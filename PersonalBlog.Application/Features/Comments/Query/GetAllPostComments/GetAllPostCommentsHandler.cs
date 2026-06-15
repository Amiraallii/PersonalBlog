using MediatR;
using Microsoft.EntityFrameworkCore;
using Personal.Domain.Contracts;
using PersonalBlog.Application.Dtos;


namespace PersonalBlog.Application.Features.Comments.Query.GetAllPostComments
{
    public class GetAllPostCommentsHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllPostCommentsCommand, PagedResultDto<CommentDto>>
    {
        public async Task<PagedResultDto<CommentDto>> Handle(GetAllPostCommentsCommand request, CancellationToken cancellationToken)
        {
            var query = unitOfWork.CommentRepository
                .GetAllComments()
                .Where(x => x.PostId == request.PostId && x.ParentId == null);

            var totalCount = await query.CountAsync(cancellationToken);


            var items = await query
                .Skip(request.Skip)
                .Take(request.PageSize)
                .Select(x =>
            new CommentDto
            {
                Id = x.Id,
                PostId = x.PostId,
                AuthorId = x.AuthorId,
                AuthorName = x.User.UserName,
                CreatedAt = x.CreateDate,
                Content = x.Content,
                ReplyCount = x.Replies.Count(),
            })
            .ToListAsync(cancellationToken);

            return new PagedResultDto<CommentDto>
            {
                Items = items,
                TotalCount = totalCount,
                HasNextPage = (request.Skip + request.PageSize) < totalCount
            };
        }
    }
}
