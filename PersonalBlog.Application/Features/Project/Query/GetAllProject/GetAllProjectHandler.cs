using MediatR;
using Microsoft.EntityFrameworkCore;
using Personal.Domain.Contracts;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Project.Query.GetAllProject
{
    internal class GetAllProjectHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllProjectQuery, IReadOnlyList<ProjectDto>>
    {
        public async Task<IReadOnlyList<ProjectDto>> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
        {
            var list = await unitOfWork.ProjectRepository
                .GetAllProject()
                .Select(x => new ProjectDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Summary = x.Summary,
                    Owner = x.Owner,
                    Link = x.Link,
                    EndDate = x.EndDate,
                    StartDate = x.StartDate,
                }).ToListAsync();

            return list;
        }
    }
}
