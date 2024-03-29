﻿using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure.SeedWork;
using WebApi.Donne.Infrastructure.User;

namespace Test.Donne.WebApi.Infrastructure.UserRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > UserRepository")]
    public class UserRepositoryTest
    {
        [TestMethod]
        public void GetAll_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);

            // Act
            var result = userRepository.GetAll();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllUsers"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetAllAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);

            // Act
            var result = await userRepository.GetAllAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("User_GetAllUserAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("User_GetAllUserAsync")).Throws(new Exception());
            UserRepository userRepository = new UserRepository(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => userRepository.GetAllAsync());

            // Assert
            mockLogger.Verify(x => x.TraceException("User_GetAllUserAsync"), Times.Exactly(0));
        }

        [TestMethod]
        public void GetById_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            var getAll = userRepository.GetAll();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].UserId;

            // Act
            var result = userRepository.GetById(idUltimo);

            // Assert
            Assert.AreEqual(idUltimo, result.UserId);
            Assert.IsTrue(result.UserId != 0);
            Assert.IsTrue(result.UserName != string.Empty);
            mockLogger.Verify(x => x.Trace("GetAllUsers"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            var getAll = await userRepository.GetAllAsync();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].UserId;

            // Act
            var result = await userRepository.GetByIdAsync(idUltimo);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("User_GetAllUserAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("User_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("User_GetByIdAsync")).Throws(new Exception());
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            var getAll = userRepository.GetAll();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].UserId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => userRepository.GetByIdAsync(idUltimo));

            // Assert
            mockLogger.Verify(x => x.TraceException("User_GetByIdAsync"), Times.Exactly(0));
            mockLogger.Verify(x => x.Trace("GetAllUsers"), Times.Exactly(1));
        }

        [TestMethod]
        public void Insert_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            int profileId = Faker.RandomNumber.Next(0, 1000);
            string profileName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            string userPassword = Faker.Name.First();
            int status = 1;
            UserModel userModel = new UserModel(userId, userName,
                userPassword, profileId, profileName, status);

            // Act
            userRepository.Insert(userModel);

            //Assert
            mockLogger.Verify(x => x.Trace("User_Insert"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task InsertAsync_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            int profileId = Faker.RandomNumber.Next(0, 1000);
            string profileName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            string userPassword = Faker.Name.First();
            int status = 1;
            UserModel userModel = new UserModel(userId, userName,
                userPassword, profileId, profileName, status);

            // Act
            await userRepository.InsertAsync(userModel);

            //Assert
            mockLogger.Verify(x => x.Trace("User_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void InsertAsync_Sem_Retorno_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("User_InsertAsync")).Throws(new Exception());
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            int profileId = Faker.RandomNumber.Next(0, 1000);
            string profileName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            string userPassword = Faker.Name.First();
            int status = 1;
            UserModel userModel = new UserModel(userId, userName,
                userPassword, profileId, profileName, status);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => userRepository.InsertAsync(userModel));

            // Assert
            mockLogger.Verify(x => x.TraceException("User_InsertAsync"), Times.Exactly(0));
        }

        [TestMethod]
        public void Update_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            var getAll = userRepository.GetAll();
            int userId = getAll.ToList()[getAll.Count() - 1].UserId;
            string profileName = Faker.Name.First();
            int profileId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            string userPassword = Faker.Name.First();
            int status = 1;
            UserModel userModel = new UserModel(userId, userName,
                userPassword, profileId, profileName, status);

            // Act
            userRepository.Update(userModel);

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllUsers"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("User_Update"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            var getAll = userRepository.GetAll();
            int userId = getAll.ToList()[getAll.Count() - 1].UserId;
            string profileName = Faker.Name.First();
            int profileId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            string userPassword = Faker.Name.First();
            int status = 1;
            UserModel userModel = new UserModel(userId, userName,
                userPassword, profileId, profileName, status);

            // Act
            await userRepository.UpdateAsync(userModel);

            //Assert
            mockLogger.Verify(x => x.Trace("User_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void UpdateAsync_Sem_Retorno_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("User_UpdateAsync")).Throws(new Exception());
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            var getAll = userRepository.GetAll();
            int userId = getAll.ToList()[getAll.Count() - 1].UserId;
            string profileName = Faker.Name.First();
            int profileId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            string userPassword = Faker.Name.First();
            int status = 1;
            UserModel userModel = new UserModel(userId, userName,
                userPassword, profileId, profileName, status);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => userRepository.UpdateAsync(userModel));

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllUsers"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            var getAll = userRepository.GetAll();
            int userId = getAll.ToList()[getAll.Count() - 1].UserId;

            // Act
            userRepository.Delete(userId);

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllUsers"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("User_Delete"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task DeleteAsync_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            var getAll = userRepository.GetAll();
            int userId = getAll.ToList()[getAll.Count() - 1].UserId;

            // Act
            await userRepository.DeleteAsync(userId);

            mockLogger.Verify(x => x.Trace("GetAllUsers"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("User_DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void DeleteAsync_Sem_Retorno_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("User_DeleteAsync")).Throws(new Exception());
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            var getAll = userRepository.GetAll();
            int userId = getAll.ToList()[getAll.Count() - 1].UserId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => userRepository.DeleteAsync(userId));

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllUsers"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("User_DeleteAsync"), Times.Exactly(1));
        }
    }
}
