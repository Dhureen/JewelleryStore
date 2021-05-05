using JewelleryStore.Application;

namespace JewelleryStore.Api
{
    public class ApplicationContext: IApplicationContext
    {
        private readonly IAuthenticationTokenProvider _authenticationTokenProvider;
        public ApplicationContext(IAuthenticationTokenProvider authenticationTokenProvider)
        {
            _authenticationTokenProvider = authenticationTokenProvider;
        }

        public int CurrentUserId => _authenticationTokenProvider.Token.Id;        
    }
}
