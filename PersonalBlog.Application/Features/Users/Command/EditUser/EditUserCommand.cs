using MediatR;
using Personal.Application.Dtos;

namespace Personal.Application.Features.Users.Command.EditUser
{
    public class EditUserCommand : EditUsersDto, IRequest
    {

    }
}
