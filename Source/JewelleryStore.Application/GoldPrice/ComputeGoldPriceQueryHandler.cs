using System.Threading;
using System.Threading.Tasks;
using JewelleryStore.Model;
using MediatR;

namespace JewelleryStore.Application
{
    public class ComputeGoldPriceQueryHandler : IRequestHandler<ComputeGoldPriceQuery, GoldPriceMessage>
    {
        private IApplicationContext _applicationContext;
        private IUserDataAccess _userDataAccess;

        public ComputeGoldPriceQueryHandler(IApplicationContext applicationContext, IUserDataAccess userDataAccess)
        {
            _applicationContext = applicationContext;
            _userDataAccess = userDataAccess;
        }

        public async Task<GoldPriceMessage> Handle(ComputeGoldPriceQuery query, CancellationToken cancellationToken)
        {
            var user = await _userDataAccess.Details(_applicationContext.CurrentUserId);
            return new GoldPriceMessage() { Price = ComputeTotalPrice(query.RatePerGram, query.WeightInGrams, user.DiscountPercentage) };
        }

        private float ComputeTotalPrice(int ratePerGram, int weightInGrams, int discountPercentage)
        {
            var price = ratePerGram * weightInGrams;
            var discount = discountPercentage > 0 ? (float)discountPercentage / 100 * price : 0;
            return price - discount;
        }
    }
}
