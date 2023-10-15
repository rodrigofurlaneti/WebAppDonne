using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Donne.Domain.LogModelTest
{
    [TestClass]
    [TestCategory("Donne > Domain > LogModelTest")]
    public class LogModelTest
    {
        [TestMethod]
        public void LogModel_Tipo_Sucesso()
        {
            // Arrange
            LogModel logModel = new LogModel();

            // Act
            logModel.DateInsert = Faker.Finance.Maturity();
            logModel.DateUpdate = Faker.Finance.Maturity();
            logModel.UserName = Faker.Name.Last();
            logModel.UserId = Faker.RandomNumber.Next();
                        
            // Assert
            Assert.IsNotNull(logModel);
            Assert.AreEqual(logModel.DateInsert.GetType(), typeof(DateTime));
            Assert.AreEqual(logModel.DateUpdate.GetType(), typeof(DateTime));
            Assert.AreEqual(logModel.UserId.GetType(), typeof(int));
            Assert.AreEqual(logModel.UserName.GetType(), typeof(string));
        }

        [TestMethod]
        public void LogModel_Construtor_Sucesso()
        {
            // Arrange
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            string userName = Faker.Name.Last();
            int userId = Faker.RandomNumber.Next();

            // Act
            LogModel logModel = new LogModel(dateInsert, dateUpdate, userId, userName);

            // Assert
            Assert.IsNotNull(logModel);
            Assert.AreEqual(dateInsert, logModel.DateInsert);
            Assert.AreEqual(dateUpdate, logModel.DateUpdate);
            Assert.AreEqual(userId, logModel.UserId);
            Assert.AreEqual(userName, logModel.UserName);
        }
    }
}
