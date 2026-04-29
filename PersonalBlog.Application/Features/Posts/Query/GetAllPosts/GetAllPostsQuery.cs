using MediatR;
using PersonalBlog.Application.Dtos;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Posts.Query.GetAllPosts
{
    public class GetAllPostsQuery : ResultFilter, IRequest<IReadOnlyList<PostDto>>
    {
    }
}
