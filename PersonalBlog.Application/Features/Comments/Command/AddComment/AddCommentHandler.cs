using MediatR;
using Personal.Domain.Contracts;
using PersonalBlog.Domain.Entity;

namespace PersonalBlog.Application.Features.Comments.Command.AddComment
{
    public class AddCommentHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddCommentCommand>
    {
        public Task Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment(request.PostId, request.AuthorId, request.Content, true);
            return null;
        }
    }
}
