using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Personal.Application.Dtos;
using Personal.Application.IServices;
using Personal.Domain.Entity;
using Personal.Infrastructure.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Personal.Infrastructure.Services
{
    public class AuthService(ApplicationDbContext context, IConfiguration configuration) : IAuthService
    {



        public async Task<AuthResultDto> Register(RegisterDto registerDto, CancellationToken ct)
        {
            var existingUser = await context.Users.FirstOrDefaultAsync(x => x.Email == registerDto.Email);
            if (existingUser != null)
            {
                return new AuthResultDto { Success = false, Errors = ["ایمیل تکراری است"] };
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                FullName = registerDto.FullName,
                Email = registerDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                RoleId = await context.Roles
                        .Where(r => r.Name == "User")
                        .Select(r => r.Id)
                        .FirstOrDefaultAsync()
            };

            await context.Users.AddAsync(user, ct);
            await context.SaveChangesAsync(ct);

            return new AuthResultDto
            {
                Success = true,
                Token = GenerateJwtToken(user)
            };

        }
        public async Task<AuthResultDto> Login(LoginDto loginDto, CancellationToken ct)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email, ct);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            {
                return new AuthResultDto { Success = false, Errors = ["نام کاربری یا رمز اشتباه است"] };
            }
            return new AuthResultDto
            {
                Success = true,
                Token = GenerateJwtToken(user)
            };
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new(ClaimTypes.Email,user.Email),
                new(ClaimTypes.Role,user.Role?.Name??"User")
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
