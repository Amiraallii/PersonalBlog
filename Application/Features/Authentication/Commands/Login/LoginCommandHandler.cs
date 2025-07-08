using MediatR;
using Personal.Application.Contracts;
using Personal.Application.Dtos;
using Personal.Domain.Entity;

namespace Personal.Application.Features.Authentication.Commands.Login
{
    public class LoginCommandHandler(IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator) : IRequestHandler<LoginCommand, AuthResultDto>
    {
        public async Task<AuthResultDto> Handle(LoginCommand request, CancellationToken ct)
        {
            User user;

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
            return new AuthResultDto
            {
                Success = true,
                Token = jwtTokenGenerator.GenerateToken(user),
            };
        }


    }
}
