using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Users.Command.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public Guid UserId { get; set; }
    }
}
