using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Projects.Query.GetProjectId
{
    public class GetProjectByIdQuery : IRequest<ProjectDto>
    {
        public int Id { get; set; }
    }
}
