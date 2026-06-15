using MediatR;
using Microsoft.EntityFrameworkCore;
using Personal.Domain.Contracts;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Projects.Query.GetAllProject
{
    internal class GetAllProjectHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllProjectQuery, PagedResultDto<ProjectDto>>
    {
        public async Task<PagedResultDto<ProjectDto>> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
        {
            var query = unitOfWork.ProjectRepository.GetAllProject();

            var totalCount = await query.CountAsync(cancellationToken);


            var items = await query
                .OrderByDescending(x => x.StartDate)
                .Skip(request.Skip)
                .Take(request.PageSize)
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

            return new PagedResultDto<ProjectDto>
            {
                Items = items,
                TotalCount = totalCount,
                HasNextPage = (request.Skip + request.PageSize) < totalCount
            };
        }

    }
}
