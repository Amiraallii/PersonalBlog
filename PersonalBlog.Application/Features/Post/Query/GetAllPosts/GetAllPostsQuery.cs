using MediatR;
using Personal.Application.Dtos;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Post.Query.GetAllPosts
{
    public class GetAllPostsQuery : ResultFilter, IRequest<ResultDto<IReadOnlyList<PostDto>>>
    {
    }
}
