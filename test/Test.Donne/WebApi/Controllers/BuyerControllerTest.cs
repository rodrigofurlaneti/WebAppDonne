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
            var result = await buyerController.GetBuyer();
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("Buyer_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetBuyerAsync"), Times.Exactly(1));
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
            Assert.ThrowsExceptionAsync<ArgumentException>(() => buyerController.GetBuyer());
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
            mockLogger.Verify(x => x.Trace("Buyer_GetByStatusAsync"), Times.Exactly(1));
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
            mockLogger.Verify(x => x.TraceException("OptionsAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("OptionsAsync"), Times.Exactly(1));
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
            mockLogger.Verify(x => x.Trace("Buyer_GetByStatusAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetById_Sucesso()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerController buyerController = new BuyerController(mockLogger.Object);
            var getAll = buyerController.GetBuyer();
            var objResult = (OkObjectResult)getAll.Result;
            var listBuyers = objResult.Value as List<BuyerModel>;
            if (listBuyers != null)
                id = listBuyers[0].BuyerId;

            // Act
            var result = await buyerController.Get(id);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.IsNotNull(listBuyers);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("Buyer_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetBuyerAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByIdAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Buyer_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Erro()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetByIdAsync")).Throws(new Exception());
            BuyerController buyerController = new BuyerController(mockLogger.Object);
            var getAll = buyerController.GetBuyer();
            var objResult = (OkObjectResult)getAll.Result;
            var listBuyers = objResult.Value as List<BuyerModel>;
            if (listBuyers != null)
                id = listBuyers[0].BuyerId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => buyerController.Get(id));

            // Assert
            mockLogger.Verify(x => x.Trace("GetByIdAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("GetByIdAsync"), Times.Exactly(1));
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
            int status = 1;
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
            mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Buyer_InsertAsync"), Times.Exactly(1));
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
            int status = 1;
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
            mockLogger.Verify(x => x.TraceException("InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Update_Sucesso()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            int status = 1;
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            string buyerPhone = Faker.RandomNumber.Next().ToString();
            int userId = Faker.RandomNumber.Next();
            string buyerAddress = Faker.Address.StreetAddress();
            string buyerName = Faker.Name.FullName();
            string userName = Faker.Name.First();

            //Setup
            BuyerController buyerController = new BuyerController(mockLogger.Object);
            var getAll = buyerController.GetBuyer();
            var objResult = (OkObjectResult)getAll.Result;
            var listBuyers = objResult.Value as List<BuyerModel>;
            if (listBuyers != null)
                id = listBuyers[0].BuyerId;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            BuyerModel buyerModel = new BuyerModel(id, buyerName, buyerPhone, buyerAddress, status,
                listDateTime, userId, userName);

            // Act
            await buyerController.Update(buyerModel);

            // Assert
            mockLogger.Verify(x => x.Trace("Buyer_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetBuyerAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("UpdateAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Buyer_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Erro()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("UpdateAsync")).Throws(new Exception());
            BuyerController buyerController = new BuyerController(mockLogger.Object);
            var getAll = buyerController.GetBuyer();
            var objResult = (OkObjectResult)getAll.Result;
            var listBuyers = objResult.Value as List<BuyerModel>;
            string buyerAddress = Faker.Address.StreetAddress();
            string buyerName = Faker.Name.FullName();
            string userName = Faker.Name.First();
            if (listBuyers != null)
                id = listBuyers[0].BuyerId;
            int status = 1;
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            string buyerPhone = Faker.RandomNumber.Next().ToString();
            int userId = Faker.RandomNumber.Next();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            BuyerModel buyerModel = new BuyerModel(id, buyerName, buyerPhone, buyerAddress, status,
                listDateTime, userId, userName);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => buyerController.Update(buyerModel));

            // Assert
            mockLogger.Verify(x => x.Trace("UpdateAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Delete_Sucesso()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            BuyerController buyerController = new BuyerController(mockLogger.Object);
            var getAll = buyerController.GetBuyer();
            var objResult = (OkObjectResult)getAll.Result;
            var listBuyers = objResult.Value as List<BuyerModel>;
            if (listBuyers != null)
                id = listBuyers[0].BuyerId;

            // Act
            await buyerController.Delete(id);

            // Assert
            mockLogger.Verify(x => x.Trace("Buyer_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetBuyerAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("DeleteAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Buyer_DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Erro()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace("DeleteAsync")).Throws(new Exception());
            BuyerController buyerController = new BuyerController(mockLogger.Object);
            var getAll = buyerController.GetBuyer();
            var objResult = (OkObjectResult)getAll.Result;
            var listBuyers = objResult.Value as List<BuyerModel>;
            if (listBuyers != null)
                id = listBuyers[0].BuyerId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => buyerController.Delete(id));

            // Assert
            mockLogger.Verify(x => x.Trace("GetBuyerAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("DeleteAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("DeleteAsync"), Times.Exactly(1));
        }
    }
}
