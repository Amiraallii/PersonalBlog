using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Comments.Query.GetCommentById
{
    public class GetCommentByIdCommand : IRequest<CommentDto>
    {
        public Guid Id { get; set; }
    }
}
