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
                var contents = request.PostContents.OrderBy(b => b.Order).ToList();
                var post = new Domain.Entity.Post
                (
                    request.Title,
                    request.Summary,
                    coverImagePath,
                    request.PublishDate

                );
                foreach (var blockCommand in request.PostContents.OrderBy(b => b.Order))
                {
                    string finalContent = string.Empty;

                    if (blockCommand.ContentType == ContentTypeEnum.Text || blockCommand.ContentType == ContentTypeEnum.Heading)
                    {
                        finalContent = blockCommand.Content;
                    }
                    else
                    {
                        if (blockCommand.Media != null)
                        {
                            var mediaPath = await fileService.SaveFileAsync(new FileDto { FileStream = blockCommand.Media, FileName = blockCommand.FileName }, ct);
                            finalContent = mediaPath;
                        }
                    }
                    var newBlock = new PostContentBlock
                    (
                        blockCommand.Order,
                        blockCommand.ContentType,
                        finalContent
                    );

                    
                    post.AddContentBlock(newBlock);

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
