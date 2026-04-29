using MediatR;
using Personal.Domain.Contracts;

namespace PersonalBlog.Application.Features.Projects.Command.DeleteProject
{
    internal class DeleteProjectHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteProjectCommand>
    {
        public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.ProjectRepository.DeleteProjectAsync(request.Id, cancellationToken);
        }
    }
}
