using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Project.Command.UpdateProject
{
    public class UpdateProjectCommand : UpdateProjectDto, IRequest
    {
    }
}
