using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace TicketSystem.Services
{
    public class AuthService
    {
        private readonly SymmetricSecurityKey _key;

        public AuthService(IConfiguration configuration)
        {
            var keyBase64 = configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(keyBase64))
            {
                throw new ArgumentException("The key is not provided.");
            }

            var key = Convert.FromBase64String(keyBase64);
            if (key.Length < 32)
            {
                throw new ArgumentException("The key must be at least 256 bits (32 bytes) long.");
            }

            _key = new SymmetricSecurityKey(key);
        }

        public string GenerateToken(string username)
        {
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
