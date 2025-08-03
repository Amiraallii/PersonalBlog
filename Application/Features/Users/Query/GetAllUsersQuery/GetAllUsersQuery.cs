using MediatR;
using Personal.Application.Dtos;

namespace Personal.Application.Features.Users.Query.GetAllUsersQuery
{
    public class GetAllUsersQuery : IRequest<List<UsersDto>>
    {
    }
}
