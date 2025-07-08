using MediatR;
using Personal.Application.Dtos;

namespace Personal.Application.Features.Authentication.Commands.Login
{
    public class LoginCommand : IRequest<AuthResultDto>
    {
        public string LoginIdentifier { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
