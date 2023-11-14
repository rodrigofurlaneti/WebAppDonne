using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Infrastructure.ProfileRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > ProfileRepository")]
    public class ProfileRepositoryTest
    {
        [TestMethod][Ignore]
        public void GetAllProfiles_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);

            // Act
            var result = profileRepository.GetAllProfiles();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllProfiles"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public void GetAllProfiles_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);

            // Act
            var result = profileRepository.GetAllProfiles();

            // Assert
            Assert.IsTrue(result.Any());
            mockLogger.Verify(x => x.Trace("GetAllProfiles"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public async Task GetAllProfilesAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);

            // Act
            var result = await profileRepository.GetAllProfilesAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllProfilesAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public void GetAllProfilesAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace("GetAllProfilesAsync")).Throws(new Exception());
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => profileRepository.GetAllProfilesAsync());
            mockLogger.Verify(x => x.TraceException("GetAllProfilesAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);

            // Setup
            var getAll = profileRepository.GetAllProfiles();
            if (!getAll.Equals(null))
                id = getAll.ToList()[0].ProfileId;

            // Act
            var result = await profileRepository.GetByIdAsync(id);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace("GetByIdAsync")).Throws(new Exception());
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);

            // Setup
            var getAll = profileRepository.GetAllProfiles();
            if (!getAll.Equals(null))
                id = getAll.ToList()[0].ProfileId;

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => profileRepository.GetByIdAsync(id));
            mockLogger.Verify(x => x.TraceException("GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public void GetById_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);
            var getAll = profileRepository.GetAllProfiles();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].ProfileId;

            // Act
            var result = profileRepository.GetById(idUltimo);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllProfiles"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetById"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public void GetById_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);
            var getAll = profileRepository.GetAllProfiles();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].ProfileId;

            // Act
            var result = profileRepository.GetById(idUltimo);

            // Assert
            Assert.IsTrue(result.ProfileName != string.Empty);
            Assert.IsTrue(result.UserName != string.Empty);
            Assert.IsTrue(result.ProfileId != 0);
            Assert.IsTrue(result.UserId != 0);
            mockLogger.Verify(x => x.Trace("GetAllProfiles"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetById"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
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
            mockLogger.Verify(x => x.Trace("Insert"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
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
            mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public void InsertAsync_Sem_Retorno_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("InsertAsync")).Throws(new Exception());
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
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => profileRepository.InsertAsync(profileModel));
            mockLogger.Verify(x => x.TraceException("InsertAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public void Update_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);
            var getAll = profileRepository.GetAllProfiles();
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
            mockLogger.Verify(x => x.Trace("GetAllProfiles"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Update"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public async Task UpdateAsync_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);
            var getAll = profileRepository.GetAllProfiles();
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
            mockLogger.Verify(x => x.Trace("GetAllProfiles"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public void UpdateAsync_Sem_Retorno_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("UpdateAsync")).Throws(new Exception());
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);
            var getAll = profileRepository.GetAllProfiles();
            int profileId = getAll.ToList()[getAll.Count() - 1].ProfileId;
            string profileName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = Faker.Finance.Maturity();
            DateTime dateInsert = getAll.ToList()[getAll.Count() - 1].DateInsert;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            ProfileModel profileModel = new ProfileModel(profileId, profileName, listDateTime, userId, userName);

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => profileRepository.UpdateAsync(profileModel));
            mockLogger.Verify(x => x.TraceException("UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public void Delete_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);
            var getAll = profileRepository.GetAllProfiles();
            int profileId = getAll.ToList()[getAll.Count() - 1].ProfileId;

            // Act
            profileRepository.Delete(profileId);

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllProfiles"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Delete"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public async Task DeleteAsync_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);
            var getAll = profileRepository.GetAllProfiles();
            int profileId = getAll.ToList()[getAll.Count() - 1].ProfileId;

            // Act
            await profileRepository.DeleteAsync(profileId);

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllProfiles"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public void DeleteAsync_Sem_Retorno_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("DeleteAsync")).Throws(new Exception());
            ProfileRepository profileRepository = new ProfileRepository(mockLogger.Object);
            var getAll = profileRepository.GetAllProfiles();
            int profileId = getAll.ToList()[getAll.Count() - 1].ProfileId;

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => profileRepository.DeleteAsync(profileId));
            mockLogger.Verify(x => x.TraceException("DeleteAsync"), Times.Exactly(1));
        }

    }
}
