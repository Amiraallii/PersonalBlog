using MediatR;
using Personal.Application.Dtos;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Post.Query.GetPostById
{
    public class GetPostByIdQuery : IRequest<ResultDto<PostDto>>
    {
        public Guid Id { get; set; }
    }
}
