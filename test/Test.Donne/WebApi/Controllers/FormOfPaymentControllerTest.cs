﻿using Domain.Donne;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Controllers
{
    [TestClass]
    [TestCategory("Donne > WebApi > Controllers > CategoryController")]
    public class FormOfPaymentControllerTest
    {
        [TestMethod]
        public async Task GetFormOfPaymentAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentController formOfPaymentController = new FormOfPaymentController(mockLogger.Object);

            // Act
            var result = await formOfPaymentController.Get();
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("GetFormOfPaymentAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetAllFormOfPaymentAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetFormOfPaymentAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetFormOfPaymentAsync")).Throws(new ArgumentNullException());
            FormOfPaymentController formOfPaymentController = new FormOfPaymentController(mockLogger.Object);

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => formOfPaymentController.Get());
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentController formOfPaymentController = new FormOfPaymentController(mockLogger.Object);
            var getAll = formOfPaymentController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listCategorys = objResult.Value as List<FormOfPaymentModel>;
            int formOfPaymentId = listCategorys[0].FormOfPaymentId;

            // Act
            var result = await formOfPaymentController.Get(formOfPaymentId);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("GetByIdAsync"), Times.Exactly(2));
            mockLogger.Verify(x => x.Trace("GetAllFormOfPaymentAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetByIdAsync")).Throws(new ArgumentNullException());
            FormOfPaymentController formOfPaymentController = new FormOfPaymentController(mockLogger.Object);
            var getAll = formOfPaymentController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listCategorys = objResult.Value as List<FormOfPaymentModel>;
            int formOfPaymentId = listCategorys[0].FormOfPaymentId;

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => formOfPaymentController.Get(formOfPaymentId));
        }

        [TestMethod]
        public async Task Post_Sucesso()
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
            mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("InsertFormOfPaymentAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Post_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("InsertFormOfPaymentAsync")).Throws(new ArgumentNullException());
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
            mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentController formOfPaymentController = new FormOfPaymentController(mockLogger.Object);
            var getAll = formOfPaymentController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listCategorys = objResult.Value as List<FormOfPaymentModel>;
            int formOfPaymentId = listCategorys[0].FormOfPaymentId;
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
            mockLogger.Verify(x => x.Trace("UpdateAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("UpdateFormOfPaymentAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("UpdateFormOfPaymentAsync")).Throws(new ArgumentNullException());
            FormOfPaymentController formOfPaymentController = new FormOfPaymentController(mockLogger.Object);
            var getAll = formOfPaymentController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listCategorys = objResult.Value as List<FormOfPaymentModel>;
            int formOfPaymentId = listCategorys[0].FormOfPaymentId;
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
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentController formOfPaymentController = new FormOfPaymentController(mockLogger.Object);
            var getAll = formOfPaymentController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listCategorys = objResult.Value as List<FormOfPaymentModel>;
            int formOfPaymentId = listCategorys[0].FormOfPaymentId;

            // Act
            await formOfPaymentController.Delete(formOfPaymentId);

            // Assert
            mockLogger.Verify(x => x.Trace("DeleteAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("DeleteFormOfPaymentAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("DeleteFormOfPaymentAsync")).Throws(new ArgumentNullException());
            FormOfPaymentController formOfPaymentController = new FormOfPaymentController(mockLogger.Object);
            var getAll = formOfPaymentController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listCategorys = objResult.Value as List<FormOfPaymentModel>;
            int formOfPaymentId = listCategorys[0].FormOfPaymentId;

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => formOfPaymentController.Delete(formOfPaymentId));
        }
    }
}
