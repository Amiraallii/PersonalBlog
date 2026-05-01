using MediatR;
using Microsoft.EntityFrameworkCore;
using Personal.Domain.Contracts;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Comments.Query.GetAllComment
{
    public class GetAllCommentHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllCommentCommand, IReadOnlyList<CommentDto>>
    {
        public async Task<IReadOnlyList<CommentDto>> Handle(GetAllCommentCommand request, CancellationToken cancellationToken)
        {
            var query = unitOfWork.CommentRepository.
                GetAllComments(cancellationToken)
                .Include(x => x.User);
            return await query.Select(x => new CommentDto
            {
                Id = x.Id,
                AuthorId = x.AuthorId,
                Content = x.Content,
                IsApproved = x.IsApproved,
                PostId = x.PostId,
                AuthorName = x.User.UserName
            })
                .ToListAsync(cancellationToken);
        }
    }
}
