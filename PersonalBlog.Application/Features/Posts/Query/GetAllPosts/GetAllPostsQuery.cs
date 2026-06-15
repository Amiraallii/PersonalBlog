using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Posts.Query.GetAllPosts
{
    public class GetAllPostsQuery : PagingRequestDto, IRequest<PagedResultDto<PostDto>>
    {
    }
}
