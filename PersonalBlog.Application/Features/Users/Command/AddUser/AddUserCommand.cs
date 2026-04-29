using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Users.Command.AddUser
{
    public class AddUserCommand : RegisterDto , IRequest
    {
    }
}
