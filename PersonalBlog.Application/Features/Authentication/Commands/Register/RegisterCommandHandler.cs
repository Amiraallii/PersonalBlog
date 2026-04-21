using MediatR;
using Personal.Application.Dtos;
using Personal.Domain.Contracts;
using Personal.Domain.Enums;
using PersonalBlog.Application.IServices;
using Personal.Domain.Entity;
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

            var user = new User
            (
                request.Email,
                request.UserName,
                BCrypt.Net.BCrypt.HashPassword(request.Password),
                request.FullName,
                userRole.Id,
                userRole
            );

            await unitOfWork.UserRepository.AddUserAsync(user, ct);

            await unitOfWork.SaveChangesAsync(ct);


            return new AuthResultDto
            {
                Success = true,
                Token = jwtTokenGenerator.GenerateToken(user)
            };
        }


    }
}
