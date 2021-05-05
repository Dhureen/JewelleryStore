using JewelleryStore.Model;
using MediatR;

namespace JewelleryStore.Application
{
    public class AuthenticateQuery: UserMessage, IRequest<AuthenticationTokenMessage>
    {       
    }
}
