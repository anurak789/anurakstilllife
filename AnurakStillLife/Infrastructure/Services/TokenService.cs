using Core.Entities.Identity;
using Core.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        private readonly IKeyVaultManager keyVaultManager;
        private readonly SymmetricSecurityKey symmetricSecurityKey;

        public TokenService(IConfiguration configuration, IKeyVaultManager keyVaultManager)
        {
            this.configuration = configuration;
            this.keyVaultManager = keyVaultManager;
            this.symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Token:Key"]));
        }

        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.DisplayName)
            };

            var creds = new SigningCredentials(this.symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(3),
                SigningCredentials = creds,
                Issuer = this.configuration["Token:Issuer"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
