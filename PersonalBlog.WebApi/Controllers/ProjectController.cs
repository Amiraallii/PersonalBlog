using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Application.Dtos;
using PersonalBlog.Application.Features.Projects.Command.AddProject;
using PersonalBlog.Application.Features.Projects.Command.DeleteProject;
using PersonalBlog.Application.Features.Projects.Command.UpdateProject;
using PersonalBlog.Application.Features.Projects.Query.GetAllProject;
using PersonalBlog.Application.Features.Projects.Query.GetProjectId;

namespace PersonalBlog.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController(IMediator mediator) : PersonalController
    {
        [HttpPost("NewProject")]
        [Authorize("Admin")]
        public async Task<IActionResult> NewProject(BaseProjectDto dto, CancellationToken ct)
        {
            var command = new AddProjectCommand
            {
                Title = dto.Title,
                Summary = dto.Summary,
                Link = dto.Link,
                Owner = dto.Owner,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
            };

            await mediator.Send(command, ct);

            return Ok();
        }

        [HttpPut("UpdateProject")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateProject(UpdateProjectDto dto, CancellationToken ct)
        {
            var command = new UpdateProjectCommand
            {
                Id = dto.Id,
                Title = dto.Title,
                Summary = dto.Summary,
                Link = dto.Link,
                Owner = dto.Owner,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
            };

            await mediator.Send(command, ct);

            return Ok();
        }

        [HttpDelete("DeleteProject")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteProject(int id, CancellationToken ct)
        {
            var command = new DeleteProjectCommand
            {
                Id = id
            };

            await mediator.Send(command, ct);

            return Ok();
        }

        [HttpGet("GetAllProjects")]
        public async Task<IActionResult> GetAllProjects(CancellationToken ct)
        {
            

            var list = await mediator.Send(new GetAllProjectQuery { }, ct);

            return Ok(list);
        }

        [HttpGet("GetProjectById")]
        public async Task<IActionResult> GetProjectById(int id, CancellationToken ct)
        {


            var project = await mediator.Send(new GetProjectByIdQuery { Id = id}, ct);

            return Ok(project);
        }
    }
}
