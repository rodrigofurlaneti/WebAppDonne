using Domain.Donne;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Controllers.ProfileControllerTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Controllers > ProfileController")]
    public class ProfileControllerTest
    {
        [TestMethod]
        public async Task GetProfileAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileController profileController = new ProfileController(mockLogger.Object);

            // Act
            var result = await profileController.Get();
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("GetProfileAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetAllProfilesAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetProfileAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace("GetProfileAsync")).Throws(new Exception());
            ProfileController profileController = new ProfileController(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => profileController.Get());

            //Assert
            mockLogger.Verify(x => x.TraceException("GetProfileAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileController profileController = new ProfileController(mockLogger.Object);
            var getAll = profileController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listProfile = objResult.Value as List<ProfileModel>;
            if (listProfile != null)
                id = listProfile[0].ProfileId;

            // Act
            var result = await profileController.Get(id);
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
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetByIdAsync")).Throws(new Exception());
            ProfileController profileController = new ProfileController(mockLogger.Object);
            var getAll = profileController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listProfile = objResult.Value as List<ProfileModel>;
            if (listProfile != null)
                id = listProfile[0].ProfileId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => profileController.Get(id));

            //Assert
            mockLogger.Verify(x => x.TraceException("GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task InsertAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileController profileController = new ProfileController(mockLogger.Object);
            int profileId = Faker.RandomNumber.Next(0, 1000);
            string profileName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = Faker.Finance.Maturity();
            DateTime dateInsert = Faker.Finance.Maturity();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            ProfileModel profileModel = new ProfileModel(profileId, profileName, listDateTime, userId, userName);


            // Act
            await profileController.Post(profileModel);

            // Assert
            mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void InsertAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("InsertAsync")).Throws(new Exception());
            ProfileController profileController = new ProfileController(mockLogger.Object);
            int profileId = Faker.RandomNumber.Next(0, 1000);
            string profileName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = Faker.Finance.Maturity();
            DateTime dateInsert = Faker.Finance.Maturity();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            ProfileModel profileModel = new ProfileModel(profileId, profileName, listDateTime, userId, userName);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => profileController.Post(profileModel));

            //Assert
            mockLogger.Verify(x => x.TraceException("InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Sucesso()
        {
            // Arrange
            int profileId = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileController profileController = new ProfileController(mockLogger.Object);
            var getAll = profileController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listProfile = objResult.Value as List<ProfileModel>;
            if(listProfile != null)
                profileId = listProfile[0].ProfileId;
            string profileName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = Faker.Finance.Maturity();
            DateTime dateInsert = Faker.Finance.Maturity();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            ProfileModel profileModel = new ProfileModel(profileId, profileName, listDateTime, userId, userName);


            // Act
            await profileController.Update(profileModel);

            // Assert
            mockLogger.Verify(x => x.Trace("UpdateAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void UpdateAsync_Erro()
        {
            // Arrange
            int profileId = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("UpdateAsync")).Throws(new Exception());
            ProfileController profileController = new ProfileController(mockLogger.Object);
            var getAll = profileController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listProfile = objResult.Value as List<ProfileModel>;
            if (listProfile != null)
                profileId = listProfile[0].ProfileId;
            string profileName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = Faker.Finance.Maturity();
            DateTime dateInsert = Faker.Finance.Maturity();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            ProfileModel profileModel = new ProfileModel(profileId, profileName, listDateTime, userId, userName);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => profileController.Update(profileModel));

            //Assert
            mockLogger.Verify(x => x.TraceException("UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task DeleteAsync_Sucesso()
        {
            // Arrange
            int profileId = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileController profileController = new ProfileController(mockLogger.Object);
            var getAll = profileController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listProfile = objResult.Value as List<ProfileModel>;
            if (listProfile != null)
                profileId = listProfile[0].ProfileId;

            // Act
            await profileController.Delete(profileId);

            // Assert
            mockLogger.Verify(x => x.Trace("DeleteAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void DeleteAsync_Erro()
        {
            // Arrange
            int profileId = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("DeleteAsync")).Throws(new Exception());
            ProfileController profileController = new ProfileController(mockLogger.Object);
            var getAll = profileController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listProfile = objResult.Value as List<ProfileModel>;
            if (listProfile != null)
                profileId = listProfile[0].ProfileId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => profileController.Delete(profileId));

            //Assert
            mockLogger.Verify(x => x.TraceException("DeleteAsync"), Times.Exactly(1));
        }
    }
}
