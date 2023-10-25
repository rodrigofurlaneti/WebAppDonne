using Domain.Donne;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Controllers.ProductControllerTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Controllers > ProductController")]
    public class ProductControllerTest
    {
        [TestMethod]
        public async Task GetProductAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProductController productController = new ProductController(mockLogger.Object);

            // Act
            var result = await productController.Get();
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("GetProductAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetAllProductsAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetProductAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace("GetProductAsync")).Throws(new Exception());
            ProductController productController = new ProductController(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => productController.Get());

            // Assert
            mockLogger.Verify(x => x.TraceException("GetProductAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            int idProduct = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProductController productController = new ProductController(mockLogger.Object);
            var getAll = productController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listProduct = objResult.Value as List<ProductModel>;
            if(listProduct != null)
                idProduct = listProduct[0].ProductId;

            // Act
            var result = await productController.Get(idProduct);
            ObjectResult objectResult = (ObjectResult)result;
            var model = objectResult.Value as ProductModel;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.IsNotNull(model);
            Assert.AreEqual(idProduct, model.ProductId);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("GetByIdAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            int idProduct = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace("GetByIdAsync")).Throws(new Exception());
            ProductController productController = new ProductController(mockLogger.Object);
            var getAll = productController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listProduct = objResult.Value as List<ProductModel>;
            if (listProduct != null)
                idProduct = listProduct[0].ProductId;

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => productController.Get(idProduct));
        }

        [TestMethod]
        public async Task UpdateAsync_Sucesso()
        {
            // Arrange
            int idProduct = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProductController productController = new ProductController(mockLogger.Object);
            var getAll = productController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listProduct = objResult.Value as List<ProductModel>;
            if (listProduct != null)
                idProduct = listProduct[0].ProductId;
            string productName = Faker.Name.First();
            int categoryId = Faker.RandomNumber.Next(0, 1000);
            string categoryName = Faker.Name.First();
            string costPrice = Faker.RandomNumber.Next(0, 100).ToString();
            string salePrice = Faker.RandomNumber.Next(0, 100).ToString();
            int quantityStock = Faker.RandomNumber.Next(0, 100);
            int minimumStockQuantity = Faker.RandomNumber.Next(0, 100);
            string totalValueCostOfInventory = Faker.RandomNumber.Next(0, 100).ToString();
            string totalValueSaleStock = Faker.RandomNumber.Next(0, 100).ToString();
            bool needToPrint = true;
            bool status = true;
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = Faker.Finance.Maturity();
            DateTime dateInsert = Faker.Finance.Maturity();
            List<string> listString = new List<string>() { productName, categoryName, costPrice, salePrice, totalValueCostOfInventory, totalValueSaleStock, userName };
            List<int> listInts = new List<int>() { idProduct, categoryId, quantityStock, minimumStockQuantity, userId };
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            ProductModel productModel = new ProductModel(listInts, listString, status, listDateTime, needToPrint);

            // Act
            await productController.Update(productModel);

            // Assert
            mockLogger.Verify(x => x.Trace("UpdateProductAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void UpdateAsync_Erro()
        {
            // Arrange
            int idProduct = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            string productName = Faker.Name.First();
            int categoryId = Faker.RandomNumber.Next(0, 1000);
            string categoryName = Faker.Name.First();
            string costPrice = Faker.RandomNumber.Next(0, 100).ToString();
            string salePrice = Faker.RandomNumber.Next(0, 100).ToString();
            int quantityStock = Faker.RandomNumber.Next(0, 100);
            int minimumStockQuantity = Faker.RandomNumber.Next(0, 100);
            string totalValueCostOfInventory = Faker.RandomNumber.Next(0, 100).ToString();
            string totalValueSaleStock = Faker.RandomNumber.Next(0, 100).ToString();
            bool needToPrint = true;
            bool status = true;
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = Faker.Finance.Maturity();
            DateTime dateInsert = Faker.Finance.Maturity();
            List<string> listString = new List<string>() { productName, categoryName, costPrice, salePrice, totalValueCostOfInventory, totalValueSaleStock, userName };
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };

            //Setup
            mockLogger.Setup(x => x.Trace("UpdateProductAsync")).Throws(new Exception());
            ProductController productController = new ProductController(mockLogger.Object);
            var getAll = productController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listProduct = objResult.Value as List<ProductModel>;
            if (listProduct != null)
                idProduct = listProduct[0].ProductId;
            List<int> listInts = new List<int>() { idProduct, categoryId, quantityStock, minimumStockQuantity, userId };
            ProductModel productModel = new ProductModel(listInts, listString, status, listDateTime, needToPrint);

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => productController.Update(productModel));

        }

        [TestMethod]
        public async Task InsertAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProductController productController = new ProductController(mockLogger.Object);
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
            bool needToPrint = true;
            bool status = true;
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = Faker.Finance.Maturity();
            DateTime dateInsert = Faker.Finance.Maturity();
            List<string> listString = new List<string>() { productName, categoryName, costPrice, salePrice, totalValueCostOfInventory, totalValueSaleStock, userName };
            List<int> listInts = new List<int>() { productId, categoryId, quantityStock, minimumStockQuantity, userId };
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            ProductModel productModel = new ProductModel(listInts, listString, status, listDateTime, needToPrint);

            // Act
            await productController.Post(productModel);

            // Assert
            mockLogger.Verify(x => x.Trace("InsertProductAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void InsertAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace("InsertProductAsync")).Throws(new Exception());
            ProductController productController = new ProductController(mockLogger.Object);
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
            bool needToPrint = true;
            bool status = true;
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = Faker.Finance.Maturity();
            DateTime dateInsert = Faker.Finance.Maturity();
            List<string> listString = new List<string>() { productName, categoryName, costPrice, salePrice, totalValueCostOfInventory, totalValueSaleStock, userName };
            List<int> listInts = new List<int>() { productId, categoryId, quantityStock, minimumStockQuantity, userId };
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            ProductModel productModel = new ProductModel(listInts, listString, status, listDateTime, needToPrint);

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => productController.Post(productModel));
        }

        [TestMethod]
        public async Task DeleteAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProductController productController = new ProductController(mockLogger.Object);
            int productId = Faker.RandomNumber.Next(0, 1000);

            // Act
            await productController.Delete(productId);

            // Assert
            mockLogger.Verify(x => x.Trace("DeleteProductAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void DeleteAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace("DeleteProductAsync")).Throws(new Exception());
            ProductController productController = new ProductController(mockLogger.Object);
            int productId = Faker.RandomNumber.Next(0, 1000);

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => productController.Delete(productId));
        }
    }
}
