using MediatR;
using Personal.Application.Dtos;
using Personal.Domain.Contracts;

namespace PersonalBlog.Application.Features.Post.Command.DeletePost
{
    public class DeletePostHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeletePostCommand>
    {
        public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {

            await unitOfWork.PostRepository.DeletePost(request.Id, cancellationToken);
            

        }
    }
}
