using MediatR;
using Personal.Domain.Contracts;

namespace PersonalBlog.Application.Features.Project.Command.UpdateProject
{
    internal class UpdateProjectHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateProjectCommand>
    {
        public async Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await unitOfWork.ProjectRepository.GetProjectByIdAsync(request.Id, cancellationToken);

            if (entity == null)
                throw new KeyNotFoundException();

            entity.UpdateProject(request.Title, request.Summary, request.Owner, request.Link, request.StartDate, request.EndDate);

            await unitOfWork.ProjectRepository.UpdateProject(entity);

            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
