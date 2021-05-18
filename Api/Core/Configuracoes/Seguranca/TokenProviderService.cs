using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Api.Core.Configuracoes.Seguranca
{

    public class TokenProviderService
    {
        private readonly IConfiguration _configuration;
        public TokenProviderService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(Dictionary<string, string> claimsAdd)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Appsettings:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(GerarClaims(claimsAdd)),
                Audience = _configuration["Appsettings:Audience"],
                Issuer = _configuration["Appsettings:Issuer"],
                Expires = DateTime.UtcNow.AddHours(Convert.ToInt32(_configuration["Appsettings:Expiration"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenGerado = tokenHandler.WriteToken(token);
            return tokenGerado;
        }

        private Claim[] GerarClaims(Dictionary<string, string> claimsAdd)
        {
            var claims = new List<Claim>();
            claimsAdd.ToList().ForEach(x => claims.Add(new Claim(x.Key, x.Value)));
            return claims.ToArray();
        }
    }
}
