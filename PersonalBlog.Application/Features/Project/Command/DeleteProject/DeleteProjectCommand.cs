using MediatR;

namespace PersonalBlog.Application.Features.Project.Command.DeleteProject
{
    public class DeleteProjectCommand : IRequest
    {
        public int Id { get; set; }
    }
}
