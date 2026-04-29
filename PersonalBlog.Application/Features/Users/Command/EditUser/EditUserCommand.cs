using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Users.Command.EditUser
{
    public class EditUserCommand : EditUsersDto, IRequest
    {

    }
}
