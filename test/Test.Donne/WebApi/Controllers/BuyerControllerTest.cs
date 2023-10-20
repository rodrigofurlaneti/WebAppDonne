using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Controllers.BuyerControllerTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Controllers > BuyerController")]
    public class BuyerControllerTest
    {
        [TestMethod]
        public async Task GetBuyersAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerController buyerController = new BuyerController(mockLogger.Object);

            // Act
            var result = await buyerController.GetBuyersAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetBuyerAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetAllBuyersAsync"), Times.Exactly(1));
        }
    }
}
