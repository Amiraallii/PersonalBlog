using MediatR;
using Personal.Application.Dtos;
using Personal.Domain.Contracts;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Post.Query.GetPostById
{
    public class GetPostByIdHandler(IPostRepository postRepository) : IRequestHandler<GetPostByIdQuery, PostDto>
    {
        public async Task<PostDto> Handle(GetPostByIdQuery request, CancellationToken ct)
        {
            var entity = await postRepository.GetPostByIdNoTracking(request.Id, ct);
            if (entity == null)
            {
                throw new KeyNotFoundException();
            }

            return new PostDto
            {
               
                    Id = entity.Id,
                    Title = entity.Title,
                    Summary = entity.Summary,
                    PublishDate = entity.PublishDate,
                    CoverImageAddress = entity.CoverImageAdd,
                    PostContents = entity.PostContents.Select(x=> new ContentBlocksDto
                    {
                        Content = x.Content,
                        ContentType = x.ContentType,
                        Order = x.Order,
                    }).ToList()
                
            };
        }
    }
}
