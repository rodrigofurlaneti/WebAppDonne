using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Donne.Domain.CommandModelTest
{
    [TestClass]
    [TestCategory("Donne > Domain > CommandModel")]
    public class CommandModelTest
    {
        [TestMethod]
        public void CommandModel_Tipo_Sucesso()
        {
            // Arrange
            CommandModel commandModel = new CommandModel();
            commandModel.BuyerId = Faker.RandomNumber.Next(0,100);
            commandModel.BuyerName = Faker.Name.FullName();
            commandModel.CommandId = Faker.RandomNumber.Next(0, 100);
            commandModel.UserId = Faker.RandomNumber.Next(0, 100);
            commandModel.UserName = Faker.Name.First();
            commandModel.DateUpdate = DateTime.Now;
            commandModel.DateInsert = DateTime.Now;
            commandModel.Status = true;


            // Act
            // Assert
            Assert.IsNotNull(commandModel);
            Assert.AreEqual(commandModel.BuyerId.GetType(), typeof(int));
            Assert.AreEqual(commandModel.BuyerName.GetType(), typeof(string));
            Assert.AreEqual(commandModel.CommandId.GetType(), typeof(int));
            Assert.AreEqual(commandModel.UserId.GetType(), typeof(int));
            Assert.AreEqual(commandModel.UserName.GetType(), typeof(string));
            Assert.AreEqual(commandModel.DateUpdate.GetType(), typeof(DateTime));
            Assert.AreEqual(commandModel.DateInsert.GetType(), typeof(DateTime));
            Assert.AreEqual(commandModel.Status.GetType(), typeof(bool));
        }

        [TestMethod]
        public void CommandModel_Construtor_Sucesso()
        {
            // Arrange
            int buyerId = Faker.RandomNumber.Next(0, 100);
            string buyerName = Faker.Name.FullName();
            int commandId = Faker.RandomNumber.Next(0, 100);
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            bool status = true;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };

            // Act
            CommandModel commandModel = new CommandModel(commandId, buyerId, buyerName, status, listDateTime,
                userId, userName);

            // Assert
            Assert.IsNotNull(commandModel);
            Assert.AreEqual(buyerId, commandModel.BuyerId);
            Assert.AreEqual(buyerName, commandModel.BuyerName);
            Assert.AreEqual(commandId, commandModel.CommandId);
            Assert.AreEqual(userId, commandModel.UserId);
            Assert.AreEqual(userName, commandModel.UserName);
            Assert.AreEqual(dateInsert, commandModel.DateInsert);
            Assert.AreEqual(dateUpdate, commandModel.DateUpdate);
            Assert.AreEqual(status, commandModel.Status);
        }
    }
}
