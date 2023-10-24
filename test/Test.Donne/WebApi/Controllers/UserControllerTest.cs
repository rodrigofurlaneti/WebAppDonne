using Domain.Donne;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Controllers.UserControllerTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Controllers > UserController")]
    public class UserControllerTest
    {
        [TestMethod]
        public async Task GetUserAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserController userController = new UserController(mockLogger.Object);

            // Act
            var result = await userController.Get();
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("GetUserAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetAllUserAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetUserAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            // Setup
            mockLogger.Setup(x => x.Trace("GetUserAsync")).Throws(new Exception());
            UserController userController = new UserController(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => userController.Get());

            // Assert
            mockLogger.Verify(x => x.TraceException("GetUserAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserController userController = new UserController(mockLogger.Object);
            var getAll = userController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var list = objResult.Value as List<UserModel>;
            int id = list[0].UserId;

            // Act
            var result = await userController.Get(id);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("GetByIdAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetByIdAsync")).Throws(new Exception());
            UserController userController = new UserController(mockLogger.Object);
            var getAll = userController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var list = objResult.Value as List<UserModel>;
            int id = list[0].UserId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => userController.Get(id));

            // Assert
            mockLogger.Verify(x => x.TraceException("GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByNameAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserController userController = new UserController(mockLogger.Object);
            var getAll = userController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var list = objResult.Value as List<UserModel>;
            string name = list[0].UserName;

            // Act
            var result = await userController.Get(name);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("GetByNameAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void GetByNameAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetByNameAsync")).Throws(new Exception());
            UserController userController = new UserController(mockLogger.Object);
            var getAll = userController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var list = objResult.Value as List<UserModel>;
            string name = list[0].UserName;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => userController.Get(name));

            // Assert
            mockLogger.Verify(x => x.TraceException("GetByNameAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task InsertAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserController userController = new UserController(mockLogger.Object);
            int profileId = Faker.RandomNumber.Next(0, 1000);
            string profileName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            string userPassword = Faker.Name.First();
            bool status = true;
            UserModel userModel = new UserModel(userId, userName,
                userPassword, profileId, profileName, status);


            // Act
            await userController.Post(userModel);

            // Assert
            mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void InsertAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("InsertAsync")).Throws(new Exception());
            UserController userController = new UserController(mockLogger.Object);
            int profileId = Faker.RandomNumber.Next(0, 1000);
            string profileName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            string userPassword = Faker.Name.First();
            bool status = true;
            UserModel userModel = new UserModel(userId, userName,
                userPassword, profileId, profileName, status);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => userController.Post(userModel));

            // Assert
            mockLogger.Verify(x => x.TraceException("InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserController userController = new UserController(mockLogger.Object);
            var getAll = userController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var list = objResult.Value as List<UserModel>;
            int userId = list[0].UserId;
            int profileId = Faker.RandomNumber.Next(0, 1000);
            string profileName = Faker.Name.First();
            string userName = Faker.Name.First();
            string userPassword = Faker.Name.First();
            bool status = true;
            UserModel userModel = new UserModel(userId, userName,
                userPassword, profileId, profileName, status);


            // Act
            await userController.Update(userModel);

            // Assert
            mockLogger.Verify(x => x.Trace("UpdateAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void UpdateAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("UpdateAsync")).Throws(new Exception());
            UserController userController = new UserController(mockLogger.Object);
            var getAll = userController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var list = objResult.Value as List<UserModel>;
            int userId = list[0].UserId;
            int profileId = Faker.RandomNumber.Next(0, 1000);
            string profileName = Faker.Name.First();
            string userName = Faker.Name.First();
            string userPassword = Faker.Name.First();
            bool status = true;
            UserModel userModel = new UserModel(userId, userName,
                userPassword, profileId, profileName, status);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => userController.Update(userModel));

            // Assert
            mockLogger.Verify(x => x.TraceException("UpdateAsync"), Times.Exactly(1));
        }
    }
}
