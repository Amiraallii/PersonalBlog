using MediatR;
using PersonalBlog.Application.Dtos;
using PersonalBlog.Application.IServices;
using Personal.Domain.Contracts;
using PersonalBlog.Domain.Entity;
using Personal.Domain.Enums;

namespace PersonalBlog.Application.Features.Posts.Command.AddPost
{
    public class AddPostCommandHandler(IUnitOfWork unitOfWork, IFileService fileService) : IRequestHandler<AddPostCommand>
    {
        public async Task Handle(AddPostCommand request, CancellationToken ct)
        {

            var coverImagePath = await fileService
                .SaveFileAsync(new FileDto { FileStream = request.CoverImage, FileName = request.CoverImageName }, ct);

            var post = new Domain.Entity.Post
            (
                request.Title,
                request.Summary,
                request.AuthorId,
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
                        var mediaPath = await fileService
                            .SaveFileAsync(new FileDto { FileStream = blockCommand.Media, FileName = blockCommand.FileName }, ct);
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


        }


    }
}
