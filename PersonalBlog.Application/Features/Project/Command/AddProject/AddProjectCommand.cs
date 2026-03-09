using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Project.Command.AddProject
{
    public class AddProjectCommand : BaseProjectDto, IRequest
    {
    }
}
