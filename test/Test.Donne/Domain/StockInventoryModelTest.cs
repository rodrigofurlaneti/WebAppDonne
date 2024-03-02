using AutoFixture;
using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Donne.Domain.StockInventoryModelTest
{
    [TestClass]
    [TestCategory("Donne > Domain > StockInventoryModel")]
    public class StockInventoryModelTest
    {
        [TestMethod]
        public void StockInventory_Type_Property_Sucesso()
        {
            //Arrange
            Fixture fixture = new Fixture();

            //Act
            StockInventoryModel stockInventory = fixture.Create<StockInventoryModel>();

            //Assert
            Assert.IsNotNull(stockInventory);
            Assert.AreEqual(stockInventory.TotalValueCostOfInventory.GetType(), typeof(string));
            Assert.AreEqual(stockInventory.TotalValueSaleStock.GetType(), typeof(string));
        }
    }
}
