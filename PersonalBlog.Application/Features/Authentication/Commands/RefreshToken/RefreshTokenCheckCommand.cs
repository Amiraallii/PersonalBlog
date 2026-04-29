using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Authentication.Commands.RefreshToken
{
    public class RefreshTokenCheckCommand : IRequest<UsersDto>
    {
        public string RefreshToken { get; set; }
    }
}
