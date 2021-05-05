using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JewelleryStore.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JewelleryStore.Application
{
    public class AuthenticationTokenGenerator : IAuthenticationTokenGenerator
    {
        private AuthSettings _appSettings;

        public AuthenticationTokenGenerator(IOptions<AuthSettings> options)
        {
            _appSettings = options.Value;
        }

        public AuthenticationTokenMessage GenerateToken(UserMessage user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.NameIdentifier,Convert.ToString(user.Id)),
                    new Claim(ClaimTypes.Name, user.Name)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationTokenMessage() { Token = tokenHandler.WriteToken(token) };
        }
    }
}
