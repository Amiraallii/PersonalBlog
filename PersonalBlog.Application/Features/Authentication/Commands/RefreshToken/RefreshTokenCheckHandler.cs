using MediatR;
using Microsoft.EntityFrameworkCore;
using Personal.Application.Dtos;
using Personal.Domain.Contracts;
using PersonalBlog.Application.IServices;

namespace PersonalBlog.Application.Features.Authentication.Commands.RefreshToken
{
    public class RefreshTokenCheckHandler(IUnitOfWork unitOfWork) : IRequestHandler<RefreshTokenCheckCommand, UsersDto>
    {
        public async Task<UsersDto> Handle(RefreshTokenCheckCommand request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.UserRepository
                        .GetUserByRefreshTokenAsync(request.RefreshToken, cancellationToken);
            if (user == null)
                return null;

            return new UsersDto
            {
                UserName = user.UserName,
                RefreshTokenExpireDate = user.RefreshTokenExpireDate
            };
        }
    }
}
