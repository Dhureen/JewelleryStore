using JewelleryStore.Model;
using MediatR;

namespace JewelleryStore.Application
{
    public class UserDetailsQuery: UserMessage, IRequest<UserMessage>
    {
    }
}
