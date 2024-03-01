using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Donne.Domain.ProfileModelTest
{
    [TestClass]
    [TestCategory("Donne > Domain > ProfileModel")]
    public class ProfileModelTest
    {
        [TestMethod]
        public void ProfileModel_Tipo_Sucesso()
        {
            // Arrange
            ProfileModel profileModel = new ProfileModel();

            // Act
            profileModel.ProfileId = Faker.RandomNumber.Next(0, 1000);
            profileModel.ProfileName = Faker.Name.First();
            profileModel.UserId = Faker.RandomNumber.Next(0, 100);
            profileModel.UserName = Faker.Name.First();
            profileModel.DateUpdate = Faker.Finance.Maturity();
            profileModel.DateInsert = Faker.Finance.Maturity();

            // Assert
            Assert.IsNotNull(profileModel);
            Assert.AreEqual(profileModel.ProfileId.GetType(), typeof(int));
            Assert.AreEqual(profileModel.ProfileName.GetType(), typeof(string));
            Assert.AreEqual(profileModel.UserId.GetType(), typeof(int));
            Assert.AreEqual(profileModel.UserName.GetType(), typeof(string));
            Assert.AreEqual(profileModel.DateUpdate.GetType(), typeof(DateTime));
            Assert.AreEqual(profileModel.DateInsert.GetType(), typeof(DateTime));
        }

        [TestMethod]
        public void ProfileModel_Construtor_Sucesso()
        {
            // Arrange
            int profileId = Faker.RandomNumber.Next(0, 1000);
            string profileName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = Faker.Finance.Maturity();
            DateTime dateInsert = Faker.Finance.Maturity();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };

            // Act
            ProfileModel profileModel = new ProfileModel(profileId, profileName, listDateTime, userId, userName);

            // Assert
            Assert.IsNotNull(profileModel);
            Assert.AreEqual(profileId, profileModel.ProfileId);
            Assert.AreEqual(profileName, profileModel.ProfileName);
            Assert.AreEqual(userId, profileModel.UserId);
            Assert.AreEqual(userName, profileModel.UserName);
            Assert.AreEqual(dateUpdate, profileModel.DateUpdate);
            Assert.AreEqual(dateInsert, profileModel.DateInsert);
        }
    }
}
