using Domain.Donne;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Controllers.FormOfPaymentControllerTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Controllers > FormOfPaymentController")]
    public class FormOfPaymentControllerTest
    {
        [TestMethod]
        public async Task GetFormOfPaymentAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentController formOfPaymentController = new FormOfPaymentController(mockLogger.Object);

            // Act
            var result = await formOfPaymentController.GetFormOfPayment();
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("GetFormOfPaymentAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("FormOfPayment_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetFormOfPaymentAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetFormOfPaymentAsync")).Throws(new Exception());
            FormOfPaymentController formOfPaymentController = new FormOfPaymentController(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => formOfPaymentController.GetFormOfPayment());

            // Assert
            mockLogger.Verify(x => x.Trace("GetFormOfPaymentAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("GetFormOfPaymentAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            await Insert_Sucesso();
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentController formOfPaymentController = new FormOfPaymentController(mockLogger.Object);
            var getAll = formOfPaymentController.GetFormOfPayment();
            var objResult = (OkObjectResult)getAll.Result;
            var listCategorys = objResult.Value as List<FormOfPaymentModel>;
            if(listCategorys != null)
                id = listCategorys[0].FormOfPaymentId;

            // Act
            var result = await formOfPaymentController.GetFormOfPayment(id);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("GetFormOfPaymentAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("FormOfPayment_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByIdAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("FormOfPayment_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            int formOfPaymentId = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetByIdAsync")).Throws(new Exception());
            FormOfPaymentController formOfPaymentController = new FormOfPaymentController(mockLogger.Object);
            var getAll = formOfPaymentController.GetFormOfPayment();
            var objResult = (OkObjectResult)getAll.Result;
            var listCategorys = objResult.Value as List<FormOfPaymentModel>;
            if(listCategorys != null)
                formOfPaymentId = listCategorys[0].FormOfPaymentId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => formOfPaymentController.GetFormOfPayment(formOfPaymentId));

            // Assert
            mockLogger.Verify(x => x.Trace("GetByIdAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Insert_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentController formOfPaymentController = new FormOfPaymentController(mockLogger.Object);
            int formOfPaymentId = Faker.RandomNumber.Next(0, 100);
            string formOfPaymentName = Faker.Name.FullName();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            FormOfPaymentModel formOfPaymentModel = new FormOfPaymentModel(formOfPaymentId,
                formOfPaymentName, listDateTime, userId, userName);

            // Act
            await formOfPaymentController.Post(formOfPaymentModel);
            
            // Assert
            mockLogger.Verify(x => x.Trace("FormOfPayment_InsertAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("InsertFormOfPaymentAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Insert_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("InsertFormOfPaymentAsync")).Throws(new Exception());
            FormOfPaymentController formOfPaymentController = new FormOfPaymentController(mockLogger.Object);
            int formOfPaymentId = Faker.RandomNumber.Next(0, 100);
            string formOfPaymentName = Faker.Name.FullName();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            FormOfPaymentModel formOfPaymentModel = new FormOfPaymentModel(formOfPaymentId,
                formOfPaymentName, listDateTime, userId, userName);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => formOfPaymentController.Post(formOfPaymentModel));

            // Assert
            mockLogger.Verify(x => x.Trace("FormOfPayment_InsertAsync"), Times.Exactly(0));
            mockLogger.Verify(x => x.Trace("InsertFormOfPaymentAsync"), Times.Exactly(0));
        }

        [TestMethod]
        public async Task Update_Sucesso()
        {
            // Arrange
            int formOfPaymentId = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentController formOfPaymentController = new FormOfPaymentController(mockLogger.Object);
            var getAll = formOfPaymentController.GetFormOfPayment();
            var objResult = (OkObjectResult)getAll.Result;
            var listCategorys = objResult.Value as List<FormOfPaymentModel>;
            if (listCategorys != null)
                formOfPaymentId = listCategorys[0].FormOfPaymentId;
            string formOfPaymentName = Faker.Name.FullName();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            FormOfPaymentModel formOfPaymentModel = new FormOfPaymentModel(formOfPaymentId,
                formOfPaymentName, listDateTime, userId, userName);

            // Act
            await formOfPaymentController.Update(formOfPaymentModel);

            // Assert
            mockLogger.Verify(x => x.Trace("GetFormOfPaymentAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("FormOfPayment_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("FormOfPayment_UpdateAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("UpdateFormOfPaymentAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Erro()
        {
            // Arrange
            int formOfPaymentId = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("UpdateFormOfPaymentAsync")).Throws(new Exception());
            FormOfPaymentController formOfPaymentController = new FormOfPaymentController(mockLogger.Object);
            var getAll = formOfPaymentController.GetFormOfPayment();
            var objResult = (OkObjectResult)getAll.Result;
            var listCategorys = objResult.Value as List<FormOfPaymentModel>;
            if (listCategorys != null)
                formOfPaymentId = listCategorys[0].FormOfPaymentId;
            string formOfPaymentName = Faker.Name.FullName();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            FormOfPaymentModel formOfPaymentModel = new FormOfPaymentModel(formOfPaymentId,
                formOfPaymentName, listDateTime, userId, userName);

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => formOfPaymentController.Update(formOfPaymentModel));
        }

        [TestMethod]
        public async Task Delete_Sucesso()
        {
            // Arrange
            await Insert_Sucesso();
            int formOfPaymentId = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentController formOfPaymentController = new FormOfPaymentController(mockLogger.Object);
            var getAll = formOfPaymentController.GetFormOfPayment();
            var objResult = (OkObjectResult)getAll.Result;
            var listCategorys = objResult.Value as List<FormOfPaymentModel>;
            if (listCategorys != null)
                formOfPaymentId = listCategorys[0].FormOfPaymentId;

            // Act
            await formOfPaymentController.Delete(formOfPaymentId);

            // Assert
            mockLogger.Verify(x => x.Trace("GetFormOfPaymentAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("FormOfPayment_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("FormOfPayment_DeleteAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("DeleteFormOfPaymentAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Erro()
        {
            // Arrange
            int formOfPaymentId = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("DeleteFormOfPaymentAsync")).Throws(new Exception());
            FormOfPaymentController formOfPaymentController = new FormOfPaymentController(mockLogger.Object);
            var getAll = formOfPaymentController.GetFormOfPayment();
            var objResult = (OkObjectResult)getAll.Result;
            var listCategorys = objResult.Value as List<FormOfPaymentModel>;
            if (listCategorys != null)
                formOfPaymentId = listCategorys[0].FormOfPaymentId;

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => formOfPaymentController.Delete(formOfPaymentId));
        }
    }
}
