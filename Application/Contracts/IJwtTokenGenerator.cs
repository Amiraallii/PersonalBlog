using Personal.Domain.Entity;

namespace Personal.Application.Contracts
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}