using PersonalBlog.Domain.Entity;
using System.Security.Cryptography;

namespace PersonalBlog.Application.IServices
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
        string GenerateRefreshToken();
       
    }
}
