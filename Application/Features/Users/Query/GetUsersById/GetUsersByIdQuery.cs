using MediatR;
using Personal.Application.Dtos;

namespace Personal.Application.Features.Users.Query.GetUsersById
{
    public class GetUsersByIdQuery : IRequest<UsersDto>
    {
        public Guid UserId { get; set; }
    }
}
