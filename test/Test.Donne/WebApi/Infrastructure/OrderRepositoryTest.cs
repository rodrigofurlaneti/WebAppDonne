using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Infrastructure.OrderRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > OrderRepository")]
    public class OrderRepositoryTest
    {
        [TestMethod]
        public void GetAllOrders_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);

            // Act
            var result = orderRepository.GetAllOrders();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAllOrders_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);

            // Act
            var result = orderRepository.GetAllOrders();

            // Assert
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetById_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            var getAll = orderRepository.GetAllOrders();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].OrderId;

            // Act
            var result = orderRepository.GetById(idUltimo);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetById_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            var getAll = orderRepository.GetAllOrders();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].OrderId;

            // Act
            var result = orderRepository.GetById(idUltimo);

            // Assert
            Assert.IsTrue(result.UserName != string.Empty);
            Assert.IsTrue(result.UserId != 0);
            Assert.IsTrue(result.Amount != 0);
            Assert.IsTrue(result.CommandId != 0);
            Assert.AreEqual(idUltimo, result.OrderId);
        }

        [TestMethod]
        public void Insert_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            int orderId = Faker.RandomNumber.Next(0, 100);
            int commandId = Faker.RandomNumber.Next(0, 100);
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

            // Act
            OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, salePrice,
                amount, totalSalePrice, listDateTime, userId, userName);

            // Act
            orderRepository.Insert(orderModel);

            //Assert
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            var getAll = orderRepository.GetAllOrders();
            int orderId = getAll.ToList()[getAll.Count() - 1].OrderId;
            int commandId = Faker.RandomNumber.Next(0, 100);
            int productId = Faker.RandomNumber.Next(0, 100);
            string productName = Faker.Name.FullName();
            string salePrice = Faker.RandomNumber.Next(0, 1000).ToString();
            int amount = Faker.RandomNumber.Next(0, 100);
            string totalSalePrice = Faker.RandomNumber.Next(0, 1000).ToString();
            DateTime dateInsert = getAll.ToList()[getAll.Count() - 1].DateInsert;
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };

            // Act
            OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, salePrice,
                amount, totalSalePrice, listDateTime, userId, userName);

            // Act
            orderRepository.Update(orderModel);

            //Assert
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(2));
        }

        [TestMethod]
        public void Delete_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            var getAll = orderRepository.GetAllOrders();
            int orderId = getAll.ToList()[getAll.Count() - 1].OrderId;

            // Act
            orderRepository.Delete(orderId);

            //Assert
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
