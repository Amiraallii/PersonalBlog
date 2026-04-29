using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Comments.Command.AddComment
{
    public class AddCommentCommand : AddCommentDto, IRequest
    {
        public Guid AuthorId { get; set; }
    }
}
