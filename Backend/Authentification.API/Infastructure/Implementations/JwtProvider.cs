using Authentification.API.Helpers.Configurations;
using Authentification.API.Infastructure.Interfaces;
using Authentification.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentification.API.Infastructure.Implementations
{
    public class JwtProvider : IJwtProvider
    {
        private readonly IConfiguration configuration;

        public JwtProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var jwtConf = configuration.GetSection("JwtConf").Get<JwtConfigurations>();

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConf!.SecretKey)), 
                SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("UserName", user.UserName),
                new Claim("Email", user.Email),
                new Claim("Role", user.Role.ToString())

            };

            var token = new JwtSecurityToken(
                audience: jwtConf.Audience,
                issuer: jwtConf.Issuer,
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddMinutes(1)
                );
        
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
