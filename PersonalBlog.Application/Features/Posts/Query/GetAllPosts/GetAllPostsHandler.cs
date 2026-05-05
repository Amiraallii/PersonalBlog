using MediatR;
using PersonalBlog.Application.Dtos;
using Personal.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace PersonalBlog.Application.Features.Posts.Query.GetAllPosts
{
    public class GetAllPostsHandler(IPostRepository postRepository) : IRequestHandler<GetAllPostsQuery, PagedResult<PostDto>>
    {
        public async Task<PagedResult<PostDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {

            var query = postRepository.GetAllPosts();

            var totalCount = await query.CountAsync(cancellationToken);

            var skip = (request.Skip - 1) * request.Size;

            var result = await query
                .OrderByDescending(x => x.PublishDate)
                .Skip(skip)
                .Take(request.Size)
                .Select(x => new PostDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Summary = x.Summary,
                    CoverImageAddress = x.CoverImageAdd,
                    PublishDate = x.PublishDate,

                }).ToListAsync(cancellationToken);

            return new PagedResult<PostDto>
            {
                Items = result,
                TotalCount = totalCount,
                PageNumber = request.Skip,
                PageSize = request.Size
            };


        }
    }
}
