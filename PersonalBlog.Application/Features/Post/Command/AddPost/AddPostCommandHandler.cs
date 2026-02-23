using MediatR;
using Personal.Application.Dtos;
using Personal.Application.IServices;
using Personal.Domain.Contracts;
using Personal.Domain.Entity;
using Personal.Domain.Enums;

namespace Personal.Application.Features.Post.Command.AddPost
{
    public class AddPostCommandHandler(IUnitOfWork unitOfWork, IFileService fileService) : IRequestHandler<AddPostCommand, ResultDto>    
    {
        public async Task<ResultDto> Handle(AddPostCommand request, CancellationToken ct)
        {
            try
            {
                var coverImagePath = await fileService
                    .SaveFileAsync(new FileDto { FileStream = request.CoverImage, FileName = request.CoverImageName }, ct);

                var post = new Posts
                {
                    CreateDate = DateTime.Now,
                    PublishDate = request.PublishDate,
                    CoverImageAdd = coverImagePath,
                    Title = request.Title,
                    ContentBlocks = new List<PostContentBlock>()

                };
                foreach (var blockCommand in request.Contents.OrderBy(b => b.Order))
                {
                    var newBlock = new PostContentBlock
                    {
                        Order = blockCommand.Order,
                        BlockType = blockCommand.ContentType,
                    };

                    if (blockCommand.ContentType == ContentTypeEnum.Text)
                    {
                        newBlock.Content = blockCommand.Content;
                    }
                    else 
                    {
                        if (blockCommand.Media != null)
                        {
                            var mediaPath = await fileService.SaveFileAsync(new FileDto { FileStream = blockCommand.Media, FileName = blockCommand.FileName }, ct);
                            newBlock.Content = mediaPath;
                        }
                    }
                    post.ContentBlocks.Add(newBlock);

                }
                await unitOfWork.PostRepository.AddPost(post, ct);
                await unitOfWork.SaveChangesAsync(ct);
                return new ResultDto { Code = 200, IsSuccess = true, Message = "پست با موفقیت ذخیره شد" };
            }
            catch (Exception ex)
            {

                return new ResultDto { Code = 500, IsSuccess = false, Message = ex.Message };

            }
        }

        
    }
}
