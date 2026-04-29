using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Application.Dtos;
using PersonalBlog.Application.Features.Authentication.Commands.Register;
using PersonalBlog.Application.Features.Users.Command.AddUser;
using PersonalBlog.Application.Features.Users.Command.DeleteUser;
using PersonalBlog.Application.Features.Users.Command.EditUser;
using PersonalBlog.Application.Features.Users.Query.GetAllUsersQuery;
using PersonalBlog.Application.Features.Users.Query.GetUsersById;

namespace PersonalBlog.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAllUsers")]
        [Authorize("Admin")]
        public async Task<IActionResult> GetAllUsers(CancellationToken ct)
        {

            var result = await mediator.Send(new GetAllUsersQuery { });

            return Ok(result);
        }

        [HttpGet("GetUsersById")]
        [Authorize("Admin")]
        public async Task<IActionResult> GetUsersById(Guid userId, CancellationToken ct)
        {

            var result = await mediator.Send(new GetUsersByIdQuery { UserId = userId });

            return Ok(result);
        }

        [HttpDelete("DeleteUserById")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteUserById(Guid userId, CancellationToken ct)
        {

            await mediator.Send(new DeleteUserCommand { UserId = userId });

            return Ok();
        }

        [HttpPut("EditUserInfo")]
        [Authorize("Admin")]
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
        [Authorize("Admin")]
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
