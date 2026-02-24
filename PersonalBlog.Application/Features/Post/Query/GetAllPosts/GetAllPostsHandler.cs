using MediatR;
using Personal.Application.Dtos;
using Personal.Domain.Contracts;
using PersonalBlog.Application.Dtos;
using Microsoft.EntityFrameworkCore;

namespace PersonalBlog.Application.Features.Post.Query.GetAllPosts
{
    public class GetAllPostsHandler(IPostRepository postRepository) : IRequestHandler<GetAllPostsQuery, ResultDto<IReadOnlyList<PostDto>>>
    {
        public async Task<ResultDto<IReadOnlyList<PostDto>>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = postRepository.GetAllPosts();
                if(!await query.AnyAsync())
                    return new ResultDto<IReadOnlyList<PostDto>>
                    {
                        IsSuccess = false,
                        Code = 404,
                        Message = "محتوایی وجود ندارد",
                        Date = DateTime.UtcNow,
                    };
                var result = await query
                    .OrderByDescending(x => x.PublishDate)
                    .Skip(request.Skip)
                    .Take(request.Size)
                    .Select(x => new PostDto
                    {
                        CoverImageAddress = x.CoverImageAdd,
                        Id = x.Id,
                        PostContents = x.PostContents.Select(x => new ContentBlocksDto
                        {
                            Content = x.Content,
                            ContentType = x.ContentType
                        }).ToList(),
                        PublishDate = x.PublishDate,
                        Title = x.Title

                    }).ToListAsync(cancellationToken);
                return new ResultDto<IReadOnlyList<PostDto>>
                {
                    IsSuccess = true,
                    Value = result
                    
                };  
            }
            catch (Exception ex)
            {

                return new ResultDto<IReadOnlyList<PostDto>>
                {
                    IsSuccess = false,
                    Code = 500,
                    Message = ex.Message,
                    Date = DateTime.UtcNow,
                };
            }
            
        }
    }
}
