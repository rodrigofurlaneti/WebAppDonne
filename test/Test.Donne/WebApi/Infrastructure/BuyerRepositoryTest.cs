using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Donne.Infrastructure;

namespace Test.Donne
{
    [TestClass]
    public class BuyerRepositoryTest
    {
        [TestMethod]
        public void GetAllBuyers_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();
            // Act
            var result = buyerRepository.GetAllBuyers();

            // Assert
            Assert.IsNotNull(buyerRepository);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }
    }
}
