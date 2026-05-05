using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Projects.Query.GetAllProject
{
    public class GetAllProjectQuery : ResultFilter, IRequest<PagedResult<ProjectDto>>
    {
    }
}
