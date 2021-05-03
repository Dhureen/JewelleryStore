using JewelleryStore.Model;
using MediatR;

namespace JewelleryStore.Application
{
    public class UpdateUserCommand : UserMessage, IRequest<int>
    {
    }
}
