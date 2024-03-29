﻿using Domain.Donne;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.Buyer;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Controllers.CommandControllerTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Controllers > CommandController")]
    public class CommandControllerTest
    {
        [TestMethod]
        public async Task GetCommandsAsync_Sucesso()
        {
            // Arrange
            await InsertReturnIntAsync_Sucesso();
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandController commandController = new CommandController(mockLogger.Object);

            // Act
            var result = await commandController.GetCommand();
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("Command_GetAllAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void GetCommandsAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            
            // Setup
            mockLogger.Setup(x => x.Trace("Command_GetAllAsync")).Throws(new Exception());
            CommandController commandController = new CommandController(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => commandController.GetCommand());

            // Assert
            mockLogger.Verify(x => x.TraceException("Command_GetAllAsync"), Times.Exactly(1));
        }

        //[TestMethod]
        //public async Task GetByStatusAsync_Sucesso()
        //{
        //    // Arrange
        //    await InsertReturnIntAsync_Sucesso();
        //    int id = 0;
        //    Mock<ILogger> mockLogger = new Mock<ILogger>();
        //    CommandController commandController = new CommandController(mockLogger.Object);
        //    var getAll = commandController.GetCommand();
        //    var objResult = (OkObjectResult)getAll.Result;
        //    var list = objResult.Value as List<CommandModel>;
        //    if (list != null)
        //        id = list[0].CommandId;

        //    // Act
        //    var result = await commandController.Options(id);
        //    ObjectResult objectResult = (ObjectResult)result;

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Assert.IsNotNull(objectResult);
        //    Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        //    Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
        //    mockLogger.Verify(x => x.Trace("Command_GetAllAsync"), Times.Exactly(2));
        //    mockLogger.Verify(x => x.Trace("Command_GetByStatusAsync"), Times.Exactly(2));
        //}

        [TestMethod]
        public void GetByStatusAsync_Erro()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            // Setup
            mockLogger.Setup(x => x.Trace("Command_GetByStatusAsync")).Throws(new Exception());
            CommandController commandController = new CommandController(mockLogger.Object);
            var getAll = commandController.GetCommand();
            var objResult = (OkObjectResult)getAll.Result;
            var list = objResult.Value as List<CommandModel>;
            if (list != null)
                id = list[0].CommandId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => commandController.Options(id));

            // Assert
            mockLogger.Verify(x => x.Trace("Command_GetByStatusAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("Command_GetByStatusAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            await InsertReturnIntAsync_Sucesso();
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandController commandController = new CommandController(mockLogger.Object);
            var getAll = commandController.GetCommand();
            var objResult = (OkObjectResult)getAll.Result;
            var list = objResult.Value as List<CommandModel>;
            if (list != null)
                id = list[0].CommandId;

            // Act
            var result = await commandController.GetCommand(id);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("Command_GetAllAsync"), Times.Exactly(2));
            mockLogger.Verify(x => x.Trace("Command_GetByIdAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Command_GetByIdAsync")).Throws(new Exception());
            CommandController commandController = new CommandController(mockLogger.Object);
            var getAll = commandController.GetCommand();
            var objResult = (OkObjectResult)getAll.Result;
            var list = objResult.Value as List<CommandModel>;
            if (list != null)
                id = list[0].CommandId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => commandController.GetCommand(id));

            // Assert
            mockLogger.Verify(x => x.TraceException("Command_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task InsertReturnIntAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandController commandController = new CommandController(mockLogger.Object);
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);
            var buyer = await buyerRepository.GetAllAsync();
            int buyerId = buyer.First().BuyerId;
            string buyerName = buyer.First().BuyerName;
            int commandId = Faker.RandomNumber.Next(0, 100);
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            int status = 1;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CommandModel commandModel = new CommandModel(commandId, buyerId, buyerName, status, listDateTime,
                userId, userName);

            // Act
            var result = await commandController.Post(commandModel);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("InsertReturnIntAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("InsertReturnIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void InsertReturnIntAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("InsertReturnIntAsync")).Throws(new Exception());
            CommandController commandController = new CommandController(mockLogger.Object);
            int buyerId = Faker.RandomNumber.Next(0, 100);
            string buyerName = Faker.Name.FullName();
            int commandId = Faker.RandomNumber.Next(0, 100);
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            int status = 1;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CommandModel commandModel = new CommandModel(commandId, buyerId, buyerName, status, listDateTime,
                userId, userName);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => commandController.Post(commandModel));

            // Assert
            mockLogger.Verify(x => x.Trace("InsertReturnIntAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Sucesso()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandController commandController = new CommandController(mockLogger.Object);
            var getAll = commandController.GetCommand();
            var objResult = (OkObjectResult)getAll.Result;
            var list = objResult.Value as List<CommandModel>;
            if (list != null)
                id = list[0].CommandId;
            int buyerId = Faker.RandomNumber.Next(0, 100);
            string buyerName = Faker.Name.FullName();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            int status = 1;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CommandModel commandModel = new CommandModel(id, buyerId, buyerName, status, listDateTime,
                userId, userName);

            // Act
            await commandController.Update(commandModel);

            // Assert
            mockLogger.Verify(x => x.Trace("Command_GetAllAsync"), Times.Exactly(2));
            mockLogger.Verify(x => x.Trace("Command_UpdateAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void UpdateAsync_Erro()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Command_UpdateAsync")).Throws(new Exception());
            CommandController commandController = new CommandController(mockLogger.Object);
            var getAll = commandController.GetCommand();
            var objResult = (OkObjectResult)getAll.Result;
            var list = objResult.Value as List<CommandModel>;
            if (list != null)
                id = list[0].CommandId;
            int buyerId = Faker.RandomNumber.Next(0, 100);
            string buyerName = Faker.Name.FullName();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            int status = 1;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CommandModel commandModel = new CommandModel(id, buyerId, buyerName, status, listDateTime,
                userId, userName);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => commandController.Update(commandModel));

            // Assert
            mockLogger.Verify(x => x.TraceException("Command_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task DeleteAsync_Sucesso()
        {
            // Arrange
            await InsertReturnIntAsync_Sucesso();
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandController commandController = new CommandController(mockLogger.Object);
            var getAll = commandController.GetCommand();
            var objResult = (OkObjectResult)getAll.Result;
            var list = objResult.Value as List<CommandModel>;
            if (list != null)
                id = list[0].CommandId;

            // Act
            await commandController.Delete(id);

            // Assert
            mockLogger.Verify(x => x.Trace("Command_GetAllAsync"), Times.Exactly(2));
            mockLogger.Verify(x => x.Trace("Command_DeleteAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void DeleteAsync_Erro()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Command_DeleteAsync")).Throws(new Exception());
            CommandController commandController = new CommandController(mockLogger.Object);
            var getAll = commandController.GetCommand();
            var objResult = (OkObjectResult)getAll.Result;
            var list = objResult.Value as List<CommandModel>;
            if (list != null)
                id = list[0].CommandId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => commandController.Delete(id));

            // Assert
            mockLogger.Verify(x => x.TraceException("Command_DeleteAsync"), Times.Exactly(1));
        }
    }
}
