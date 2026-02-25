using MediatR;
using Personal.Application.Dtos;
using Personal.Domain.Contracts;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Post.Query.GetPostById
{
    public class GetPostByIdHandler(IPostRepository postRepository) : IRequestHandler<GetPostByIdQuery, ResultDto<PostDto>>
    {
        public async Task<ResultDto<PostDto>> Handle(GetPostByIdQuery request, CancellationToken ct)
        {
            var entity = await postRepository.GetPostByIdNoTracking(request.Id, ct);
            if (entity == null)
            {
                return new ResultDto<PostDto> 
                { 
                    Code = 200,
                    IsSuccess = false,
                    Message = "پست مورد نظر یافت نشد",
                    Date = DateTime.UtcNow,
                    Value = null
                };
            }

            return new ResultDto<PostDto>
            {
                Code = 200,
                IsSuccess = false,
                Date = DateTime.UtcNow,
                Value = new PostDto
                {
                    CoverImageAddress = entity.CoverImageAdd,
                    Id = entity.Id,
                    PostContents = entity.PostContents.Select(x=> new ContentBlocksDto
                    {
                        Content = x.Content,
                        ContentType = x.ContentType,
                        Order = x.Order,
                    }).ToList(),
                    PublishDate = entity.PublishDate,
                    Summary = entity.Summary,
                    Title = entity.Title    
                }
            };
        }
    }
}
