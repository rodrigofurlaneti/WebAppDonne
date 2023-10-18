using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Donne.Infrastructure;

namespace Test.Donne.WebApi.Infrastructure.BuyerRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > BuyerRepository")]
    public class BuyerRepositoryTest
    {
        [TestMethod]
        public void GetAllBuyers_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();

            // Act
            var result = buyerRepository.GetAllBuyers();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAllBuyers_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();

            // Act
            var result = buyerRepository.GetAllBuyers();

            // Assert
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void GetByStatus_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();

            // Act
            var result = buyerRepository.GetByStatus(1);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetByStatus_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();

            // Act
            var result = buyerRepository.GetByStatus(1);

            // Assert
            Assert.IsTrue(result.Count() > 0);
            Assert.AreEqual("Marcelo", result.First().BuyerName);
        }
    }
}
