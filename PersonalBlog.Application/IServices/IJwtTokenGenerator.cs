using Personal.Domain.Entity;

namespace PersonalBlog.Application.IServices
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
