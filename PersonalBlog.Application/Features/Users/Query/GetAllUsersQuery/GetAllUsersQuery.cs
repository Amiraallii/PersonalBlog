using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Users.Query.GetAllUsersQuery
{
    public class GetAllUsersQuery : IRequest<List<UsersDto>>
    {
    }
}
