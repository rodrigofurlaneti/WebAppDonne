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
        [TestMethod][Ignore]
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

        [TestMethod][Ignore]
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

        [TestMethod][Ignore]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            int orderId = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderController orderController = new OrderController(mockLogger.Object);
            var getAll = orderController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listOrders = objResult.Value as List<OrderModel>;
            if(listOrders != null)
                orderId = listOrders[0].OrderId;

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

        [TestMethod][Ignore]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            int orderId = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace("GetByIdAsync")).Throws(new Exception());
            OrderController orderController = new OrderController(mockLogger.Object);
            var getAll = orderController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listOrders = objResult.Value as List<OrderModel>;
            if (listOrders != null)
                orderId = listOrders[0].OrderId;

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => orderController.Get(orderId));
        }

        //[TestMethod][Ignore]
        //public async Task Post_Sucesso()
        //{
        //    // Arrange
        //    Mock<ILogger> mockLogger = new Mock<ILogger>();
        //    OrderController orderController = new OrderController(mockLogger.Object);
        //    int orderId = Faker.RandomNumber.Next(0, 100);
        //    int commandId = Faker.RandomNumber.Next(0, 100);
        //    int productId = Faker.RandomNumber.Next(0, 100);
        //    string productName = Faker.Name.FullName();
        //    string salePrice = Faker.RandomNumber.Next(0, 1000).ToString();
        //    int amount = Faker.RandomNumber.Next(0, 100);
        //    string totalSalePrice = Faker.RandomNumber.Next(0, 1000).ToString();
        //    DateTime dateInsert = Faker.Finance.Maturity();
        //    DateTime dateUpdate = Faker.Finance.Maturity();
        //    int userId = Faker.RandomNumber.Next(0, 1000);
        //    string userName = Faker.Name.Last();
        //    List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
        //    OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, salePrice,
        //        amount, totalSalePrice, listDateTime, userId, userName);

        //    // Act
        //    await orderController.Post(orderModel);

        //    // Assert
        //    mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(2));
        //}

        //[TestMethod][Ignore]
        //public void Post_Erro()
        //{
        //    // Arrange
        //    Mock<ILogger> mockLogger = new Mock<ILogger>();
        //    mockLogger.Setup(x => x.Trace("InsertAsync")).Throws(new Exception());
        //    OrderController orderController = new OrderController(mockLogger.Object);
        //    int orderId = Faker.RandomNumber.Next(0, 100);
        //    int commandId = Faker.RandomNumber.Next(0, 100);
        //    int productId = Faker.RandomNumber.Next(0, 100);
        //    string productName = Faker.Name.FullName();
        //    string salePrice = Faker.RandomNumber.Next(0, 1000).ToString();
        //    int amount = Faker.RandomNumber.Next(0, 100);
        //    string totalSalePrice = Faker.RandomNumber.Next(0, 1000).ToString();
        //    DateTime dateInsert = Faker.Finance.Maturity();
        //    DateTime dateUpdate = Faker.Finance.Maturity();
        //    int userId = Faker.RandomNumber.Next(0, 1000);
        //    string userName = Faker.Name.Last();
        //    List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
        //    OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, salePrice,
        //        amount, totalSalePrice, listDateTime, userId, userName);

        //    // Act
        //    Assert.ThrowsExceptionAsync<ArgumentException>(() => orderController.Post(orderModel));

        //    // Assert
        //    mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(1));
        //    mockLogger.Verify(x => x.TraceException("InsertAsync"), Times.Exactly(1));
        //}

        //[TestMethod][Ignore]
        //public async Task Update_Sucesso()
        //{
        //    // Arrange
        //    int orderId = 0;
        //    Mock<ILogger> mockLogger = new Mock<ILogger>();
        //    OrderController orderController = new OrderController(mockLogger.Object);
        //    var getAll = orderController.Get();
        //    var objResult = (OkObjectResult)getAll.Result;
        //    var listOrders = objResult.Value as List<OrderModel>;
        //    if (listOrders != null)
        //        orderId = listOrders[0].OrderId;
        //    int commandId = Faker.RandomNumber.Next(0, 100);
        //    int productId = Faker.RandomNumber.Next(0, 100);
        //    string productName = Faker.Name.FullName();
        //    string salePrice = Faker.RandomNumber.Next(0, 1000).ToString();
        //    int amount = Faker.RandomNumber.Next(0, 100);
        //    string totalSalePrice = Faker.RandomNumber.Next(0, 1000).ToString();
        //    DateTime dateInsert = Faker.Finance.Maturity();
        //    DateTime dateUpdate = Faker.Finance.Maturity();
        //    int userId = Faker.RandomNumber.Next(0, 1000);
        //    string userName = Faker.Name.Last();
        //    List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
        //    OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, salePrice,
        //        amount, totalSalePrice, listDateTime, userId, userName);

        //    // Act
        //    await orderController.Update(orderModel);

        //    // Assert
        //    mockLogger.Verify(x => x.Trace("UpdateAsync"), Times.Exactly(2));
        //}

        //[TestMethod][Ignore]
        //public void Update_Erro()
        //{
        //    // Arrange
        //    int orderId = 0;
        //    DateTime dateInsert = DateTime.Now;
        //    Mock<ILogger> mockLogger = new Mock<ILogger>();
        //    mockLogger.Setup(x => x.Trace("UpdateAsync")).Throws(new Exception());
        //    OrderController orderController = new OrderController(mockLogger.Object);
        //    var getAll = orderController.Get();
        //    var objResult = (OkObjectResult)getAll.Result;
        //    var listOrders = objResult.Value as List<OrderModel>;
        //    if (listOrders != null)
        //    {
        //        orderId = listOrders[0].OrderId;
        //        dateInsert = listOrders[0].DateInsert;
        //    }
        //    int commandId = Faker.RandomNumber.Next(0, 100);
        //    int productId = Faker.RandomNumber.Next(0, 100);
        //    string productName = Faker.Name.FullName();
        //    string salePrice = Faker.RandomNumber.Next(0, 1000).ToString();
        //    int amount = Faker.RandomNumber.Next(0, 100);
        //    string totalSalePrice = Faker.RandomNumber.Next(0, 1000).ToString();
        //    DateTime dateUpdate = Faker.Finance.Maturity();
        //    int userId = Faker.RandomNumber.Next(0, 1000);
        //    string userName = Faker.Name.Last();
        //    List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
        //    OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, salePrice,
        //        amount, totalSalePrice, listDateTime, userId, userName);

        //    // Act
        //    Assert.ThrowsExceptionAsync<ArgumentException>(() => orderController.Update(orderModel));

        //    // Assert
        //    mockLogger.Verify(x => x.Trace("UpdateAsync"), Times.Exactly(1));
        //    mockLogger.Verify(x => x.TraceException("UpdateAsync"), Times.Exactly(1));
        //}

        [TestMethod][Ignore]
        public async Task Delete_Sucesso()
        {
            // Arrange
            int orderId = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderController orderController = new OrderController(mockLogger.Object);
            var getAll = orderController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listOrders = objResult.Value as List<OrderModel>;
            if (listOrders != null)
                orderId = listOrders[0].OrderId;

            // Act
            await orderController.Delete(orderId);

            // Assert
            mockLogger.Verify(x => x.Trace("DeleteAsync"), Times.Exactly(2));
        }

        [TestMethod][Ignore]
        public void Delete_Erro()
        {
            // Arrange
            int orderId = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("DeleteAsync")).Throws(new Exception());
            OrderController orderController = new OrderController(mockLogger.Object);
            var getAll = orderController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listOrders = objResult.Value as List<OrderModel>;
            if (listOrders != null)
                orderId = listOrders[0].OrderId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => orderController.Delete(orderId));

            // Assert
            mockLogger.Verify(x => x.Trace("DeleteAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("DeleteAsync"), Times.Exactly(1));
        }


    }
}
