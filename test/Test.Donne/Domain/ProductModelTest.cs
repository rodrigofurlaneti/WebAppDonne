using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Donne.Domain.ProductModelTest
{
    [TestClass]
    [TestCategory("Donne > Domain > ProductModel")]
    public class ProductModelTest
    {
        [TestMethod]
        public void ProductModel_Tipo_Sucesso()
        {
            // Arrange
            ProductModel productModel = new ProductModel();
            productModel.ProductId = Faker.RandomNumber.Next(0, 1000);
            productModel.ProductName = Faker.Name.First();
            productModel.CategoryId = Faker.RandomNumber.Next(0, 1000);
            productModel.CategoryName = Faker.Name.First();
            productModel.CostPrice = Faker.RandomNumber.Next(0, 100).ToString();
            productModel.SalePrice = Faker.RandomNumber.Next(0, 100).ToString();
            productModel.QuantityStock = Faker.RandomNumber.Next(0, 100);
            productModel.MinimumStockQuantity = Faker.RandomNumber.Next(0, 100);
            productModel.TotalValueCostOfInventory = Faker.RandomNumber.Next(0, 100).ToString();
            productModel.TotalValueSaleStock = Faker.RandomNumber.Next(0, 100).ToString();
            productModel.NeedToPrint = true;
            productModel.Status = true;
            productModel.UserId = Faker.RandomNumber.Next(0, 100);
            productModel.UserName = Faker.Name.First();
            productModel.DateUpdate = Faker.Finance.Maturity();
            productModel.DateInsert = Faker.Finance.Maturity();

            // Act
            // Assert
            Assert.IsNotNull(productModel);
            Assert.AreEqual(productModel.ProductId.GetType(), typeof(int));
            Assert.AreEqual(productModel.ProductName.GetType(), typeof(string));
            Assert.AreEqual(productModel.CategoryId.GetType(), typeof(int));
            Assert.AreEqual(productModel.CategoryName.GetType(), typeof(string));
            Assert.AreEqual(productModel.CostPrice.GetType(), typeof(string));
            Assert.AreEqual(productModel.SalePrice.GetType(), typeof(string));
            Assert.AreEqual(productModel.QuantityStock.GetType(), typeof(int));
            Assert.AreEqual(productModel.MinimumStockQuantity.GetType(), typeof(int));
            Assert.AreEqual(productModel.TotalValueCostOfInventory.GetType(), typeof(string));
            Assert.AreEqual(productModel.TotalValueSaleStock.GetType(), typeof(string));
            Assert.AreEqual(productModel.NeedToPrint.GetType(), typeof(bool));
            Assert.AreEqual(productModel.Status.GetType(), typeof(bool));
            Assert.AreEqual(productModel.UserId.GetType(), typeof(int));
            Assert.AreEqual(productModel.UserName.GetType(), typeof(string));
            Assert.AreEqual(productModel.DateUpdate.GetType(), typeof(DateTime));
            Assert.AreEqual(productModel.DateInsert.GetType(), typeof(DateTime));
        }

        [TestMethod]
        public void ProductModel_Construtor_Sucesso()
        {
            // Arrange
            int productId = Faker.RandomNumber.Next(0, 1000);
            string productName = Faker.Name.First();
            int categoryId = Faker.RandomNumber.Next(0, 1000);
            string categoryName = Faker.Name.First();
            string costPrice = Faker.RandomNumber.Next(0, 100).ToString();
            string salePrice = Faker.RandomNumber.Next(0, 100).ToString();
            int quantityStock = Faker.RandomNumber.Next(0, 100);
            int minimumStockQuantity = Faker.RandomNumber.Next(0, 100);
            string totalValueCostOfInventory = Faker.RandomNumber.Next(0, 100).ToString();
            string totalValueSaleStock = Faker.RandomNumber.Next(0, 100).ToString();
            bool needToPrint = true;
            bool status = true;
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = Faker.Finance.Maturity();
            DateTime dateInsert = Faker.Finance.Maturity();
            int quantityToBuy = Faker.RandomNumber.Next(0, 100);
            string totalValueOfLastPurchase = Faker.RandomNumber.Next(0, 100).ToString();
            List<string> listString = new List<string>() { productName, categoryName, costPrice, salePrice,
                totalValueCostOfInventory, totalValueSaleStock, userName, totalValueOfLastPurchase };
            List<int> listInts = new List<int>() { productId, categoryId, quantityStock, minimumStockQuantity, 
                userId, quantityToBuy };
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };

            // Act
            ProductModel productModel = new ProductModel(listInts, listString , status, listDateTime, needToPrint);

            // Assert
            Assert.IsNotNull(productModel);
            Assert.AreEqual(productId, productModel.ProductId);
            Assert.AreEqual(productName, productModel.ProductName);
            Assert.AreEqual(categoryId, productModel.CategoryId);
            Assert.AreEqual(categoryName, productModel.CategoryName);
            Assert.AreEqual(costPrice, productModel.CostPrice);
            Assert.AreEqual(salePrice, productModel.SalePrice);
            Assert.AreEqual(quantityStock, productModel.QuantityStock);
            Assert.AreEqual(minimumStockQuantity, productModel.MinimumStockQuantity);
            Assert.AreEqual(totalValueCostOfInventory, productModel.TotalValueCostOfInventory);
            Assert.AreEqual(totalValueSaleStock, productModel.TotalValueSaleStock);
            Assert.AreEqual(needToPrint, productModel.NeedToPrint);
            Assert.AreEqual(status, productModel.Status);
            Assert.AreEqual(userId, productModel.UserId);
            Assert.AreEqual(userName, productModel.UserName);
            Assert.AreEqual(dateUpdate, productModel.DateUpdate);
            Assert.AreEqual(dateInsert, productModel.DateInsert);
        }
    }
}
