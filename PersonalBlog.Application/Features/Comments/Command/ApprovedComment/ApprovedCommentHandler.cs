using MediatR;
using Personal.Domain.Contracts;

namespace PersonalBlog.Application.Features.Comments.Command.ApprovedComment
{
    public class ApprovedCommentHandler(IUnitOfWork unitOfWork) : IRequestHandler<ApprovedCommentCommand>
    {
        public async Task Handle(ApprovedCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await unitOfWork.CommentRepository.GetCommentByIdForUpdate(request.Id, cancellationToken);

            comment.ApprovedState();
            await unitOfWork.SaveChangesAsync(cancellationToken);   
        }
    }
}
