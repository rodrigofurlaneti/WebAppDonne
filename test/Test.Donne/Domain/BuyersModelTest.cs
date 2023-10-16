using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Donne.Domain.BuyersModelTest
{
    [TestClass]
    [TestCategory("Donne > Domain > BuyersModel")]
    public class BuyersModelTest
    {
        [TestMethod]
        public void BuyerModel_Tipo_Sucesso()
        {
            // Arrange
            BuyerModel buyerModel = new BuyerModel();
            buyerModel.BuyerAddress = Faker.Address.StreetAddress();
            buyerModel.BuyerName = Faker.Name.FullName();
            buyerModel.UserName = Faker.Name.First();
            buyerModel.BuyerId = Faker.RandomNumber.Next(0, 100);
            buyerModel.Status = true;
            buyerModel.DateUpdate = DateTime.Now;
            buyerModel.DateInsert = DateTime.Now;
            buyerModel.BuyerPhone = Faker.RandomNumber.Next().ToString();
            buyerModel.UserId = Faker.RandomNumber.Next();
                
            // Act
            // Assert
            Assert.IsNotNull(buyerModel);
            Assert.IsNotNull(buyerModel.BuyerAddress);
            Assert.IsNotNull(buyerModel.BuyerName);
            Assert.IsNotNull(buyerModel.UserName);
            Assert.IsNotNull(buyerModel.BuyerId);
            Assert.IsNotNull(buyerModel.Status);
            Assert.IsNotNull(buyerModel.DateUpdate);
            Assert.IsNotNull(buyerModel.DateInsert);
            Assert.IsNotNull(buyerModel.BuyerPhone);
            Assert.IsNotNull(buyerModel.UserId);
            Assert.AreEqual(buyerModel.BuyerAddress.GetType(), typeof(string));
            Assert.AreEqual(buyerModel.BuyerName.GetType(), typeof(string));
            Assert.AreEqual(buyerModel.UserName.GetType(), typeof(string));
            Assert.AreEqual(buyerModel.BuyerId.GetType(), typeof(int));
            Assert.AreEqual(buyerModel.Status.GetType(), typeof(bool));
            Assert.AreEqual(buyerModel.DateUpdate.GetType(), typeof(DateTime));
            Assert.AreEqual(buyerModel.DateInsert.GetType(), typeof(DateTime));
            Assert.AreEqual(buyerModel.BuyerPhone.GetType(), typeof(string));
            Assert.AreEqual(buyerModel.UserId.GetType(), typeof(int));
        }

        [TestMethod]
        public void BuyerModel_Construtor_Sucesso()
        {
            // Arrange
            string buyerAddress = Faker.Address.StreetAddress();
            string buyerName = Faker.Name.FullName();
            string userName = Faker.Name.First();
            int buyerId = Faker.RandomNumber.Next(0, 100);
            bool status = true;
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            string buyerPhone = Faker.RandomNumber.Next().ToString();
            int userId = Faker.RandomNumber.Next();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };

            // Act
            BuyerModel buyerModel = new BuyerModel(buyerId, buyerName, buyerPhone, buyerAddress, status, 
                listDateTime, userId, userName);

            // Assert
            Assert.IsNotNull(buyerModel);
            Assert.IsNotNull(buyerModel.BuyerAddress);
            Assert.IsNotNull(buyerModel.BuyerName);
            Assert.IsNotNull(buyerModel.UserName);
            Assert.IsNotNull(buyerModel.BuyerId);
            Assert.IsNotNull(buyerModel.Status);
            Assert.IsNotNull(buyerModel.DateUpdate);
            Assert.IsNotNull(buyerModel.DateInsert);
            Assert.IsNotNull(buyerModel.BuyerPhone);
            Assert.IsNotNull(buyerModel.UserId);
            Assert.IsNotNull(buyerModel.UserName);
            Assert.AreEqual(buyerModel.BuyerAddress, buyerAddress);
            Assert.AreEqual(buyerModel.BuyerName, buyerName);
            Assert.AreEqual(buyerModel.UserName, userName);
            Assert.AreEqual(buyerModel.BuyerId, buyerId);
            Assert.AreEqual(buyerModel.Status, status);
            Assert.AreEqual(buyerModel.DateUpdate, dateUpdate);
            Assert.AreEqual(buyerModel.DateInsert, dateInsert);
            Assert.AreEqual(buyerModel.BuyerPhone, buyerPhone);
            Assert.AreEqual(buyerModel.UserId, userId);
        }
    }
}
