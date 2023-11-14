using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Donne.Domain.CommandOrderModelTest
{
    [Ignore]
    [TestClass]
    [TestCategory("Donne > Domain > CommandOrderModel")]
    public class CommandOrderModelTest
    {
        [TestMethod][Ignore]
        public void CommandOrderModel_Tipo_Sucesso()
        {
            // Arrange
            CommandOrderModel commandOrderModel = new CommandOrderModel();
            commandOrderModel.BuyerId = Faker.RandomNumber.Next(0, 100);
            commandOrderModel.BuyerName = Faker.Name.FullName();
            commandOrderModel.CommandId = Faker.RandomNumber.Next(0, 100);
            commandOrderModel.ProductId = Faker.RandomNumber.Next(0, 100);
            commandOrderModel.ProductName = Faker.Name.First();
            commandOrderModel.Amount = Faker.RandomNumber.Next(0, 1000);
            commandOrderModel.SalePrice = Faker.RandomNumber.Next(0, 1000).ToString();
            commandOrderModel.TotalSalePrice = Faker.RandomNumber.Next(0, 1000).ToString();

            // Act
            // Assert
            Assert.IsNotNull(commandOrderModel);
            Assert.AreEqual(commandOrderModel.BuyerId.GetType(), typeof(int));
            Assert.AreEqual(commandOrderModel.BuyerName.GetType(), typeof(string));
            Assert.AreEqual(commandOrderModel.CommandId.GetType(), typeof(int));
            Assert.AreEqual(commandOrderModel.ProductId.GetType(), typeof(int));
            Assert.AreEqual(commandOrderModel.ProductName.GetType(), typeof(string));
            Assert.AreEqual(commandOrderModel.SalePrice.GetType(), typeof(string));
            Assert.AreEqual(commandOrderModel.TotalSalePrice.GetType(), typeof(string));
        }

        [TestMethod][Ignore]
        public void CommandOrderModel_Construtor_Sucesso()
        {
            // Arrange
            int buyerId = Faker.RandomNumber.Next(0, 100);
            string buyerName = Faker.Name.FullName();
            int commandId = Faker.RandomNumber.Next(0, 100);
            int productId = Faker.RandomNumber.Next(0, 100);
            string productName = Faker.Name.First();
            int amount = Faker.RandomNumber.Next(0, 1000);
            string salePrice = Faker.RandomNumber.Next(0, 1000).ToString();
            string totalSalePrice = Faker.RandomNumber.Next(0, 1000).ToString();
            List<string> listStrings = new List<string>() { buyerName, productName, salePrice, totalSalePrice };

            // Act
            CommandOrderModel commandOrderModel = new CommandOrderModel(commandId, buyerId, listStrings, productId, 
                amount);

            // Assert
            Assert.IsNotNull(commandOrderModel);
            Assert.AreEqual(buyerId, commandOrderModel.BuyerId);
            Assert.AreEqual(buyerName, commandOrderModel.BuyerName);
            Assert.AreEqual(commandId, commandOrderModel.CommandId);
            Assert.AreEqual(productId, commandOrderModel.ProductId);
            Assert.AreEqual(productName, commandOrderModel.ProductName);
            Assert.AreEqual(salePrice, commandOrderModel.SalePrice);
            Assert.AreEqual(totalSalePrice, commandOrderModel.TotalSalePrice);
        }
    }
}
