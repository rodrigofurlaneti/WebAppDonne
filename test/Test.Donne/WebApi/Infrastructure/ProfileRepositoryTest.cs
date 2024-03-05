using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure.Profile;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Infrastructure.ProfileRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > ProfileRepository")]
    public class ProfileRepositoryTest
    {
        [TestMethod]
        public void GetAll_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);

            // Act
            var result = profileRepository.GetAll();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Profile_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetAllAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);

            // Act
            var result = await profileRepository.GetAllAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Profile_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace("Profile_GetAllAsync")).Throws(new Exception());
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => profileRepository.GetAllAsync());

            // Assert
            mockLogger.Verify(x => x.TraceException("Profile_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);

            // Setup
            var getAll = profileRepository.GetAll();
            if (!getAll.Equals(null))
                id = getAll.ToList()[0].ProfileId;

            // Act
            var result = await profileRepository.GetByIdAsync(id);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Profile_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Profile_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            InsertAsync_Sem_Retorno_Sucesso();
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace("Profile_GetByIdAsync")).Throws(new Exception());
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);

            // Setup
            var getAll = profileRepository.GetAll();
            if (!getAll.Equals(null))
                id = getAll.ToList()[0].ProfileId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => profileRepository.GetByIdAsync(id));

            // Assert
            mockLogger.Verify(x => x.TraceException("Profile_GetByIdAsync"), Times.Exactly(0));
        }

        [TestMethod]
        public void GetById_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            InsertAsync_Sem_Retorno_Sucesso();
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);
            var getAll = profileRepository.GetAll();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].ProfileId;

            // Act
            var result = profileRepository.GetById(idUltimo);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Profile_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Profile_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            InsertAsync_Sem_Retorno_Sucesso();
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);
            var getAll = profileRepository.GetAll();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].ProfileId;

            // Act
            var result = profileRepository.GetById(idUltimo);

            // Assert
            Assert.IsTrue(result.ProfileName != string.Empty);
            Assert.IsTrue(result.UserName != string.Empty);
            Assert.IsTrue(result.ProfileId != 0);
            Assert.IsTrue(result.UserId != 0);
            mockLogger.Verify(x => x.Trace("Profile_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Profile_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public void Insert_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);
            int profileId = Faker.RandomNumber.Next(0, 1000);
            string profileName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = Faker.Finance.Maturity();
            DateTime dateInsert = Faker.Finance.Maturity();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            ProfileModel profileModel = new ProfileModel(profileId, profileName, listDateTime, userId, userName);

            // Act
            profileRepository.Insert(profileModel);

            //Assert
            mockLogger.Verify(x => x.Trace("Profile_Insert"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task InsertAsync_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);
            int profileId = Faker.RandomNumber.Next(0, 1000);
            string profileName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = Faker.Finance.Maturity();
            DateTime dateInsert = Faker.Finance.Maturity();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            ProfileModel profileModel = new ProfileModel(profileId, profileName, listDateTime, userId, userName);

            // Act
            await profileRepository.InsertAsync(profileModel);

            //Assert
            mockLogger.Verify(x => x.Trace("Profile_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void InsertAsync_Sem_Retorno_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Profile_InsertAsync")).Throws(new Exception());
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);
            int profileId = Faker.RandomNumber.Next(0, 1000);
            string profileName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = Faker.Finance.Maturity();
            DateTime dateInsert = Faker.Finance.Maturity();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            ProfileModel profileModel = new ProfileModel(profileId, profileName, listDateTime, userId, userName);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => profileRepository.InsertAsync(profileModel));

            // Assert
            mockLogger.Verify(x => x.TraceException("Profile_InsertAsync"), Times.Exactly(0));
        }

        [TestMethod]
        public void Update_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);
            var getAll = profileRepository.GetAll();
            int profileId = getAll.ToList()[getAll.Count() - 1].ProfileId;
            string profileName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = Faker.Finance.Maturity();
            DateTime dateInsert = getAll.ToList()[getAll.Count() - 1].DateInsert;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            ProfileModel profileModel = new ProfileModel(profileId, profileName, listDateTime, userId, userName);

            // Act
            profileRepository.Update(profileModel);

            //Assert
            mockLogger.Verify(x => x.Trace("Profile_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Profile_Update"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);
            var getAll = profileRepository.GetAll();
            int profileId = getAll.ToList()[getAll.Count() - 1].ProfileId;
            string profileName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = Faker.Finance.Maturity();
            DateTime dateInsert = getAll.ToList()[getAll.Count() - 1].DateInsert;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            ProfileModel profileModel = new ProfileModel(profileId, profileName, listDateTime, userId, userName);

            // Act
            await profileRepository.UpdateAsync(profileModel);

            //Assert
            mockLogger.Verify(x => x.Trace("Profile_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Profile_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void UpdateAsync_Sem_Retorno_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Profile_UpdateAsync")).Throws(new Exception());
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);
            var getAll = profileRepository.GetAll();
            int profileId = getAll.ToList()[getAll.Count() - 1].ProfileId;
            string profileName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = Faker.Finance.Maturity();
            DateTime dateInsert = getAll.ToList()[getAll.Count() - 1].DateInsert;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            ProfileModel profileModel = new ProfileModel(profileId, profileName, listDateTime, userId, userName);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => profileRepository.UpdateAsync(profileModel));

            // Assert
            mockLogger.Verify(x => x.Trace("Profile_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Sem_Retorno_Sucesso()
        {
            // Arrange
            InsertAsync_Sem_Retorno_Sucesso();
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);
            var getAll = profileRepository.GetAll();
            int profileId = getAll.ToList()[getAll.Count() - 1].ProfileId;

            // Act
            profileRepository.Delete(profileId);

            //Assert
            mockLogger.Verify(x => x.Trace("Profile_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Profile_Delete"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task DeleteAsync_Sem_Retorno_Sucesso()
        {
            // Arrange
            InsertAsync_Sem_Retorno_Sucesso();
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);
            var getAll = profileRepository.GetAll();
            int profileId = getAll.ToList()[getAll.Count() - 1].ProfileId;

            // Act
            await profileRepository.DeleteAsync(profileId);

            //Assert
            mockLogger.Verify(x => x.Trace("Profile_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Profile_DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void DeleteAsync_Sem_Retorno_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("DeleteAsync")).Throws(new Exception());
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);
            var getAll = profileRepository.GetAll();
            int profileId = getAll.ToList()[getAll.Count() - 1].ProfileId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => profileRepository.DeleteAsync(profileId));

            // Assert
            mockLogger.Verify(x => x.Trace("Profile_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Profile_DeleteAsync"), Times.Exactly(0));
        }

    }
}
