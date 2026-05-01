using MediatR;
using Personal.Domain.Contracts;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Comments.Query.GetCommentById
{
    public class GetCommentByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetCommentByIdCommand, CommentDto>
    {
        public async Task<CommentDto> Handle(GetCommentByIdCommand request, CancellationToken cancellationToken)
        {
            var comment = await unitOfWork.CommentRepository
                .GetCommentById(request.Id, cancellationToken);
            if (comment == null)
            {
                throw new KeyNotFoundException();
            }

            return new CommentDto
            {
                Id = comment.Id,
                AuthorId = comment.AuthorId,
                Content = comment.Content,
                IsApproved = comment.IsApproved,
                PostId = comment.PostId,
            };
        }
    }
}
