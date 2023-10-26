using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Infrastructure.UserRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > UserRepository")]
    public class UserRepositoryTest
    {
        [TestMethod]
        public void GetAllUsers_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);

            // Act
            var result = userRepository.GetAllUsers();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllUsers"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllUsers_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);

            // Act
            var result = userRepository.GetAllUsers();

            // Assert
            Assert.IsTrue(result.Any());
            mockLogger.Verify(x => x.Trace("GetAllUsers"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetAllUsersAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);

            // Act
            var result = await userRepository.GetAllUsersAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllUserAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllUsersAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetAllUserAsync")).Throws(new Exception());
            UserRepository userRepository = new UserRepository(mockLogger.Object);

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => userRepository.GetAllUsersAsync());
            mockLogger.Verify(x => x.TraceException("GetAllUserAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            var getAll = userRepository.GetAllUsers();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].UserId;

            // Act
            var result = userRepository.GetById(idUltimo);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllUsers"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            var getAll = userRepository.GetAllUsers();
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
            var getAll = await userRepository.GetAllUsersAsync();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].UserId;

            // Act
            var result = await userRepository.GetByIdAsync(idUltimo);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllUserAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetByIdAsync")).Throws(new Exception());
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            var getAll = userRepository.GetAllUsers();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].UserId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => userRepository.GetByIdAsync(idUltimo));
            mockLogger.Verify(x => x.TraceException("GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByName_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            var getAll = userRepository.GetAllUsers();
            string nameUltimo = getAll.ToList()[getAll.Count() - 1].UserName;

            // Act
            var result = userRepository.GetByName(nameUltimo);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllUsers"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByName"), Times.Exactly(1));
        }


        [TestMethod]
        public void GetByName_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            var getAll = userRepository.GetAllUsers();
            string nameUltimo = getAll.ToList()[getAll.Count() - 1].UserName;

            // Act
            var result = userRepository.GetByName(nameUltimo);

            // Assert
            Assert.AreEqual(nameUltimo, result.UserName);
            Assert.IsTrue(result.UserId != 0);
            Assert.IsTrue(result.UserName != string.Empty);
            mockLogger.Verify(x => x.Trace("GetAllUsers"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByName"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByNameAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            var getAll = userRepository.GetAllUsers();
            string nameUltimo = getAll.ToList()[getAll.Count() - 1].UserName;

            // Act
            var result = await userRepository.GetByNameAsync(nameUltimo);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllUsers"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByNameAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByNameAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetByNameAsync")).Throws(new Exception());
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            var getAll = userRepository.GetAllUsers();
            string nameUltimo = getAll.ToList()[getAll.Count() - 1].UserName;

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => userRepository.GetByNameAsync(nameUltimo));
            mockLogger.Verify(x => x.TraceException("GetByNameAsync"), Times.Exactly(1));
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
            bool status = true;
            UserModel userModel = new UserModel(userId, userName,
                userPassword, profileId, profileName, status);

            // Act
            userRepository.Insert(userModel);

            //Assert
            mockLogger.Verify(x => x.Trace("Insert"), Times.Exactly(1));
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
            bool status = true;
            UserModel userModel = new UserModel(userId, userName,
                userPassword, profileId, profileName, status);

            // Act
            await userRepository.InsertAsync(userModel);

            //Assert
            mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void InsertAsync_Sem_Retorno_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("InsertAsync")).Throws(new Exception());
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            int profileId = Faker.RandomNumber.Next(0, 1000);
            string profileName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            string userPassword = Faker.Name.First();
            bool status = true;
            UserModel userModel = new UserModel(userId, userName,
                userPassword, profileId, profileName, status);

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => userRepository.InsertAsync(userModel));
            mockLogger.Verify(x => x.TraceException("InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            var getAll = userRepository.GetAllUsers();
            int userId = getAll.ToList()[getAll.Count() - 1].UserId;
            string profileName = Faker.Name.First();
            int profileId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            string userPassword = Faker.Name.First();
            bool status = true;
            UserModel userModel = new UserModel(userId, userName,
                userPassword, profileId, profileName, status);

            // Act
            userRepository.Update(userModel);

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllUsers"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Update"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            var getAll = userRepository.GetAllUsers();
            int userId = getAll.ToList()[getAll.Count() - 1].UserId;
            string profileName = Faker.Name.First();
            int profileId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            string userPassword = Faker.Name.First();
            bool status = true;
            UserModel userModel = new UserModel(userId, userName,
                userPassword, profileId, profileName, status);

            // Act
            await userRepository.UpdateAsync(userModel);

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllUsers"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void UpdateAsync_Sem_Retorno_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("UpdateAsync")).Throws(new Exception());
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            var getAll = userRepository.GetAllUsers();
            int userId = getAll.ToList()[getAll.Count() - 1].UserId;
            string profileName = Faker.Name.First();
            int profileId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            string userPassword = Faker.Name.First();
            bool status = true;
            UserModel userModel = new UserModel(userId, userName,
                userPassword, profileId, profileName, status);

            // Act
            //Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => userRepository.UpdateAsync(userModel));
            mockLogger.Verify(x => x.TraceException("UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            var getAll = userRepository.GetAllUsers();
            int userId = getAll.ToList()[getAll.Count() - 1].UserId;

            // Act
            userRepository.Delete(userId);

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllUsers"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Delete"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task DeleteAsync_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            var getAll = userRepository.GetAllUsers();
            int userId = getAll.ToList()[getAll.Count() - 1].UserId;

            // Act
            await userRepository.DeleteAsync(userId);

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllUsers"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void DeleteAsync_Sem_Retorno_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("DeleteAsync")).Throws(new Exception());
            UserRepository userRepository = new UserRepository(mockLogger.Object);
            var getAll = userRepository.GetAllUsers();
            int userId = getAll.ToList()[getAll.Count() - 1].UserId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => userRepository.DeleteAsync(userId));

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllUsers"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("DeleteAsync"), Times.Exactly(1));
        }
    }
}
