using MediatR;
using Microsoft.AspNetCore.Mvc;
using Personal.Application.Dtos;
using Personal.Application.Features.Authentication.Commands.Register;
using Personal.Application.Features.Users.Command.DeleteUser;
using Personal.Application.Features.Users.Query.GetAllUsersQuery;
using Personal.Application.Features.Users.Query.GetUsersById;

namespace Personal.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers(CancellationToken ct)
        {
            
            var result = await mediator.Send(new GetAllUsersQuery { });

            return Ok(result);
        }

        [HttpGet("GetUsersById")]
        public async Task<IActionResult> GetUsersById(Guid userId, CancellationToken ct)
        {

            var result = await mediator.Send(new GetUsersByIdQuery { UserId = userId});

            return Ok(result);
        }
        [HttpDelete("DeleteUserById")]
        public async Task<IActionResult> DeleteUserById(Guid userId, CancellationToken ct)
        {

            await mediator.Send(new DeleteUserCommand { UserId = userId });

            return Ok();
        }
    }
}
