using MediatR;
using Personal.Application.Dtos;
using Personal.Domain.Contracts;
using PersonalBlog.Application.Dtos;
using Microsoft.EntityFrameworkCore;

namespace PersonalBlog.Application.Features.Post.Query.GetAllPosts
{
    public class GetAllPostsHandler(IPostRepository postRepository) : IRequestHandler<GetAllPostsQuery, IReadOnlyList<PostDto>>
    {
        public async Task<IReadOnlyList<PostDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {

            var query = postRepository.GetAllPosts();
            if (!await query.AnyAsync())
                throw new KeyNotFoundException();

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

            return result;


        }
    }
}
