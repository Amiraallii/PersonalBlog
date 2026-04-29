using MediatR;

namespace PersonalBlog.Application.Features.Comments.Command.ApprovedComment
{
    public class ApprovedCommentCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
