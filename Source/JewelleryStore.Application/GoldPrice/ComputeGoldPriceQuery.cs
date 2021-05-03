using JewelleryStore.Model;
using MediatR;

namespace JewelleryStore.Application
{
    public class ComputeGoldPriceQuery : ComputeGoldPriceMessage, IRequest<GoldPriceMessage>
    {
    }
}
