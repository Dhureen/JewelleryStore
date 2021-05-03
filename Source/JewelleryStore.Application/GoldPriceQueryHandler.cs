using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace JewelleryStore.Application
{
    public class GoldPriceQueryHandler : IRequestHandler<GoldPriceQuery, float>
    {
        private IUserDataAccess _userDataAccess;
        private IUserDomainFactory _userFactory;

        public GoldPriceQueryHandler(IUserDataAccess userDataAccess, IUserDomainFactory userFactory)
        {
            _userDataAccess = userDataAccess;
            _userFactory = userFactory;
        }

        public async Task<float> Handle(GoldPriceQuery query, CancellationToken cancellationToken)
        {
            var userMessage = await _userDataAccess.Details(2);
            var user = await _userFactory.Get(userMessage);
            return ComputeTotalPrice(query.RatePerGram, query.WeightInGrams, user.DiscountPercentage);
        }

        private float ComputeTotalPrice(int ratePerGram, int weightInGrams, int discountPercentage)
        {
            var price = ratePerGram * weightInGrams;
            var discount = discountPercentage > 0 ? (float)discountPercentage / 100 * price : 0;
            return price - discount;
        }
    }
}
