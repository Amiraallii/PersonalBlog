using MediatR;
using Personal.Application.Dtos;
using Personal.Domain.Contracts;
using Personal.Domain.Entity;
using PersonalBlog.Application.IServices;

namespace PersonalBlog.Application.Features.Authentication.Commands.RefreshToken
{
    public class RefreshTokenHandler(IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator) : IRequestHandler<RefreshTokenCommand, AuthResultDto>
    {
        public async Task<AuthResultDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.UserRepository
                .GetUserByUserNameAsync(request.Username, cancellationToken);
            var refreshToken = jwtTokenGenerator.GenerateRefreshToken();
            user.UpsertToken(refreshToken, DateTime.UtcNow.AddDays(30));
            await unitOfWork.SaveChangesAsync();
            return new AuthResultDto
            {
                Success = true,
                Token = jwtTokenGenerator.GenerateToken(user),
                RefreshToken = refreshToken
            };
        }
    }
}
