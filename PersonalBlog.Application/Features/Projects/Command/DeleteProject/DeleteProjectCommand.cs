using MediatR;

namespace PersonalBlog.Application.Features.Projects.Command.DeleteProject
{
    public class DeleteProjectCommand : IRequest
    {
        public int Id { get; set; }
    }
}
