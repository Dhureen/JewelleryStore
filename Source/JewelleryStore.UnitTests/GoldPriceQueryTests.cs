using System.Threading.Tasks;
using JewelleryStore.Application;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace JewelleryStore.UnitTests
{
    [TestClass]
    public class GoldPriceQueryTests
    {
        private const int _normalUserDiscount = 0;
        private const int _privilegedUserDiscount = 2;
        private const int _userId = 1;

        [TestMethod]
        public async Task GetGoldPriceForNormalUser_Verify()
        {
            //Arrange
            var mediator = new Mock<IMediator>();
            var context = new Mock<IApplicationContext>();
            var dataAccess = new Mock<IUserDataAccess>();
            context.Setup(x => x.CurrentUserId).Returns(_userId);
            dataAccess.Setup(x => x.Details(_userId)).Returns(Task.FromResult(new Model.UserMessage() { DiscountPercentage = _normalUserDiscount }));
            var query = new ComputeGoldPriceQuery() { RatePerGram = 10, WeightInGrams = 10};
            var handler = new ComputeGoldPriceQueryHandler(context.Object, dataAccess.Object);

            //Act
            var goldPrice = await handler.Handle(query, new System.Threading.CancellationToken());

            //Assert
            context.Verify(x => x.CurrentUserId, Times.Once);
            dataAccess.Verify(x => x.Details(_userId), Times.Once);

            Assert.AreEqual(100, goldPrice.Price);
        }

        [TestMethod]
        public async Task GetGoldPriceForPrivilegedUser_Verify()
        {
            //Arrange
            var mediator = new Mock<IMediator>();
            var context = new Mock<IApplicationContext>();
            var dataAccess = new Mock<IUserDataAccess>();
            context.Setup(x => x.CurrentUserId).Returns(_userId);
            dataAccess.Setup(x => x.Details(_userId)).Returns(Task.FromResult(new Model.UserMessage() { DiscountPercentage = _privilegedUserDiscount }));
            var query = new ComputeGoldPriceQuery() { RatePerGram = 10, WeightInGrams = 10 };
            var handler = new ComputeGoldPriceQueryHandler(context.Object, dataAccess.Object);

            //Act
            var goldPrice = await handler.Handle(query, new System.Threading.CancellationToken());

            //Assert
            context.Verify(x => x.CurrentUserId, Times.Once);
            dataAccess.Verify(x => x.Details(_userId), Times.Once);
            Assert.AreEqual(98, goldPrice.Price);
        }
    }
}
