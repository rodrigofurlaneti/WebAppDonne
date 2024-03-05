using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure.Product;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Infrastructure.ProductRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > ProductRepository")]
    public class ProductRepositoryTest
    {
        [TestMethod]
        public void GetAll_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProductRepository productRepository = new ProductRepository(mockLogger.Object);

            // Act
            var result = productRepository.GetAll();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Product_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAll_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProductRepository productRepository = new ProductRepository(mockLogger.Object);

            // Act
            var result = productRepository.GetAll();

            // Assert
            Assert.IsTrue(result.Any());
            mockLogger.Verify(x => x.Trace("Product_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetAllAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProductRepository productRepository = new ProductRepository(mockLogger.Object);

            // Act
            var result = await productRepository.GetAllAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Product_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetAllAsync")).Throws(new Exception());
            ProductRepository productRepository = new ProductRepository(mockLogger.Object);

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => productRepository.GetAllAsync());
            mockLogger.Verify(x => x.Trace("GetAllAsync"), Times.Exactly(0));
        }

        [TestMethod]
        public void GetById_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProductRepository productRepository = new ProductRepository(mockLogger.Object);
            var getAll = productRepository.GetAll();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].ProductId;

            // Act
            var result = productRepository.GetById(idUltimo);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Product_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProductRepository productRepository = new ProductRepository(mockLogger.Object);
            var getAll = productRepository.GetAll();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].ProductId;

            // Act
            var result = productRepository.GetById(idUltimo);

            // Assert
            Assert.IsTrue(result.SalePrice != string.Empty);
            Assert.IsTrue(result.CategoryName != string.Empty);
            Assert.IsTrue(result.CategoryId != 0);
            Assert.IsTrue(result.UserId != 0);
            mockLogger.Verify(x => x.Trace("Product_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public void Insert_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProductRepository productRepository = new ProductRepository(mockLogger.Object);
            int productId = Faker.RandomNumber.Next(0, 1000);
            string productName = Faker.Name.First();
            int categoryId = Faker.RandomNumber.Next(0, 1000);
            string categoryName = Faker.Name.First();
            string costPrice = Faker.RandomNumber.Next(0, 100).ToString();
            string salePrice = Faker.RandomNumber.Next(0, 100).ToString();
            int quantityStock = Faker.RandomNumber.Next(0, 100);
            int minimumStockQuantity = Faker.RandomNumber.Next(0, 100);
            string totalValueCostOfInventory = Faker.RandomNumber.Next(0, 100).ToString();
            string totalValueSaleStock = Faker.RandomNumber.Next(0, 100).ToString();
            int needToPrint = 1;
            int status = 1;
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = Faker.Finance.Maturity();
            DateTime dateInsert = Faker.Finance.Maturity();
            int quantityToBuy = Faker.RandomNumber.Next(0, 100);
            string totalValueOfLastPurchase = Faker.RandomNumber.Next(0, 100).ToString();
            List<string> listString = new List<string>() { productName, categoryName, costPrice, salePrice, totalValueCostOfInventory, totalValueSaleStock, userName, totalValueOfLastPurchase };
            List<int> listInts = new List<int>() { productId, categoryId, quantityStock, minimumStockQuantity, userId, quantityToBuy };
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            ProductModel productModel = new ProductModel(listInts, listString, status, listDateTime, needToPrint);


            // Act
            productRepository.Insert(productModel);

            // Assert
            mockLogger.Verify(x => x.Trace("Product_Insert"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProductRepository productRepository = new ProductRepository(mockLogger.Object);
            var getAll = productRepository.GetAll();
            int productId = getAll.ToList()[getAll.Count() - 1].ProductId;
            string productName = Faker.Name.First();
            int categoryId = Faker.RandomNumber.Next(0, 1000);
            string categoryName = Faker.Name.First();
            string costPrice = Faker.RandomNumber.Next(0, 100).ToString();
            string salePrice = Faker.RandomNumber.Next(0, 100).ToString();
            int quantityStock = Faker.RandomNumber.Next(0, 100);
            int minimumStockQuantity = Faker.RandomNumber.Next(0, 100);
            string totalValueCostOfInventory = Faker.RandomNumber.Next(0, 100).ToString();
            string totalValueSaleStock = Faker.RandomNumber.Next(0, 100).ToString();
            int needToPrint = 1;
            int status = 1;
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = Faker.Finance.Maturity();
            DateTime dateInsert = Faker.Finance.Maturity();
            int quantityToBuy = Faker.RandomNumber.Next(0, 100);
            string totalValueOfLastPurchase = Faker.RandomNumber.Next(0, 100).ToString();
            List<string> listString = new List<string>() { productName, categoryName, costPrice, salePrice, totalValueCostOfInventory, totalValueSaleStock, userName, totalValueOfLastPurchase };
            List<int> listInts = new List<int>() { productId, categoryId, quantityStock, minimumStockQuantity, userId , quantityToBuy};
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            ProductModel productModel = new ProductModel(listInts, listString, status, listDateTime, needToPrint);

            // Act
            productRepository.Update(productModel);

            // Assert
            mockLogger.Verify(x => x.Trace("Product_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Product_Update"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProductRepository productRepository = new ProductRepository(mockLogger.Object);
            var getAll = productRepository.GetAll();
            int productId = getAll.ToList()[getAll.Count() - 1].ProductId;

            // Act
            productRepository.Delete(productId);

            // Assert
            mockLogger.Verify(x => x.Trace("Product_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Product_Delete"), Times.Exactly(1));
        }
    }
}
