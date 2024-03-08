using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure.SeedWork;
using WebApi.Donne.Infrastructure.ShoppingList;

namespace Test.Donne.WebApi.Infrastructure.ShoppingListRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > ShoppingListRepository")]
    public class ShoppingListRepositoryTest
    {
        [TestMethod]
        public void GetAll_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ShoppingListRepository shoppingListRepository = new ShoppingListRepository(mockLogger.Object);

            // Act
            var result = shoppingListRepository.GetAll();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("ShoppingList_GetAll_Entry"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("ShoppingList_GetAll_Exit"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAll_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("ShoppingList_GetAll_Entry")).Throws(new ArgumentNullException());
            ShoppingListRepository shoppingListRepository = new ShoppingListRepository(mockLogger.Object);

            // Act
            Assert.ThrowsException<ArgumentNullException>(() => shoppingListRepository.GetAll());

            // Assert
            mockLogger.Verify(x => x.TraceException("ShoppingList_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetAllAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ShoppingListRepository shoppingListRepository = new ShoppingListRepository(mockLogger.Object);

            // Act
            var result = await shoppingListRepository.GetAllAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("ShoppingList_GetAllAsync_Entry"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("ShoppingList_GetAllAsync_Exit"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("ShoppingList_GetAllAsync_Entry")).Throws(new ArgumentNullException());
            ShoppingListRepository shoppingListRepository = new ShoppingListRepository(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => shoppingListRepository.GetAllAsync());

            // Assert
            mockLogger.Verify(x => x.TraceException("ShoppingList_GetAllAsync"), Times.Exactly(1));
        }
    }
}
