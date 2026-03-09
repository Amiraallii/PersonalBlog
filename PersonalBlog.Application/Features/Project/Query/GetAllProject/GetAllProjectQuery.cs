using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Project.Query.GetAllProject
{
    public class GetAllProjectQuery : IRequest<IReadOnlyList<ProjectDto>>
    {
    }
}
