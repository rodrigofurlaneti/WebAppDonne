using AutoFixture;
using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Donne.Infrastructure.Authentication;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Infrastructure.AuthenticationRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > AuthenticationRepository")]
    public class AuthenticationRepositoryTest
    {
        [TestMethod]
        public void GetAllAuthentications_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            AuthenticationRepository authenticationRepository = new AuthenticationRepository(mockLogger.Object);

            // Act
            var result = authenticationRepository.GetAll();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Authentication_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllAuthentications_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Authentication_GetAll")).Throws(new ArgumentNullException());
            AuthenticationRepository authenticationRepository = new AuthenticationRepository(mockLogger.Object);


            // Act
            var resultAction = () => authenticationRepository.GetAll();
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("Authentication_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetAllAuthenticationsAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            AuthenticationRepository authenticationRepository = new AuthenticationRepository(mockLogger.Object);

            // Act
            var result = await authenticationRepository.GetAllAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Authentication_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetAllAuthenticationsAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Authentication_GetAllAsync")).Throws(new ArgumentNullException());
            AuthenticationRepository authenticationRepository = new AuthenticationRepository(mockLogger.Object);


            // Act
            var resultAction = () => authenticationRepository.GetAllAsync();
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("Authentication_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            AuthenticationRepository authenticationRepository = new AuthenticationRepository(mockLogger.Object);
            var resultAll = authenticationRepository.GetAll();

            // Act
            var result = authenticationRepository.GetById(resultAll.First().Id);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Authentication_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Authentication_GetById")).Throws(new ArgumentNullException());
            AuthenticationRepository authenticationRepository = new AuthenticationRepository(mockLogger.Object);
            var resultAll = authenticationRepository.GetAll();

            // Act
            var resultAction = () => authenticationRepository.GetById(resultAll.First().Id);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("Authentication_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            AuthenticationRepository authenticationRepository = new AuthenticationRepository(mockLogger.Object);
            var resultAll = await authenticationRepository.GetAllAsync();

            // Act
            var result = await authenticationRepository.GetByIdAsync(resultAll.First().Id);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Authentication_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Authentication_GetByIdAsync")).Throws(new ArgumentNullException());
            AuthenticationRepository authenticationRepository = new AuthenticationRepository(mockLogger.Object);
            var resultAll = await authenticationRepository.GetAllAsync();

            // Act
            var resultAction = () => authenticationRepository.GetByIdAsync(resultAll.First().Id);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("Authentication_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Insert_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            AuthenticationRepository authenticationRepository = new AuthenticationRepository(mockLogger.Object);
            Fixture fixture = new Fixture();
            AuthenticationModel authenticationModel = fixture.Build<AuthenticationModel>()
                .With(authenticationModel => authenticationModel.Id, Faker.RandomNumber.Next(1, 1000))
                .With(authenticationModel => authenticationModel.NavigatorUserAgent, "Google Chrome")
                .With(authenticationModel => authenticationModel.ServerInternetProtocol, "8.8.8.8")
                .With(authenticationModel => authenticationModel.ClientInternetProtocol, "7.7.7.7")
                .With(authenticationModel => authenticationModel.Authenticated, "1")
                .With(authenticationModel => authenticationModel.AuthenticationDateTime, DateTime.Now.ToString())
                .With(authenticationModel => authenticationModel.Status, "1")
                .With(authenticationModel => authenticationModel.HostedServerName, Faker.Name.First())
                .Create<AuthenticationModel>();

            // Act
            authenticationRepository.Insert(authenticationModel);

            // Assert
            mockLogger.Verify(x => x.Trace("Authentication_Insert"), Times.Exactly(1));
        }

        [TestMethod]
        public void Insert_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Authentication_Insert")).Throws(new ArgumentNullException());
            AuthenticationRepository authenticationRepository = new AuthenticationRepository(mockLogger.Object);
            Fixture fixture = new Fixture();
            AuthenticationModel authenticationModel = fixture.Build<AuthenticationModel>()
                .With(authenticationModel => authenticationModel.Id, Faker.RandomNumber.Next(1, 1000))
                .With(authenticationModel => authenticationModel.NavigatorUserAgent, "Google Chrome")
                .With(authenticationModel => authenticationModel.ServerInternetProtocol, "8.8.8.8")
                .With(authenticationModel => authenticationModel.ClientInternetProtocol, "7.7.7.7")
                .With(authenticationModel => authenticationModel.Authenticated, "1")
                .With(authenticationModel => authenticationModel.AuthenticationDateTime, DateTime.Now.ToString())
                .With(authenticationModel => authenticationModel.Status, "1")
                .With(authenticationModel => authenticationModel.HostedServerName, Faker.Name.First())
                .Create<AuthenticationModel>();

            // Act
            var resultAction = () => authenticationRepository.Insert(authenticationModel);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("Authentication_Insert"), Times.Exactly(1));
        }
    }
}
