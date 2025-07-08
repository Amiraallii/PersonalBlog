using MediatR;
using Microsoft.AspNetCore.Mvc;
using Personal.Application.Dtos;
using Personal.Application.Features.Authentication.Commands.Login;
using Personal.Application.Features.Authentication.Commands.Register;

namespace Personal.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto, CancellationToken ct)
        {
            var command = new RegisterCommand
            {
                FullName = registerDto.FullName,
                Email = registerDto.Email,
                Password = registerDto.Password,
            };
            var result = await mediator.Send(command);

            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto, CancellationToken ct)
        {
            var command = new LoginCommand
            {
                Password = loginDto.Password,
                LoginIdentifier = loginDto.LoginIdentifier,
            }; 
            var result = await mediator.Send(command, ct);

            if (!result.Success)
                return BadRequest(result.Errors);

            return Ok(result);
        }
    }
}
