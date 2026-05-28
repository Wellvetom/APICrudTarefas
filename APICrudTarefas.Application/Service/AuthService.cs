
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using APICrudTarefas.Domain.Configurations;

namespace APICrudTarefas.Application.Service
{

    public class AuthService 
    {
        private readonly JwtSettings _settings;

        public AuthService(IConfiguration configuration)
        {
            _settings = configuration.GetSection("Jwt").Get<JwtSettings>()!;
        }

        public string GerarToken(string usuario)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, usuario)
        };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_settings.Key));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_settings.ExpiresInMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
