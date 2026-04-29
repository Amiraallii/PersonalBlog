using MediatR;
using Personal.Domain.Contracts;

namespace PersonalBlog.Application.Features.Comments.Command.UpdateComment
{
    public class UpdateCommentHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateCommentCommand>
    {
        public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await unitOfWork.CommentRepository.GetCommentById(request.Id, cancellationToken);
            if (comment.AuthorId != request.AuthorId) 
            {
                throw new InvalidOperationException("کامنت متعلق به شما نمیباشد...");
            }
            // اصلا نیاز دارم به این؟؟ بعد باید یه چک کنم ... نمیدونم چرا یهو به فکرم رسیده این... وقتی تغییر دادیم توی انتیتی نیازی نباید باشه دیگه به این..
            comment.UpdateContent(request.Content);
            await unitOfWork.CommentRepository.UpdateComment(comment, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
