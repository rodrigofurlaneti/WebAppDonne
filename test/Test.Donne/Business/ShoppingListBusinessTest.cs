
using AutoFixture;
using Business.Donne;
using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Donne.Business.ShoppingListBusinessTest
{
    [TestClass]
    [TestCategory("Donne > Business > ShoppingListBusiness")]
    public class ShoppingListBusinessTest
    {
        [TestMethod]
        public void ShoppingListBusinessValid_Sucesso()
        {
            //Arrange
            var fixture = new Fixture();
            List<ShoppingListModel> listShoppingListModel = fixture.Create<List<ShoppingListModel>>();

            //Act
            var result = ShoppingListBusiness.ShoppingListBusinessValid(listShoppingListModel);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.First().QuantityToBuy, listShoppingListModel.First().QuantityToBuy);
            Assert.AreEqual(result.First().TotalValueOfLastPurchase, listShoppingListModel.First().TotalValueOfLastPurchase);
        }
    }
}
