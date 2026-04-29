using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Users.Query.GetUsersById
{
    public class GetUsersByIdQuery : IRequest<UsersDto>
    {
        public Guid UserId { get; set; }
    }
}
