using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Application.Dtos;
using PersonalBlog.Application.Features.PersonalInformation.Command.UpsertPersonalInformation;
using PersonalBlog.Application.Features.PersonalInformation.Query.GetPersonalInformationNoTracking;

namespace PersonalBlog.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonalInformationController(IMediator mediator) : PersonalController
    {
        [HttpPost("ModifyInfo")]
        public async Task<IActionResult> UpsertPersonalInformation(PersonalInformationDto model, CancellationToken ct)
        {
            var command = new UpsertPersonalInformationCommand
            {
                AboutMe = model.AboutMe,
                ContactInfo = model.ContactInfo,
                JobTitle = model.JobTitle,
                LastName = model.LastName,
                Name = model.Name,
            };

            await mediator.Send(command, ct);

            return Ok();
        }

        [HttpGet("GetPersonalInfo")]
        public async Task<IActionResult> GetPersonalInfo(CancellationToken ct)
        {
            var query = new GetPersonalInformationNoTrackingQuery();

            var model = await mediator.Send(query, ct);

            return Ok(model);
        }
    }
}
