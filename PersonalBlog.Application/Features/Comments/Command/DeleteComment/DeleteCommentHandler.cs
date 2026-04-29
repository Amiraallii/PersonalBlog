using MediatR;
using Personal.Domain.Contracts;

namespace PersonalBlog.Application.Features.Comments.Command.DeleteComment
{
    public class DeleteCommentHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCommentCommand, int>
    {
        public async Task<int> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await unitOfWork.CommentRepository.GetCommentById(request.Id, cancellationToken);
            if (comment.AuthorId != request.AuthorId)
            {
                throw new InvalidOperationException("کامنت متعلق به شما نمیباشد...");
            }
            await unitOfWork.CommentRepository.DeleteComment(request.Id, cancellationToken);
            return await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
