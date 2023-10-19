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
        public void GetAllUser_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);

            // Act
            var result = userRepository.GetAllUsers();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAllProfile_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            UserRepository userRepository = new UserRepository(mockLogger.Object);

            // Act
            var result = userRepository.GetAllUsers();

            // Assert
            Assert.IsTrue(result.Any());
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
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(1));
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
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(2));
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
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
