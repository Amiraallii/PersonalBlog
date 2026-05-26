using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Application.Dtos;
using PersonalBlog.Application.Features.ProjectRequests.Command.AddProjectRequest;

namespace PersonalBlog.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProjectRequestController(IMediator mediator) : PersonalController
    {
        [HttpPost("RequestNewProject")]
        public async Task<IActionResult> RequestNewProject(CreateProjectRequestDto dto, CancellationToken ct)
        {
            var command = new AddProjectRequestCommand
            {
                Location = dto.Location,
                PhoneNumber = dto.PhoneNumber,
                Summary = dto.Summary,
                Title = dto.Title,
                Creator = CurrentUserId,
            };
            await mediator.Send(command);
            return Ok();    
        }
    }
}
