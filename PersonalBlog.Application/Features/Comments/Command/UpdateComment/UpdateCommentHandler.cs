using MediatR;
using Personal.Domain.Contracts;

namespace PersonalBlog.Application.Features.Comments.Command.UpdateComment
{
    public class UpdateCommentHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateCommentCommand>
    {
        public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await unitOfWork.CommentRepository.GetCommentByIdForUpdate(request.Id, cancellationToken);
            if (comment.AuthorId != request.AuthorId) 
            {
                throw new InvalidOperationException("کامنت متعلق به شما نمیباشد...");
            }
            await unitOfWork.CommentRepository.UpdateComment(comment, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
