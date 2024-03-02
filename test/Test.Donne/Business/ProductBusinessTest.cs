using AutoFixture;
using Business.Donne;
using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Donne.Business.ProductBusinessTest
{
    [TestClass]
    [TestCategory("Donne > Business > ProductBusiness")]
    public class ProductBusinessTest
    {
        [TestMethod]
        public void ProductModelValid_Sucesso()
        {
            // Arrange
            var fixture = new Fixture();
            var productModel = fixture.Build<ProductModel>()
                                      .With(productModel => productModel.SalePrice, Faker.Finance.Coupon().ToString())
                                      .With(productModel => productModel.CostPrice, Faker.Finance.Coupon().ToString())
                                      .With(productModel => productModel.CategoryName, Faker.Name.First())
                                      .With(productModel => productModel.ProductName, Faker.Name.First())
                                      .With(productModel => productModel.MinimumStockQuantity, Faker.RandomNumber.Next(11, 20))
                                      .With(productModel => productModel.QuantityStock, Faker.RandomNumber.Next(1, 10))
                                      .Create();

            var quantityToBuy = productModel.MinimumStockQuantity - productModel.QuantityStock;
            var valueOfLastPurchase = quantityToBuy * Convert.ToDecimal(productModel.CostPrice);

            //Act
            ProductBusiness.ProductModelValid(productModel);

            //Assert
            Assert.AreEqual(quantityToBuy, productModel.QuantityToBuy);
            Assert.AreEqual(valueOfLastPurchase.ToString(), productModel.TotalValueOfLastPurchase);
        }
    }
}
