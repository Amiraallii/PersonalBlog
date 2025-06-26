using Microsoft.AspNetCore.Mvc;
using Personal.Application.Dtos;
using Personal.Application.IServices;
using Personal.Infrastructure.Services;

namespace Personal.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto, CancellationToken ct)
        {
            var result = await authService.Register(registerDto, ct);

            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto, CancellationToken ct)
        {
            var result = await authService.Login(loginDto, ct);

            if (!result.Success)
                return BadRequest(result.Errors);

            return Ok(result);
        }
    }
}
