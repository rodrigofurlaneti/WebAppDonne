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
        [TestMethod][Ignore]
        public void GetAllOrders_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);

            // Act
            var result = orderRepository.GetAllOrders();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllOrders"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public void GetAllOrders_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);

            // Act
            var result = orderRepository.GetAllOrders();

            // Assert
            Assert.IsTrue(result.Any());
            mockLogger.Verify(x => x.Trace("GetAllOrders"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public async Task GetAllOrdersAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);

            // Act
            var result = await orderRepository.GetAllOrdersAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllOrdersAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public void GetAllOrdersAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            // Setup
            mockLogger.Setup(x => x.Trace("GetAllOrdersAsync")).Throws(new Exception());
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => orderRepository.GetAllOrdersAsync());
            mockLogger.Verify(x => x.TraceException("GetAllOrdersAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
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
            mockLogger.Verify(x => x.Trace("GetAllOrders"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetById"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
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
            mockLogger.Verify(x => x.Trace("Insert"), Times.Exactly(1));
        }

        //[TestMethod][Ignore]
        //public async Task InsertAsync_Sucesso()
        //{
        //    // Arrange
        //    Mock<ILogger> mockLogger = new Mock<ILogger>();
        //    OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
        //    int orderId = Faker.RandomNumber.Next(0, 100);
        //    int commandId = Faker.RandomNumber.Next(0, 100);
        //    string productName = Faker.Name.FullName();
        //    string salePrice = Faker.RandomNumber.Next(0, 1000).ToString();
        //    int amount = Faker.RandomNumber.Next(0, 100);
        //    string totalSalePrice = Faker.RandomNumber.Next(0, 1000).ToString();
        //    DateTime dateInsert = Faker.Finance.Maturity();
        //    DateTime dateUpdate = Faker.Finance.Maturity();
        //    int userId = Faker.RandomNumber.Next(0, 1000);
        //    string userName = Faker.Name.Last();
        //    List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };

        //    // Act
        //    OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, salePrice,
        //        amount, totalSalePrice, listDateTime, userId, userName);

        //    // Act
        //    await orderRepository.InsertAsync(orderModel);

        //    //Assert
        //    mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(1));
        //}

        [TestMethod][Ignore]
        public void InsertAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("InsertAsync")).Throws(new Exception());
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
            OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, salePrice,
                amount, totalSalePrice, listDateTime, userId, userName);

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => orderRepository.InsertAsync(orderModel));
            mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
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
            mockLogger.Verify(x => x.Trace("GetAllOrders"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Update"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public async Task UpdateAsync_Sucesso()
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
            OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, salePrice,
                amount, totalSalePrice, listDateTime, userId, userName);

            // Act
            await orderRepository.UpdateAsync(orderModel);

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllOrders"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public void UpdateAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("UpdateAsync")).Throws(new Exception());
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
            OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, salePrice,
                amount, totalSalePrice, listDateTime, userId, userName);

            // Act
            //Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => orderRepository.UpdateAsync(orderModel));
            mockLogger.Verify(x => x.TraceException("UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
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
            mockLogger.Verify(x => x.Trace("GetAllOrders"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Delete"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public async Task DeleteAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            var getAll = orderRepository.GetAllOrders();
            int orderId = getAll.ToList()[getAll.Count() - 1].OrderId;

            // Act
            await orderRepository.DeleteAsync(orderId);

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllOrders"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public void DeleteAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("DeleteAsync")).Throws(new Exception());
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            var getAll = orderRepository.GetAllOrders();
            int orderId = getAll.ToList()[getAll.Count() - 1].OrderId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => orderRepository.DeleteAsync(orderId));
            mockLogger.Verify(x => x.TraceException("DeleteAsync"), Times.Exactly(1));
        }
    }
}
