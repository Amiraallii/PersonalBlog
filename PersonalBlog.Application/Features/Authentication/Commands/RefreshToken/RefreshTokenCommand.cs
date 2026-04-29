using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Authentication.Commands.RefreshToken
{
    public class RefreshTokenCommand : IRequest<AuthResultDto>
    {
        public string Username { get; set; }
    }
}
