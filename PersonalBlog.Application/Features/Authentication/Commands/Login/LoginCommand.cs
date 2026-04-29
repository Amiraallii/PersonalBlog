using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Authentication.Commands.Login
{
    public class LoginCommand : IRequest<AuthResultDto>
    {
        public string LoginIdentifier { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
