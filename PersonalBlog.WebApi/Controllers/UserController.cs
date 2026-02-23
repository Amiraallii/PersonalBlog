using MediatR;
using Microsoft.AspNetCore.Mvc;
using Personal.Application.Dtos;
using Personal.Application.Features.Authentication.Commands.Register;
using Personal.Application.Features.Users.Command.DeleteUser;
using Personal.Application.Features.Users.Command.EditUser;
using Personal.Application.Features.Users.Query.GetAllUsersQuery;
using Personal.Application.Features.Users.Query.GetUsersById;
using PersonalBlog.Application.Features.Users.Command.AddUser;

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

            var result = await mediator.Send(new GetUsersByIdQuery { UserId = userId });

            return Ok(result);
        }

        [HttpDelete("DeleteUserById")]
        public async Task<IActionResult> DeleteUserById(Guid userId, CancellationToken ct)
        {

            await mediator.Send(new DeleteUserCommand { UserId = userId });

            return Ok();
        }

        [HttpPut("EditUserInfo")]
        public async Task<IActionResult> EditUserInfo(EditUsersDto dto, CancellationToken ct)
        {

            await mediator.Send(new EditUserCommand
            {
                Id = dto.Id,
                Email = dto.Email,
                FullName = dto.FullName,
                UserName = dto.UserName
            });

            return Ok();
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(RegisterDto dto, CancellationToken ct)
        {

            await mediator.Send(new AddUserCommand
            {
                Email = dto.Email,
                FullName = dto.FullName,
                UserName = dto.UserName,
                Password = dto.Password
            });

            return Ok();
        }
    }
}
