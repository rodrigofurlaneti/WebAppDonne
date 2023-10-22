using Domain.Donne;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Controllers.OrderControllerTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Controllers > OrderController")]
    public class OrderControllerTest
    {
        [TestMethod]
        public async Task GetOrderAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderController orderController = new OrderController(mockLogger.Object);

            // Act
            var result = await orderController.Get();
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("GetOrdersAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetAllOrdersAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetOrderAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetOrdersAsync")).Throws(new Exception());
            OrderController orderController = new OrderController(mockLogger.Object);

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => orderController.Get());
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderController orderController = new OrderController(mockLogger.Object);
            var getAll = orderController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listOrders = objResult.Value as List<OrderModel>;
            int orderId = listOrders[0].OrderId;

            // Act
            var result = await orderController.Get(orderId);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("GetByIdAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace("GetByIdAsync")).Throws(new Exception());
            OrderController orderController = new OrderController(mockLogger.Object);
            var getAll = orderController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listOrders = objResult.Value as List<OrderModel>;
            int orderId = listOrders[0].OrderId;

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => orderController.Get(orderId));
        }


    }
}
