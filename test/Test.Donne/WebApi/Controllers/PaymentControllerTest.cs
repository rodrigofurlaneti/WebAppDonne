using Domain.Donne;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Controllers.PaymentControllerTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Controllers > PaymentController")]
    public class PaymentControllerTest
    {
        [TestMethod]
        public async Task GetPaymentAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            PaymentController paymentController = new PaymentController(mockLogger.Object);

            // Act
            var result = await paymentController.GetPayment();
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("Payment_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetPaymentAsync"), Times.Exactly(1));
        }


        [TestMethod]
        public void GetPaymentAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace("GetPaymentAsync")).Throws(new Exception());
            PaymentController paymentController = new PaymentController(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => paymentController.GetPayment());

            // Assert
            mockLogger.Verify(x => x.Trace("GetPaymentAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("GetPaymentAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            await InsertAsync_Sucesso();
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            PaymentController paymentController = new PaymentController(mockLogger.Object);
            var getAll = paymentController.GetPayment();
            var objResult = (OkObjectResult)getAll.Result;
            var listPayment = objResult.Value as List<PaymentModel>;
            if (listPayment != null)
                id = listPayment[0].PaymentId;

            // Act
            var result = await paymentController.GetFormOfPayment(id);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("Payment_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetPaymentAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Payment_GetByIdAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            PaymentController paymentController = new PaymentController(mockLogger.Object);
            var getAll = paymentController.GetPayment();
            var objResult = (OkObjectResult)getAll.Result;
            var listPayment = objResult.Value as List<PaymentModel>;
            if (listPayment != null)
                id = listPayment[0].PaymentId;

            //Setup
            mockLogger.Setup(x => x.Trace("GetByIdAsync")).Throws(new Exception());

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => paymentController.GetFormOfPayment(id));

            // Assert
            mockLogger.Verify(x => x.Trace("GetByIdAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task InsertAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            PaymentController paymentController = new PaymentController(mockLogger.Object);
            int paymentId = Faker.RandomNumber.Next(0, 100);
            int commandId = Faker.RandomNumber.Next(0, 100);
            int formOfPaymentId = Faker.RandomNumber.Next(0, 100);
            string formOfPaymentName = Faker.Name.First();
            string paymentAmount = Faker.RandomNumber.Next(0, 1000).ToString();
            string paymentType = Faker.RandomNumber.Next(0, 1000).ToString();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            PaymentModel paymentModel = new PaymentModel(paymentId, commandId,
                formOfPaymentId, formOfPaymentName, paymentAmount, paymentType, listDateTime,
                userId, userName);

            // Act
            await paymentController.Post(paymentModel);

            // Assert
            mockLogger.Verify(x => x.Trace("Payment_InsertAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void InsertAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            int paymentId = Faker.RandomNumber.Next(0, 100);
            int commandId = Faker.RandomNumber.Next(0, 100);
            int formOfPaymentId = Faker.RandomNumber.Next(0, 100);
            string formOfPaymentName = Faker.Name.First();
            string paymentAmount = Faker.RandomNumber.Next(0, 1000).ToString();
            string paymentType = Faker.RandomNumber.Next(0, 1000).ToString();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            PaymentModel paymentModel = new PaymentModel(paymentId, commandId,
                formOfPaymentId, formOfPaymentName, paymentAmount, paymentType, listDateTime,
                userId, userName);

            //Setup
            mockLogger.Setup(x => x.Trace("InsertAsync")).Throws(new Exception());
            PaymentController paymentController = new PaymentController(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => paymentController.Post(paymentModel));

            // Assert
            mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Sucesso()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            PaymentController paymentController = new PaymentController(mockLogger.Object);
            var getAll = paymentController.GetPayment();
            var objResult = (OkObjectResult)getAll.Result;
            var listPayment = objResult.Value as List<PaymentModel>;
            if (listPayment != null)
                id = listPayment[0].PaymentId;
            int commandId = Faker.RandomNumber.Next(0, 100);
            int formOfPaymentId = Faker.RandomNumber.Next(0, 100);
            string formOfPaymentName = Faker.Name.First();
            string paymentAmount = Faker.RandomNumber.Next(0, 1000).ToString();
            string paymentType = Faker.RandomNumber.Next(0, 1000).ToString();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            PaymentModel paymentModel = new PaymentModel(id, commandId,
                formOfPaymentId, formOfPaymentName, paymentAmount, paymentType, listDateTime,
                userId, userName);

            // Act
            await paymentController.Update(paymentModel);

            // Assert
            mockLogger.Verify(x => x.Trace("Payment_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetPaymentAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Payment_UpdateAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void UpdateAsync_Erro()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace("UpdateAsync")).Throws(new Exception());
            PaymentController paymentController = new PaymentController(mockLogger.Object);
            var getAll = paymentController.GetPayment();
            var objResult = (OkObjectResult)getAll.Result;
            var listPayment = objResult.Value as List<PaymentModel>;
            if (listPayment != null)
                id = listPayment[0].PaymentId;
            int commandId = Faker.RandomNumber.Next(0, 100);
            int formOfPaymentId = Faker.RandomNumber.Next(0, 100);
            string formOfPaymentName = Faker.Name.First();
            string paymentAmount = Faker.RandomNumber.Next(0, 1000).ToString();
            string paymentType = Faker.RandomNumber.Next(0, 1000).ToString();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            PaymentModel paymentModel = new PaymentModel(id, commandId,
                formOfPaymentId, formOfPaymentName, paymentAmount, paymentType, listDateTime,
                userId, userName);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => paymentController.Update(paymentModel));

            // Assert
            mockLogger.Verify(x => x.Trace("Payment_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetPaymentAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task DeleteAsync_Sucesso()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            PaymentController paymentController = new PaymentController(mockLogger.Object);
            var getAll = paymentController.GetPayment();
            var objResult = (OkObjectResult)getAll.Result;
            var listPayment = objResult.Value as List<PaymentModel>;
            if(listPayment != null)
                id = listPayment[0].PaymentId;

            // Act
            await paymentController.Delete(id);

            // Assert
            mockLogger.Verify(x => x.Trace("Payment_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetPaymentAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Payment_DeleteAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void DeleteAsync_Erro()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace("DeleteAsync")).Throws(new Exception());
            PaymentController paymentController = new PaymentController(mockLogger.Object);
            var getAll = paymentController.GetPayment();
            var objResult = (OkObjectResult)getAll.Result;
            var listPayment = objResult.Value as List<PaymentModel>;
            if (listPayment != null)
                id = listPayment[0].PaymentId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => paymentController.Delete(id));

            // Assert
            //mockLogger.Verify(x => x.TraceException("GetPaymentAsync"), Times.Once());
        }
    }
}
