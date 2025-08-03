using Personal.Domain.Entity;

namespace Personal.Domain.Contracts
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Users user);
    }
}
