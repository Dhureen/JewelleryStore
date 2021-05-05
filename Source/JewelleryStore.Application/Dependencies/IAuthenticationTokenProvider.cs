using JewelleryStore.Model;

namespace JewelleryStore.Application
{
    public interface IAuthenticationTokenProvider
    {
        public AuthenticationTokenMessage Token { get; }
    }
}
