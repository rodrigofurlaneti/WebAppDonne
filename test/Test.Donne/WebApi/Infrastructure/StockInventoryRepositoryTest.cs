using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure.SeedWork;
using WebApi.Donne.Infrastructure.StockInventory;

namespace Test.Donne.WebApi.Infrastructure
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > StockInventoryRepository")]
    public class StockInventoryRepositoryTest
    {
        [TestMethod]
        public async Task GetAll_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            StockInventoryRepository shoppingListRepository = new StockInventoryRepository(mockLogger.Object);

            // Act
            var result = shoppingListRepository.GetAll();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("StockInventory_GetAll_Entry"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("StockInventory_GetAll_Exit"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAll_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("StockInventory_GetAll_Entry")).Throws(new ArgumentNullException());
            StockInventoryRepository shoppingListRepository = new StockInventoryRepository(mockLogger.Object);

            // Act
            Assert.ThrowsException<ArgumentNullException>(() => shoppingListRepository.GetAll());

            // Assert
            mockLogger.Verify(x => x.TraceException("StockInventory_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetAllAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            StockInventoryRepository shoppingListRepository = new StockInventoryRepository(mockLogger.Object);

            // Act
            var result = await shoppingListRepository.GetAllAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("StockInventory_GetAllAsync_Entry"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("StockInventory_GetAllAsync_Exit"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("StockInventory_GetAllAsync_Entry")).Throws(new ArgumentNullException());
            StockInventoryRepository shoppingListRepository = new StockInventoryRepository(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => shoppingListRepository.GetAllAsync());

            // Assert
            mockLogger.Verify(x => x.TraceException("StockInventory_GetAllAsync"), Times.Exactly(1));
        }
    }
}
