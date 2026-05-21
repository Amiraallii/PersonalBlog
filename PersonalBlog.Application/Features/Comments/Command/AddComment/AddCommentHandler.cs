using MediatR;
using Personal.Domain.Contracts;
using PersonalBlog.Domain.Entity;

namespace PersonalBlog.Application.Features.Comments.Command.AddComment
{
    public class AddCommentHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddCommentCommand>
    {
        public async Task Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            if (request.ParentId.HasValue)
            {
                var parent  = await unitOfWork.CommentRepository
                    .GetCommentById(request.ParentId.Value, cancellationToken);

                if (parent == null)
                {
                    throw new KeyNotFoundException();
                }

                if (parent.ParentId.HasValue)
                    request.ParentId = parent.ParentId.Value;

            }
            var comment = new Comment(request.PostId, request.AuthorId, request.Content, true, request.ParentId);
            await unitOfWork.CommentRepository.AddComment(comment, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
