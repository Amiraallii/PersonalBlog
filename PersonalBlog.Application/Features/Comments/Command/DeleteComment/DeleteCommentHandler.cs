using MediatR;
using Microsoft.EntityFrameworkCore;
using Personal.Domain.Contracts;
using System.ComponentModel.Design;

namespace PersonalBlog.Application.Features.Comments.Command.DeleteComment
{
    public class DeleteCommentHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCommentCommand, int>
    {
        public async Task<int> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await unitOfWork.CommentRepository.GetCommentById(request.Id, cancellationToken);

            if (comment == null)
                throw new InvalidOperationException("کامنت یافت نشد.");

            if (comment.AuthorId != request.AuthorId)
                throw new InvalidOperationException("کامنت متعلق به شما نمیباشد...");

           
            
            await unitOfWork.CommentRepository.DeleteReplies(request.Id, cancellationToken);    
            

            await unitOfWork.CommentRepository.DeleteComment(request.Id, cancellationToken);
            return await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
