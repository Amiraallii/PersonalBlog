using MediatR;
using Personal.Application.Dtos;
using Personal.Domain.Contracts;
using PersonalBlog.Application.IServices;
using System.Security.Cryptography;

namespace Personal.Application.Features.Authentication.Commands.Login
{
    public class LoginCommandHandler(IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator) : IRequestHandler<LoginCommand, AuthResultDto>
    {
        public async Task<AuthResultDto> Handle(LoginCommand request, CancellationToken ct)
        {
            Domain.Entity.User user;

            if (request.LoginIdentifier.Contains('@'))
            {
                user = await unitOfWork.UserRepository.GetUserByEmailAsync(request.LoginIdentifier, ct);
            }
            else
            {
                user = await unitOfWork.UserRepository.GetUserByUserNameAsync(request.LoginIdentifier, ct);
            }

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return new AuthResultDto { Success = false, Errors = ["نام کاربری یا رمز عبور اشتباه است!"] };
            }

            var refreshToken = jwtTokenGenerator.GenerateRefreshToken();
            user.UpsertToken(refreshToken, DateTime.UtcNow.AddDays(30));
            return new AuthResultDto
            {
                Success = true,
                Token = jwtTokenGenerator.GenerateToken(user),
                RefreshToken = refreshToken
            };
        }
        

    }
}
