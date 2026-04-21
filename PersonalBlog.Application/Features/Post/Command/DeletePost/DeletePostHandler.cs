using MediatR;
using Personal.Application.Dtos;
using Personal.Application.IServices;
using Personal.Domain.Contracts;

namespace PersonalBlog.Application.Features.Post.Command.DeletePost
{
    public class DeletePostHandler(IUnitOfWork unitOfWork, IFileService fileService) : IRequestHandler<DeletePostCommand>
    {
        public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await unitOfWork.PostRepository.GetPostById(request.Id, cancellationToken);
            await fileService.DeleteFile(post.CoverImageAdd, cancellationToken);
            foreach(var item in post.PostContents)
            {
                if (item.ContentType == Personal.Domain.Enums.ContentTypeEnum.Image || item.ContentType == Personal.Domain.Enums.ContentTypeEnum.Video)
                    await fileService.DeleteFile(item.Content, cancellationToken);

            }
            await unitOfWork.PostRepository.DeletePost(request.Id, cancellationToken);
            

        }
    }
}
