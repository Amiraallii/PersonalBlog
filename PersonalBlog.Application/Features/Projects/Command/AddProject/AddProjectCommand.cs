using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Projects.Command.AddProject
{
    public class AddProjectCommand : BaseProjectDto, IRequest
    {
    }
}
