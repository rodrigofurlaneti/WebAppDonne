using Domain.Donne;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Controllers
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
            Assert.ThrowsExceptionAsync<ArgumentException>(() => stockInventoryController.Get());

            // Assert
            mockLogger.Verify(x => x.TraceException("GetStockInventoryAsync"), Times.Exactly(1));
        }
    }
}
