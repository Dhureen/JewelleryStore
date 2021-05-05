using System;
using System.Security.Claims;
using JewelleryStore.Application;
using JewelleryStore.Model;
using Microsoft.AspNetCore.Http;

namespace JewelleryStore.Api
{
    public class AuthenticationTokenProvider : IAuthenticationTokenProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationTokenProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public AuthenticationTokenMessage Token => GetToken();

        private AuthenticationTokenMessage GetToken()
        {
            var token = ((ClaimsIdentity)_httpContextAccessor.HttpContext?.User.Identity).BootstrapContext;
            var user = _httpContextAccessor.HttpContext.User; 
            return new AuthenticationTokenMessage() {
                Id = Convert.ToInt32(user.FindFirst(ClaimTypes.NameIdentifier).Value),
                Name = user.FindFirst(ClaimTypes.Name).Value,
                Token = token.ToString()
            };
        }
    }
}
