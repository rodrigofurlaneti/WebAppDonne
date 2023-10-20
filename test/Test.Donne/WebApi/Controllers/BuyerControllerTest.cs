using Domain.Donne;
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
            mockLogger.Setup(x => x.Trace("OptionsAsync")).Throws(new Exception());
            BuyerController buyerController = new BuyerController(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => buyerController.OptionsAsync(1));

            // Assert
            mockLogger.Verify(x => x.TraceExeption("OptionsAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceExeption("OptionsAsync"), Times.Exactly(1));
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

        [TestMethod]
        public async Task Insert_Post_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerController buyerController = new BuyerController(mockLogger.Object);
            string buyerAddress = Faker.Address.StreetAddress();
            string buyerName = Faker.Name.FullName();
            string userName = Faker.Name.First();
            int buyerId = Faker.RandomNumber.Next(0, 100);
            bool status = true;
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            string buyerPhone = Faker.RandomNumber.Next().ToString();
            int userId = Faker.RandomNumber.Next();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            BuyerModel buyerModel = new BuyerModel(buyerId, buyerName, buyerPhone, buyerAddress, status,
                listDateTime, userId, userName);

            // Act
            await buyerController.Post(buyerModel);

            // Assert
            mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void Insert_Post_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            string buyerAddress = Faker.Address.StreetAddress();
            string buyerName = Faker.Name.FullName();
            string userName = Faker.Name.First();
            int buyerId = Faker.RandomNumber.Next(0, 100);
            bool status = true;
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            string buyerPhone = Faker.RandomNumber.Next().ToString();
            int userId = Faker.RandomNumber.Next();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };

            //Setup
            mockLogger.Setup(x => x.Trace("InsertAsync")).Throws(new Exception());
            BuyerController buyerController = new BuyerController(mockLogger.Object);
            BuyerModel buyerModel = new BuyerModel(buyerId, buyerName, buyerPhone, buyerAddress, status,
            listDateTime, userId, userName);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => buyerController.Post(buyerModel));

            // Assert
            mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceExeption("InsertAsync"), Times.Exactly(1));
        }
    }
}
