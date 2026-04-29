using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Comments.Command.UpdateComment
{
    public class UpdateCommentCommand : UpdateCommentDto, IRequest
    {
        public Guid AuthorId { get; set; }
    }
}
