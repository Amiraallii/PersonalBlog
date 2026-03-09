using MediatR;
using Personal.Domain.Contracts;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Project.Query.GetProjectId
{
    internal class GetProjectByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetProjectByIdQuery, ProjectDto>
    {
        public async Task<ProjectDto> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await unitOfWork.ProjectRepository
                .GetProjectByIdNoTrackingAsync(request.Id, cancellationToken);

            return new ProjectDto
            {
                Id = model.Id,
                Title = model.Title,
                Summary = model.Summary,
                Link = model.Link,
                Owner = model.Owner,
                StartDate = model.StartDate,
                EndDate = model.EndDate
            };
        }
    }
}
