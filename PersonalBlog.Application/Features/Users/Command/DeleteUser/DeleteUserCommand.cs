using MediatR;
using Personal.Application.Dtos;

namespace Personal.Application.Features.Users.Command.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public Guid UserId { get; set; }
    }
}
