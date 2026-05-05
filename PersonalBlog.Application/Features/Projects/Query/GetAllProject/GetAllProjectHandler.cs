using MediatR;
using Microsoft.EntityFrameworkCore;
using Personal.Domain.Contracts;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Projects.Query.GetAllProject
{
    internal class GetAllProjectHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllProjectQuery, PagedResult<ProjectDto>>
    {
        public async Task<PagedResult<ProjectDto>> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
        {
            var query = unitOfWork.ProjectRepository.GetAllProject();

            var totalCount = await query.CountAsync(cancellationToken);

            var skip = (request.Skip - 1) * request.Size;

            var items = await query
                .OrderByDescending(x => x.StartDate)
                .Skip(skip)
                .Take(request.Size)
                .Select(x => new ProjectDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Summary = x.Summary,
                    Owner = x.Owner,
                    Link = x.Link,
                    EndDate = x.EndDate,
                    StartDate = x.StartDate,
                }).ToListAsync(cancellationToken);

            return new PagedResult<ProjectDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = request.Skip,
                PageSize = request.Size
            };
        }

    }
}
