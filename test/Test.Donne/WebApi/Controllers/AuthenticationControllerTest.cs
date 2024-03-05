using AutoFixture;
using Domain.Donne;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Controllers.AuthenticationControllerTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Controllers > AuthenticationController")]
    public class AuthenticationControllerTest
    {
        [TestMethod]
        public async Task Get_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            AuthenticationController authenticationController = new AuthenticationController(mockLogger.Object);

            // Act
            var result = await authenticationController.GetAuthentication();
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("User_GetUserAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Authentication_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Get_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace("User_GetUserAsync")).Throws(new Exception());
            AuthenticationController authenticationController = new AuthenticationController(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => authenticationController.GetAuthentication());

            // Assert
            mockLogger.Verify(x => x.TraceException("User_GetUserAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Post_Sucesso()
        {
            // Arrange
            string userNameExpectedValue = Faker.Name.First();
            string userPasswordExpectedValue = Faker.Name.First();
            string serverInternetProtocolExpectedValue = "127.0.0.1";
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            AuthenticationController authenticationController = new AuthenticationController(mockLogger.Object);
            UserController userController = new UserController(mockLogger.Object);
            Fixture fixture = new Fixture();
            AuthenticationUserModel authenticationUserModel = fixture.Build<AuthenticationUserModel>()
                        .With(authenticationUserModel => authenticationUserModel.UserName, userNameExpectedValue)
                        .With(authenticationUserModel => authenticationUserModel.UserPassword, userPasswordExpectedValue)
                        .With(authenticationUserModel => authenticationUserModel.ServerInternetProtocol, serverInternetProtocolExpectedValue)
                        .Create<AuthenticationUserModel>();
            UserModel userModel = fixture.Build<UserModel>()
                        .With(userModel => userModel.UserName, userNameExpectedValue)
                        .With(userModel => userModel.UserPassword, userPasswordExpectedValue)
                        .Create<UserModel>();
            await userController.Post(userModel);

            // Act
            var result = await authenticationController.Post(authenticationUserModel);

            // Assert
            mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("User_InsertAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Authentication_InsertAuthentication"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("User_GetByNameAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Authentication_InvalidPassword_InsertAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Authentication_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Post_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            string userNameExpectedValue = Faker.Name.First();
            string userPasswordExpectedValue = Faker.Name.First();
            string serverInternetProtocolExpectedValue = "127.0.0.1";
            Fixture fixture = new Fixture();
            AuthenticationUserModel authenticationUserModel = fixture.Build<AuthenticationUserModel>()
                        .With(authenticationUserModel => authenticationUserModel.UserName, userNameExpectedValue)
                        .With(authenticationUserModel => authenticationUserModel.UserPassword, userPasswordExpectedValue)
                        .With(authenticationUserModel => authenticationUserModel.ServerInternetProtocol, serverInternetProtocolExpectedValue)
                        .Create<AuthenticationUserModel>();

            //Setup
            mockLogger.Setup(x => x.Trace("Authentication_InsertAuthentication")).Throws(new Exception());
            AuthenticationController authenticationController = new AuthenticationController(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => authenticationController.Post(authenticationUserModel));

            // Assert
            mockLogger.Verify(x => x.TraceException("Authentication_InsertAuthentication"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Post_InvalidUserName_Sucesso()
        {
            // Arrange
            string userNameInvalidExpectedValue = Faker.Name.First();
            string userPasswordInvalidExpectedValue = Faker.Name.First();
            string serverInternetProtocolExpectedValue = "127.0.0.1";
            string objectResultExpectedValue = "InvalidUserName";
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            AuthenticationController authenticationController = new AuthenticationController(mockLogger.Object);
            UserController userController = new UserController(mockLogger.Object);
            Fixture fixture = new Fixture();
            AuthenticationUserModel authenticationUserModel = fixture.Build<AuthenticationUserModel>()
                        .With(authenticationUserModel => authenticationUserModel.UserName, userNameInvalidExpectedValue)
                        .With(authenticationUserModel => authenticationUserModel.UserPassword, userPasswordInvalidExpectedValue)
                        .With(authenticationUserModel => authenticationUserModel.ServerInternetProtocol, serverInternetProtocolExpectedValue)
                        .Create<AuthenticationUserModel>();

            // Act
            var result = await authenticationController.Post(authenticationUserModel);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.Unauthorized, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status401Unauthorized, objectResult.StatusCode);
            Assert.AreEqual(objectResultExpectedValue, objectResult.Value);
            mockLogger.Verify(x => x.Trace("Authentication_InsertAuthentication"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("User_GetByNameAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Authentication_InvalidUserName_InsertAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Authentication_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Post_InvalidUserPassword_Sucesso()
        {
            // Arrange
            string userNameExpectedValue = Faker.Name.First();
            string userPasswordExpectedValue = Faker.Name.First();
            string userPasswordFakeExpectedValue = Faker.Name.First();
            string serverInternetProtocolExpectedValue = "127.0.0.1";
            string objectResultExpectedValue = "InvalidPassword";
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            AuthenticationController authenticationController = new AuthenticationController(mockLogger.Object);
            UserController userController = new UserController(mockLogger.Object);
            Fixture fixture = new Fixture();
            AuthenticationUserModel authenticationUserModel = fixture.Build<AuthenticationUserModel>()
                        .With(authenticationUserModel => authenticationUserModel.UserName, userNameExpectedValue)
                        .With(authenticationUserModel => authenticationUserModel.UserPassword, userPasswordFakeExpectedValue)
                        .With(authenticationUserModel => authenticationUserModel.ServerInternetProtocol, serverInternetProtocolExpectedValue)
                        .Create<AuthenticationUserModel>();
            UserModel userModel = fixture.Build<UserModel>()
                        .With(userModel => userModel.UserName, userNameExpectedValue)
                        .With(userModel => userModel.UserPassword, userPasswordExpectedValue)
                        .Create<UserModel>();
            await userController.Post(userModel);

            // Act
            var result = await authenticationController.Post(authenticationUserModel);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.Unauthorized, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status401Unauthorized, objectResult.StatusCode);
            Assert.AreEqual(objectResultExpectedValue, objectResult.Value);
            mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("User_InsertAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Authentication_InsertAuthentication"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("User_GetByNameAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Authentication_InvalidPassword_InsertAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Authentication_InsertAsync"), Times.Exactly(1));
        }
    }
}
