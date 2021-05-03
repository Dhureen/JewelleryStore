using JewelleryStore.Model;
using MediatR;

namespace JewelleryStore.Application
{
    public class DeleteUserCommand : UserMessage, IRequest
    {
    }
}
