using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Donne.Domain.OrderModelTest
{
    [TestClass]
    [TestCategory("Donne > Domain > OrderModel")]
    public class OrderModelTest
    {
        [TestMethod]
        public void OrderModel_Tipo_Sucesso()
        {
            // Arrange
            OrderModel orderModel = new OrderModel();
            orderModel.OrderId = Faker.RandomNumber.Next(0, 100);
            orderModel.CommandId = Faker.RandomNumber.Next(0, 100);
            orderModel.ProductId = Faker.RandomNumber.Next(0, 100);
            orderModel.ProductName = Faker.Name.FullName();
            orderModel.SalePrice = Faker.Name.FullName();
            orderModel.Amount = Faker.RandomNumber.Next(0, 100);
            orderModel.TotalSalePrice = Faker.Name.FullName();
            orderModel.DateInsert = Faker.Finance.Maturity();
            orderModel.DateUpdate = Faker.Finance.Maturity();
            orderModel.UserId = Faker.RandomNumber.Next(0, 1000);
            orderModel.UserName = Faker.Name.Last();

            // Act
            // Assert
            Assert.IsNotNull(orderModel);
            Assert.AreEqual(orderModel.OrderId.GetType(), typeof(int));
            Assert.AreEqual(orderModel.CommandId.GetType(), typeof(int));
            Assert.AreEqual(orderModel.ProductId.GetType(), typeof(int));
            Assert.AreEqual(orderModel.ProductName.GetType(), typeof(string));
            Assert.AreEqual(orderModel.SalePrice.GetType(), typeof(string));
            Assert.AreEqual(orderModel.Amount.GetType(), typeof(int));
            Assert.AreEqual(orderModel.TotalSalePrice.GetType(), typeof(string));
            Assert.AreEqual(orderModel.DateInsert.GetType(), typeof(DateTime));
            Assert.AreEqual(orderModel.DateUpdate.GetType(), typeof(DateTime));
            Assert.AreEqual(orderModel.UserId.GetType(), typeof(int));
            Assert.AreEqual(orderModel.UserName.GetType(), typeof(string));
        }

        [TestMethod]
        public void OrderModel_Construtor_Sucesso()
        {
            // Arrange
            int orderId = Faker.RandomNumber.Next(0, 100);
            int commandId = Faker.RandomNumber.Next(0, 100);
            int productId = Faker.RandomNumber.Next(0, 100);
            string productName = Faker.Name.FullName();
            string buyerName = Faker.Name.FullName();
            string salePrice = Faker.Name.FullName();
            int amount = Faker.RandomNumber.Next(0, 100);
            string totalSalePrice = Faker.Name.FullName();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };

            // Act
            OrderModel orderModel = new OrderModel(orderId, commandId, productId, productName, buyerName, 
                salePrice, amount, totalSalePrice, listDateTime, userId, userName);

            // Assert
            Assert.IsNotNull(orderModel);
            Assert.AreEqual(orderId, orderModel.OrderId);
            Assert.AreEqual(commandId, orderModel.CommandId);
            Assert.AreEqual(productId, orderModel.ProductId);
            Assert.AreEqual(productName, orderModel.ProductName);
            Assert.AreEqual(buyerName, orderModel.BuyerName);
            Assert.AreEqual(salePrice, orderModel.SalePrice);
            Assert.AreEqual(amount, orderModel.Amount);
            Assert.AreEqual(totalSalePrice, orderModel.TotalSalePrice);
            Assert.AreEqual(dateInsert, orderModel.DateInsert);
            Assert.AreEqual(dateUpdate, orderModel.DateUpdate);
            Assert.AreEqual(userId, orderModel.UserId);
            Assert.AreEqual(userName, orderModel.UserName);
        }
    }
}
