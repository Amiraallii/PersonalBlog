using MediatR;
using Personal.Domain.Contracts;

namespace PersonalBlog.Application.Features.Project.Command.AddProject
{
    public class AddProjectHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddProjectCommand>
    {
        public async Task Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            var model = new PersonalBlog.Domain.Entity.Project(request.Title, request.Summary, request.Owner, request.Link, request.StartDate, request.EndDate);

            await unitOfWork.ProjectRepository.AddProjectAsync(model, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
