using MediatR;
using Personal.Application.Dtos;
using Personal.Domain.Contracts;
using Personal.Domain.Entity;
using Personal.Domain.Enums;

namespace Personal.Application.Features.Authentication.Commands.Register
{
    public class RegisterCommandHandler(IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator) : IRequestHandler<RegisterCommand, AuthResultDto>
    {
        public async Task<AuthResultDto> Handle(RegisterCommand request, CancellationToken ct)
        {
            var existingEmail = await unitOfWork.UserRepository.GetUserByEmailAsync(request.Email, ct);
            if (existingEmail != null)
            {
                return new AuthResultDto { Success = false, Errors = ["ایمیل تکراری است"] };
            }
            var existingUser = await unitOfWork.UserRepository.GetUserByUserNameAsync(request.UserName, ct);
            if (existingUser != null)
            {
                return new AuthResultDto { Success = false, Errors = ["نام کاربری تکراری است"] };
            }
            var userRole = await unitOfWork.UserRepository.GetRoleByNameAsync(UserRole.User.ToString(), ct);

            var user = new Domain.Entity.Users
            {
                Id = Guid.NewGuid(),
                FullName = request.FullName,
                Email = request.Email,
                UserName = request.UserName,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                RoleId = userRole.Id
            };

            await unitOfWork.UserRepository.AddUserAsync(user, ct);

            await unitOfWork.SaveChangesAsync(ct);

            user.Role = userRole;


            return new AuthResultDto
            {
                Success = true,
                Token = jwtTokenGenerator.GenerateToken(user)
            };
        }


    }
}
