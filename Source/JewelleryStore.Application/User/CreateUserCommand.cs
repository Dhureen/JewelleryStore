using JewelleryStore.Model;
using MediatR;

namespace JewelleryStore.Application
{
    public class CreateUserCommand : UserMessage, IRequest<int>
    {
    }
}
