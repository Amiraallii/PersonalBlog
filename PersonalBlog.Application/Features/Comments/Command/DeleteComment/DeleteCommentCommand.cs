using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Comments.Command.DeleteComment
{
    public class DeleteCommentCommand : IRequest<int>
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
    }
}
