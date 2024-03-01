using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Donne.Domain.UserModelTest
{
    [TestClass]
    [TestCategory("Donne > Domain > UserModel")]
    public class UserModelTest
    {
        [TestMethod]
        public void UserModel_Tipo_Sucesso()
        {
            // Arrange
            UserModel userModel = new UserModel();

            // Act
            userModel.ProfileId = Faker.RandomNumber.Next(0, 1000);
            userModel.ProfileName = Faker.Name.First();
            userModel.UserId = Faker.RandomNumber.Next(0, 100);
            userModel.UserName = Faker.Name.First();
            userModel.UserPassword = Faker.Name.First();
            userModel.Status = 1;
            
            // Assert
            Assert.IsNotNull(userModel);
            Assert.AreEqual(userModel.ProfileId.GetType(), typeof(int));
            Assert.AreEqual(userModel.ProfileName.GetType(), typeof(string));
            Assert.AreEqual(userModel.UserId.GetType(), typeof(int));
            Assert.AreEqual(userModel.UserName.GetType(), typeof(string));
            Assert.AreEqual(userModel.UserPassword.GetType(), typeof(string));
            Assert.AreEqual(userModel.Status.GetType(), typeof(int));
        }

        [TestMethod]
        public void UserModel_Construtor_Sucesso()
        {
            // Arrange
            int profileId = Faker.RandomNumber.Next(0, 1000);
            string profileName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            string userPassword = Faker.Name.First();
            int status = 1;

            // Act
            UserModel userModel = new UserModel(userId, userName, 
                userPassword, profileId, profileName, status);

            // Assert
            Assert.IsNotNull(userModel);
            Assert.AreEqual(profileId, userModel.ProfileId);
            Assert.AreEqual(profileName, userModel.ProfileName);
            Assert.AreEqual(userId, userModel.UserId);
            Assert.AreEqual(userName, userModel.UserName);
            Assert.AreEqual(userPassword, userModel.UserPassword);
            Assert.AreEqual(status, userModel.Status);
        }
    }
}
