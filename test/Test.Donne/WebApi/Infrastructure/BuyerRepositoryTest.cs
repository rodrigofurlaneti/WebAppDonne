using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Donne.Infrastructure;

namespace Test.Donne.WebApi.Infrastructure.BuyerRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > BuyerRepository")]
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
            Assert.IsNotNull(result);
        }
    }
}
