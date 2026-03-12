using MediatR;
using Personal.Application.Dtos;

namespace PersonalBlog.Application.Features.Authentication.Commands.RefreshToken
{
    public class RefreshTokenCommand : IRequest<AuthResultDto>
    {
        public string Username { get; set; }
    }
}
