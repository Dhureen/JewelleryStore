using System;
using System.Threading;
using System.Threading.Tasks;
using JewelleryStore.Infrastructure;
using JewelleryStore.Model;
using MediatR;

namespace JewelleryStore.Application
{
    public class ComputeGoldPriceQueryHandler : IRequestHandler<ComputeGoldPriceQuery, GoldPriceMessage>
    {
        private IApplicationContext _applicationContext;
        private IUserDataAccess _userDataAccess;
        private IUserDomainFactory _userFactory;

        public ComputeGoldPriceQueryHandler(IApplicationContext applicationContext, IUserDataAccess userDataAccess, IUserDomainFactory userFactory)
        {
            _applicationContext = applicationContext;
            _userDataAccess = userDataAccess;
            _userFactory = userFactory;
        }

        public async Task<GoldPriceMessage> Handle(ComputeGoldPriceQuery query, CancellationToken cancellationToken)
        {
            var userMessage = await _userDataAccess.Details(_applicationContext.CurrentUserId);
            var user = await _userFactory.Get(userMessage);
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
