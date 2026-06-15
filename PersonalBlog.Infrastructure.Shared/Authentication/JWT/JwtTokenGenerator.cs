using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PersonalBlog.Domain.Entity;
using Personal.Domain.Enums;
using PersonalBlog.Application.IServices;
using PersonalBlog.Application.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PersonalBlog.Infrastructure.Shared.Authentication.JWT
{
    public class JwtTokenGenerator(PersonalSettings settings) : IJwtTokenGenerator
    {
        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new("sub", user.Id.ToString()),
                new("email", user.Email),
                new("role", user.Role?.Name ?? UserRole.User.ToString()),
                new("userName", user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.Key!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: settings.Jwt.Issuer,
                audience: settings.Jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(14),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];

            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }
    }
}
