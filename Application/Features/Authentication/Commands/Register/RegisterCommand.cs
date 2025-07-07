using MediatR;
using Personal.Application.Dtos;

namespace Personal.Application.Features.Authentication.Commands.Register
{
    public class RegisterCommand : IRequest<AuthResultDto>
    {
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
