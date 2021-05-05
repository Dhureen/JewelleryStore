using JewelleryStore.Model;

namespace JewelleryStore.Application
{
    public interface IAuthenticationTokenGenerator
    {
        AuthenticationTokenMessage GenerateToken(UserMessage user);
    }
}
