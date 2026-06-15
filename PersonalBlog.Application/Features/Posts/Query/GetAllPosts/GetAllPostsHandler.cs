using MediatR;
using PersonalBlog.Application.Dtos;
using Personal.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace PersonalBlog.Application.Features.Posts.Query.GetAllPosts
{
    public class GetAllPostsHandler(IPostRepository postRepository) : IRequestHandler<GetAllPostsQuery, PagedResultDto<PostDto>>
    {
        public async Task<PagedResultDto<PostDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {

            var query = postRepository.GetAllPosts();

            var totalCount = await query.CountAsync(cancellationToken);


            var result = await query
                .OrderByDescending(x => x.PublishDate)
                .Skip(request.Skip)
                .Take(request.PageSize)
                .Select(x => new PostDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Summary = x.Summary,
                    CoverImageAddress = x.CoverImageAdd,
                    PublishDate = x.PublishDate,

                }).ToListAsync(cancellationToken);

            return new PagedResultDto<PostDto>
            {
                Items = result,
                TotalCount = totalCount,
                HasNextPage = (request.Skip + request.PageSize) < totalCount
            };


        }
    }
}
