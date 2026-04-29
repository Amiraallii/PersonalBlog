using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Authentication.Commands.Register
{
    public class RegisterCommand : IRequest<AuthResultDto>
    {
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
