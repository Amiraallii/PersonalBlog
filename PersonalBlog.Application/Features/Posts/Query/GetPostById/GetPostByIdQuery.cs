using MediatR;
using PersonalBlog.Application.Dtos;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Posts.Query.GetPostById
{
    public class GetPostByIdQuery : IRequest<PostDto>
    {
        public Guid Id { get; set; }
    }
}
