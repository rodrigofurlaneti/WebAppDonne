using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Controllers.StockInventoryControllerTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Controllers > StockInventoryController")]
    public class StockInventoryControllerTest
    {
        [TestMethod]
        public void GetStockInventory_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();


            //Setup
            mockLogger.Setup(x => x.Trace("GetStockInventoryAsync")).Throws(new Exception());
            StockInventoryController stockInventoryController = new StockInventoryController(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => stockInventoryController.GetStockInventory());

            // Assert
            mockLogger.Verify(x => x.TraceException("GetStockInventoryAsync"), Times.Exactly(1));
        }
    }
}
