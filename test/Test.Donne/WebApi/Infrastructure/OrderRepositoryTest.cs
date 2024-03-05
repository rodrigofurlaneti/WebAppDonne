using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure.Order;
using WebApi.Donne.Infrastructure.Product;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Infrastructure.OrderRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > OrderRepository")]
    public class OrderRepositoryTest
    {
        [TestMethod]
        public void GetAllOrders_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);

            // Act
            var result = orderRepository.GetAllOrders();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Order_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllOrders_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            // Setup
            mockLogger.Setup(x => x.Trace("Order_GetAll")).Throws(new ArgumentNullException());
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);

            // Act
            Assert.ThrowsException<ArgumentNullException>(() => orderRepository.GetAllOrders());

            // Assert                                  Order_GetAllAsync
            mockLogger.Verify(x => x.TraceException("Order_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetAllOrdersAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);

            // Act
            var result = await orderRepository.GetAllOrdersAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Order_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllOrdersAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            // Setup
            mockLogger.Setup(x => x.Trace("Order_GetAllAsync")).Throws(new ArgumentNullException());
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => orderRepository.GetAllOrdersAsync());

            // Assert                                  Order_GetAllAsync
            //mockLogger.Verify(x => x.TraceException("Order_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Sucesso()
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
            mockLogger.Verify(x => x.Trace("Order_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Order_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Order_GetById")).Throws(new ArgumentNullException());
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            var getAll = orderRepository.GetAllOrders();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].OrderId;

            // Act
            Assert.ThrowsException<ArgumentNullException>(() => orderRepository.GetById(idUltimo));

            // Assert
            mockLogger.Verify(x => x.Trace("Order_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Order_GetById"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("Order_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            var getAll = await orderRepository.GetAllOrdersAsync();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].OrderId;

            // Act
            var result = await orderRepository.GetByIdAsync(idUltimo);

            // Assert
            mockLogger.Verify(x => x.Trace("Order_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Order_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Order_GetByIdAsync")).Throws(new ArgumentNullException());
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            var getAll = await orderRepository.GetAllOrdersAsync();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].OrderId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => orderRepository.GetByIdAsync(idUltimo));

            // Assert
            mockLogger.Verify(x => x.Trace("Order_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Order_GetByIdAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("Order_GetByIdAsync"), Times.Exactly(1));
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
            string buyerName = Faker.Name.FullName();
            string salePrice = Faker.RandomNumber.Next(0, 1000).ToString();
            int amount = Faker.RandomNumber.Next(0, 100);
            string totalSalePrice = Faker.RandomNumber.Next(0, 1000).ToString();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };

            // Act
            OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, buyerName, salePrice,
                amount, totalSalePrice, listDateTime, userId, userName);

            // Act
            orderRepository.Insert(orderModel);

            //Assert
            mockLogger.Verify(x => x.Trace("Order_Insert"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task InsertAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            ProductRepository productRepository = new ProductRepository(mockLogger.Object);
            var resultProduct = productRepository.GetAllProducts();
            var product = resultProduct.FirstOrDefault();
            int orderId = Faker.RandomNumber.Next(0, 100);
            int commandId = Faker.RandomNumber.Next(0, 100);
            int productId = product.ProductId;
            string productName = product.ProductName;
            string buyerName = Faker.Name.FullName();
            string salePrice = product.SalePrice;
            int amount = Faker.RandomNumber.Next(0, 100);
            string totalSalePrice = Faker.RandomNumber.Next(0, 1000).ToString();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, buyerName, salePrice,
                amount, totalSalePrice, listDateTime, userId, userName);

            // Act
            await orderRepository.InsertAsync(orderModel);

            //Assert
            mockLogger.Verify(x => x.Trace("Product_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Order_InsertAsync"), Times.Exactly(2));
            mockLogger.Verify(x => x.Trace("Product_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task InsertAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Order_InsertAsync")).Throws(new ArgumentNullException());
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            ProductRepository productRepository = new ProductRepository(mockLogger.Object);
            var resultProduct = await productRepository.GetAllProductsAsync();
            var product = resultProduct.FirstOrDefault();
            int orderId = Faker.RandomNumber.Next(0, 100);
            int commandId = Faker.RandomNumber.Next(0, 100);
            int productId = product.ProductId;
            string productName = product.ProductName;
            string buyerName = Faker.Name.FullName();
            string salePrice = product.SalePrice;
            int amount = Faker.RandomNumber.Next(0, 100);
            string totalSalePrice = Faker.RandomNumber.Next(0, 1000).ToString();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, buyerName, salePrice,
                amount, totalSalePrice, listDateTime, userId, userName);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => orderRepository.InsertAsync(orderModel));

            // Assert
            mockLogger.Verify(x => x.TraceException("Order_InsertAsync"), Times.Exactly(1));
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
            string buyerName = Faker.Name.FullName();
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
            OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, buyerName, salePrice,
                amount, totalSalePrice, listDateTime, userId, userName);

            // Act
            orderRepository.Update(orderModel);

            //Assert
            mockLogger.Verify(x => x.Trace("Order_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Order_Update"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Order_Update")).Throws(new ArgumentNullException());
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            var getAll = orderRepository.GetAllOrders();
            int orderId = getAll.ToList()[getAll.Count() - 1].OrderId;
            int commandId = Faker.RandomNumber.Next(0, 100);
            int productId = Faker.RandomNumber.Next(0, 100);
            string buyerName = Faker.Name.FullName();
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
            OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, buyerName, salePrice,
                amount, totalSalePrice, listDateTime, userId, userName);

            // Act
            Assert.ThrowsException<ArgumentNullException>(() => orderRepository.Update(orderModel));

            // Assert
            mockLogger.Verify(x => x.TraceException("Order_Update"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            var getAll = await orderRepository.GetAllOrdersAsync();
            int orderId = getAll.ToList()[getAll.Count() - 1].OrderId;
            int commandId = Faker.RandomNumber.Next(0, 100);
            int productId = Faker.RandomNumber.Next(0, 100);
            string buyerName = Faker.Name.FullName();
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
            OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, buyerName, salePrice,
                amount, totalSalePrice, listDateTime, userId, userName);

            // Act
            await orderRepository.UpdateAsync(orderModel);

            //Assert
            mockLogger.Verify(x => x.Trace("Order_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Order_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Order_UpdateAsync")).Throws(new ArgumentNullException());
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            var getAll = await orderRepository.GetAllOrdersAsync();
            int orderId = getAll.ToList()[getAll.Count() - 1].OrderId;
            int commandId = Faker.RandomNumber.Next(0, 100);
            int productId = Faker.RandomNumber.Next(0, 100);
            string buyerName = Faker.Name.FullName();
            string productName = Faker.Name.FullName();
            string salePrice = Faker.RandomNumber.Next(0, 1000).ToString();
            int amount = Faker.RandomNumber.Next(0, 100);
            string totalSalePrice = Faker.RandomNumber.Next(0, 1000).ToString();
            DateTime dateInsert = getAll.ToList()[getAll.Count() - 1].DateInsert;
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, buyerName, salePrice,
                amount, totalSalePrice, listDateTime, userId, userName);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => orderRepository.UpdateAsync(orderModel));

            // Assert
            mockLogger.Verify(x => x.Trace("Order_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Order_UpdateAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("Order_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            int orderId = Faker.RandomNumber.Next(0, 100);
            int commandId = Faker.RandomNumber.Next(0, 100);
            int productId = Faker.RandomNumber.Next(0, 100);
            string productName = Faker.Name.FullName();
            string buyerName = Faker.Name.FullName();
            string salePrice = Faker.RandomNumber.Next(0, 1000).ToString();
            int amount = Faker.RandomNumber.Next(0, 100);
            string totalSalePrice = Faker.RandomNumber.Next(0, 1000).ToString();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, buyerName, salePrice,
                amount, totalSalePrice, listDateTime, userId, userName);
            orderRepository.Insert(orderModel);
            var getAll = orderRepository.GetAllOrders();
            int orderIdRet = getAll.ToList()[getAll.Count() - 1].OrderId;

            // Act
            orderRepository.Delete(orderId);

            //Assert
            mockLogger.Verify(x => x.Trace("Order_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Order_Delete"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Order_Delete")).Throws(new ArgumentNullException());
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            var getAll = orderRepository.GetAllOrders();
            int orderId = getAll.ToList()[getAll.Count() - 1].OrderId;

            // Act
            Assert.ThrowsException<ArgumentNullException>(() => orderRepository.Delete(orderId));

            // Assert
            mockLogger.Verify(x => x.TraceException("Order_Delete"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task DeleteAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            ProductRepository productRepository = new ProductRepository(mockLogger.Object);
            var resultProduct = await productRepository.GetAllProductsAsync();
            var product = resultProduct.FirstOrDefault();
            int orderId = Faker.RandomNumber.Next(0, 100);
            int commandId = Faker.RandomNumber.Next(0, 100);
            int productId = product.ProductId;
            string productName = product.ProductName;
            string buyerName = Faker.Name.FullName();
            string salePrice = product.SalePrice;
            int amount = Faker.RandomNumber.Next(0, 100);
            string totalSalePrice = Faker.RandomNumber.Next(0, 1000).ToString();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, buyerName, salePrice,
                amount, totalSalePrice, listDateTime, userId, userName);
            await orderRepository.InsertAsync(orderModel);
            var getAll = orderRepository.GetAllOrders();
            int orderIdRet = getAll.ToList()[getAll.Count() - 1].OrderId;

            // Act
            await orderRepository.DeleteAsync(orderIdRet);

            //Assert
            mockLogger.Verify(x => x.Trace("Product_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Order_InsertAsync"), Times.Exactly(2));
            mockLogger.Verify(x => x.Trace("GetByIdAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Product_UpdateAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Order_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Order_DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void DeleteAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Order_DeleteAsync")).Throws(new Exception());
            OrderRepository orderRepository = new OrderRepository(mockLogger.Object);
            ProductRepository productRepository = new ProductRepository(mockLogger.Object);
            var resultProduct = productRepository.GetAllProducts();
            var product = resultProduct.FirstOrDefault();
            int orderId = Faker.RandomNumber.Next(0, 100);
            int commandId = Faker.RandomNumber.Next(0, 100);
            int productId = product.ProductId;
            string productName = product.ProductName;
            string buyerName = Faker.Name.FullName();
            string salePrice = product.SalePrice;
            int amount = Faker.RandomNumber.Next(0, 100);
            string totalSalePrice = Faker.RandomNumber.Next(0, 1000).ToString();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, buyerName, salePrice,
                amount, totalSalePrice, listDateTime, userId, userName);
            orderRepository.Insert(orderModel);
            var getAll = orderRepository.GetAllOrders();
            int orderIdRet = getAll.ToList()[getAll.Count() - 1].OrderId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => orderRepository.DeleteAsync(orderIdRet));

            //Assert
            mockLogger.Verify(x => x.TraceException("Order_DeleteAsync"), Times.Exactly(1));
        }
    }
}
