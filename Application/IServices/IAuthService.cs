using Personal.Application.Dtos;

namespace Personal.Application.IServices
{
    public interface IAuthService
    {
        Task<AuthResultDto> Login(LoginDto loginDto, CancellationToken ct);
        Task<AuthResultDto> Register(RegisterDto registerDto, CancellationToken ct);
    }
}
