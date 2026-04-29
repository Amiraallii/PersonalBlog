using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Projects.Command.UpdateProject
{
    public class UpdateProjectCommand : UpdateProjectDto, IRequest
    {
    }
}
