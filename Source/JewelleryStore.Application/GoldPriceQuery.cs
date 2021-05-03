using JewelleryStore.Model;
using MediatR;

namespace JewelleryStore.Application
{
    public class GoldPriceQuery : GoldPriceMessage, IRequest<float>
    {
    }
}
