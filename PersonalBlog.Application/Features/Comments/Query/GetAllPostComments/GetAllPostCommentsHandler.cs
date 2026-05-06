using MediatR;
using Microsoft.EntityFrameworkCore;
using Personal.Domain.Contracts;
using PersonalBlog.Application.Dtos;


namespace PersonalBlog.Application.Features.Comments.Query.GetAllPostComments
{
    public class GetAllPostCommentsHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllPostCommentsCommand, IReadOnlyList<CommentDto>>
    {
        public async Task<IReadOnlyList<CommentDto>> Handle(GetAllPostCommentsCommand request, CancellationToken cancellationToken)
        {
            var skip = (request.Skip - 1) * request.Size;
            var query = unitOfWork.CommentRepository
                .GetAllComments(cancellationToken)
                .Where(x => x.PostId == request.PostId)
                .Skip(skip)
                .Take(request.Size)
                .Include(x => x.User);

            return await query.Select(x =>
            new CommentDto
            {
                Id = x.Id,
                PostId = x.PostId,
                AuthorId = x.AuthorId,
                AuthorName = x.User.UserName,
                CreatedAt = x.CreateDate,
                Content = x.Content,
            }
            ).ToListAsync(cancellationToken);
        }
    }
}
