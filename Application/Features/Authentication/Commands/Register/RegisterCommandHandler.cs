using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Personal.Application.Contracts;
using Personal.Application.Dtos;
using Personal.Domain.Entity;
using Personal.Domain.Enums;

namespace Personal.Application.Features.Authentication.Commands.Register
{
    public class RegisterCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuration) : IRequestHandler<RegisterCommand, AuthResultDto>
    {
        public async Task<AuthResultDto> Handle(RegisterCommand request, CancellationToken ct)
        {
            var existingUser = await unitOfWork.UserRepository.GetUserByEmailAsync(request.Email, ct);
            if (existingUser != null)
            {
                return new AuthResultDto { Success = false, Errors = ["ایمیل تکراری است"] };
            }
            var userRole = await unitOfWork.UserRepository.GetRoleByNameAsync(UserRole.User.ToString(), ct);

            var user = new User
            {
                Id = Guid.NewGuid(),
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                RoleId = userRole.Id
            };

            await unitOfWork.UserRepository.AddUserAsync(user, ct);

            await unitOfWork.SaveChangesAsync(ct);

            user.Role = userRole;


            return new AuthResultDto
            {
                Success = true,
                Token = GenerateJwtToken(user, configuration)
            };
        }

        private string GenerateJwtToken(User user, IConfiguration configuration)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new(ClaimTypes.Email,user.Email),
                new(ClaimTypes.Role,user.Role?.Name ?? UserRole.User.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
