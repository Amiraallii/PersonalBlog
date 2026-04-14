using MediatR;

namespace PersonalBlog.Application.Features.Authentication.Commands.Logout
{
    public class LogoutCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
