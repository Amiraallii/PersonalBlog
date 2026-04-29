using MediatR;
using PersonalBlog.Application.Dtos;
using PersonalBlog.Application.IServices;
using Personal.Domain.Contracts;
using PersonalBlog.Domain.Entity;
using Personal.Domain.Enums;

namespace PersonalBlog.Application.Features.Posts.Command.UpdatePost
{
    public class UpdatePostHandler(IUnitOfWork unitOfWork, IFileService fileService) :
        IRequestHandler<UpdatePostCommand>
    {
        public async Task Handle(UpdatePostCommand request, CancellationToken ct)
        {
            var post = await unitOfWork.PostRepository.GetPostById(request.Id, ct);
            post.PostContents.Clear();
            var coverImagePath = await fileService
                    .SaveFileAsync(new FileDto { FileStream = request.CoverImage, FileName = request.CoverImageName }, ct);
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
            post.UpdatePost(request.Title, request.Summary, coverImagePath, request.PublishDate);
            await unitOfWork.SaveChangesAsync(ct);
        }
    }
}
