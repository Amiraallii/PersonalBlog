using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.ProjectRequests.Command.AddProjectRequest
{
    public class AddProjectRequestCommand : CreateProjectRequestDto, IRequest
    {
        public Guid Creator { get; set; }
    }
}
