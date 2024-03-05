using Domain.Donne;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.Order;
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
            var result = await orderController.GetOrder();
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("Order_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetOrdersAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetOrderAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetOrdersAsync")).Throws(new ArgumentNullException());
            OrderController orderController = new OrderController(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => orderController.GetOrder());

            // Assert
            mockLogger.Verify(x => x.TraceException("GetAllOrdersAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderController orderController = new OrderController(mockLogger.Object);
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            var getAll = orderRepository.GetAll();
            int orderId = getAll.First().OrderId;

            // Act
            var result = await orderController.Get(orderId);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("Order_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Order_GetByIdAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetByIdAsync")).Throws(new Exception());
            OrderController orderController = new OrderController(mockLogger.Object);
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            var getAll = orderRepository.GetAll();
            int orderId = getAll.First().OrderId;

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => orderController.Get(orderId));
        }

        //[TestMethod]
        //public async Task Post_Sucesso()
        //{
        //    // Arrange
        //    Mock<ILogger> mockLogger = new Mock<ILogger>();
        //    OrderController orderController = new OrderController(mockLogger.Object);
        //    int orderId = Faker.RandomNumber.Next(0, 100);
        //    int commandId = Faker.RandomNumber.Next(0, 100);
        //    int productId = Faker.RandomNumber.Next(0, 100);
        //    string productName = Faker.Name.FullName();
        //    string buyerName = Faker.Name.First();
        //    string salePrice = Faker.RandomNumber.Next(0, 1000).ToString();
        //    int amount = Faker.RandomNumber.Next(0, 100);
        //    string totalSalePrice = Faker.RandomNumber.Next(0, 1000).ToString();
        //    DateTime dateInsert = Faker.Finance.Maturity();
        //    DateTime dateUpdate = Faker.Finance.Maturity();
        //    int userId = Faker.RandomNumber.Next(0, 1000);
        //    string userName = Faker.Name.Last();
        //    List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
        //    OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, buyerName, salePrice, amount, totalSalePrice,
        //        listDateTime, userId, userName);

        //    // Act
        //    await orderController.Post(orderModel);

        //    // Assert
        //    mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(1));
        //    mockLogger.Verify(x => x.Trace("Order_InsertAsync"), Times.Exactly(2));
        //    mockLogger.Verify(x => x.Trace("GetByIdAsync"), Times.Exactly(1));
        //    mockLogger.Verify(x => x.Trace("Product_UpdateAsync"), Times.Exactly(1));
        //}

        [TestMethod]
        public void Post_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("InsertAsync")).Throws(new Exception());
            OrderController orderController = new OrderController(mockLogger.Object);
            int orderId = Faker.RandomNumber.Next(0, 100);
            int commandId = Faker.RandomNumber.Next(0, 100);
            string buyerName = Faker.Name.First();
            int productId = Faker.RandomNumber.Next(0, 100);
            string productName = Faker.Name.FullName();
            string salePrice = Faker.RandomNumber.Next(0, 1000).ToString();
            int amount = Faker.RandomNumber.Next(0, 100);
            string totalSalePrice = Faker.RandomNumber.Next(0, 1000).ToString();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, buyerName, salePrice, amount, totalSalePrice,
                listDateTime, userId, userName);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => orderController.Post(orderModel));

            // Assert
            mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderController orderController = new OrderController(mockLogger.Object);
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            var getAll = orderRepository.GetAll();
            int orderId = getAll.First().OrderId;
            int commandId = Faker.RandomNumber.Next(0, 100);
            int productId = Faker.RandomNumber.Next(0, 100);
            string productName = Faker.Name.FullName();
            string buyerName = Faker.Name.First();
            string salePrice = Faker.RandomNumber.Next(0, 1000).ToString();
            int amount = Faker.RandomNumber.Next(0, 100);
            string totalSalePrice = Faker.RandomNumber.Next(0, 1000).ToString();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, buyerName, salePrice, amount, totalSalePrice,
                listDateTime, userId, userName);

            // Act
            await orderController.Update(orderModel);

            // Assert
            mockLogger.Verify(x => x.Trace("Order_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("UpdateAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Order_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Erro()
        {
            // Arrange
            DateTime dateInsert = DateTime.Now;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("UpdateAsync")).Throws(new Exception());
            OrderController orderController = new OrderController(mockLogger.Object);
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            var getAll = orderRepository.GetAll();
            int orderId = getAll.First().OrderId;
            int commandId = Faker.RandomNumber.Next(0, 100);
            int productId = Faker.RandomNumber.Next(0, 100);
            string buyerName = Faker.Name.First();
            string productName = Faker.Name.FullName();
            string salePrice = Faker.RandomNumber.Next(0, 1000).ToString();
            int amount = Faker.RandomNumber.Next(0, 100);
            string totalSalePrice = Faker.RandomNumber.Next(0, 1000).ToString();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, buyerName, salePrice, amount, totalSalePrice,
                listDateTime, userId, userName);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => orderController.Update(orderModel));

            // Assert
            mockLogger.Verify(x => x.Trace("UpdateAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Delete_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderController orderController = new OrderController(mockLogger.Object);
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            var getAll = orderRepository.GetAll();
            int orderId = getAll.First().OrderId;

            // Act
            await orderController.Delete(orderId);

            // Assert
            mockLogger.Verify(x => x.Trace("Order_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("DeleteAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Order_DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("DeleteAsync")).Throws(new Exception());
            OrderController orderController = new OrderController(mockLogger.Object);
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            var getAll = orderRepository.GetAll();
            int orderId = getAll.First().OrderId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => orderController.Delete(orderId));

            // Assert
            mockLogger.Verify(x => x.Trace("DeleteAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("DeleteAsync"), Times.Exactly(1));
        }


    }
}
