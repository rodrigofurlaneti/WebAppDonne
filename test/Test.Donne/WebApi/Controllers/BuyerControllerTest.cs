using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
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
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("GetBuyerAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetAllBuyersAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetBuyersAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace("GetBuyerAsync")).Throws(new Exception());
            BuyerController buyerController = new BuyerController(mockLogger.Object);

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => buyerController.GetBuyersAsync());
        }

        [TestMethod]
        public async Task GetByStatus_Ativo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerController buyerController = new BuyerController(mockLogger.Object);

            // Act
            var result = await buyerController.OptionsAsync(1);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("OptionsAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByStatusAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByStatus_Ativo_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace("GetBuyerAsync")).Throws(new Exception());
            BuyerController buyerController = new BuyerController(mockLogger.Object);

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => buyerController.GetBuyersAsync());
        }

        [TestMethod]
        public async Task GetByStatus_Desativo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerController buyerController = new BuyerController(mockLogger.Object);

            // Act
            var result = await buyerController.OptionsAsync(0);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("OptionsAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByStatusAsync"), Times.Exactly(1));
        }
    }
}
