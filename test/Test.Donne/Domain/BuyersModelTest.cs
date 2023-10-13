using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Donne.Domain.BuyersModelTest
{
    [TestClass]
    public class BuyersModelTest
    {
        [TestMethod]
        public void BuyerModel_Sucesso()
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
            buyerModel.UserName = Faker.Name.First();
                
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
            Assert.IsNotNull(buyerModel.UserName);
            Assert.AreEqual(buyerModel.BuyerAddress.GetType(), typeof(string));
            Assert.AreEqual(buyerModel.BuyerName.GetType(), typeof(string));
            Assert.AreEqual(buyerModel.UserName.GetType(), typeof(string));
            Assert.AreEqual(buyerModel.BuyerId.GetType(), typeof(int));
            Assert.AreEqual(buyerModel.Status.GetType(), typeof(bool));
            Assert.AreEqual(buyerModel.DateUpdate.GetType(), typeof(DateTime));
            Assert.AreEqual(buyerModel.DateInsert.GetType(), typeof(DateTime));
            Assert.AreEqual(buyerModel.BuyerPhone.GetType(), typeof(string));
            Assert.AreEqual(buyerModel.UserId.GetType(), typeof(int));
            Assert.AreEqual(buyerModel.UserName.GetType(), typeof(string));
        }
    }
}
