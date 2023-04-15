using Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Domain.Service
{
    public class TokenService: ITokenService
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;

        public TokenService(Microsoft.Extensions.Configuration.IConfiguration config)
        {
            _config = config;
        }
        public string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var issuer = _config.GetValue<dynamic>("Jwt:Issuer");
            var audience = _config.GetValue<dynamic>("Jwt:Audience");
            var keyJwt = _config.GetValue<dynamic>("Jwt:Key");
            var key = Encoding.ASCII.GetBytes(keyJwt);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, usuario.Nome),
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.Perfil.Nome),
                    new Claim(JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            return tokenHandler.WriteToken(token);
        }
    }
}
