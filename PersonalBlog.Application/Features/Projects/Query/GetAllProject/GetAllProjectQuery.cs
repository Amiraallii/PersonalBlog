using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Projects.Query.GetAllProject
{
    public class GetAllProjectQuery : IRequest<IReadOnlyList<ProjectDto>>
    {
    }
}
