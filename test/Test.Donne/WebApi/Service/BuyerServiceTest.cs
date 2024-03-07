using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure.SeedWork;
using WebApi.Donne.Service;
using WebApi.Donne.Service.Buyer;

namespace Test.Donne.WebApi.Service.CommandServiceTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Service > BuyerService")]
    public class BuyerServiceTest
    {
        [TestMethod]
        public void GetAll_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerService buyerService = new BuyerService(mockLogger.Object);

            // Act
            var result = buyerService.GetAll();

            // Assert
            mockLogger.Verify(x => x.Trace("BuyerService_GetAll_Entry"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("BuyerService_GetAll_Exit"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAll_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("BuyerService_GetAll_Entry")).Throws(new ArgumentNullException());
            BuyerService buyerService = new BuyerService(mockLogger.Object);

            // Act
            var resultAction = () => buyerService.GetAll();
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("BuyerService_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerService buyerService = new BuyerService(mockLogger.Object);
            var getAll = buyerService.GetAll();

            // Act
            var result = buyerService.GetById(getAll.First().BuyerId);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("BuyerService_GetById_Entry"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("BuyerService_GetById_Exit"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("BuyerService_GetById_Entry")).Throws(new ArgumentNullException());
            BuyerService buyerService = new BuyerService(mockLogger.Object);
            var getAll = buyerService.GetAll();

            // Act
            var resultAction = () => buyerService.GetById(getAll.First().BuyerId);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("BuyerService_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerService buyerService = new BuyerService(mockLogger.Object);
            var getAll = buyerService.GetAll();

            // Act
            var result = await buyerService.GetByIdAsync(getAll.First().BuyerId);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("BuyerService_GetByIdAsync_Entry"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("BuyerService_GetByIdAsync_Exit"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("BuyerService_GetByIdAsync_Entry")).Throws(new ArgumentNullException());
            BuyerService buyerService = new BuyerService(mockLogger.Object);
            var getAll = buyerService.GetAll();

            // Act
            var resultAction = () => buyerService.GetByIdAsync(getAll.First().BuyerId);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("BuyerService_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerService buyerService = new BuyerService(mockLogger.Object);
            var getAll = buyerService.GetAll();
            var buyerModel = buyerService.GetById(getAll.First().BuyerId);

            // Act
            buyerService.Update(buyerModel);

            // Assert
            mockLogger.Verify(x => x.Trace("BuyerService_Update_Entry"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("BuyerService_Update_Exit"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("BuyerService_Update_Entry")).Throws(new ArgumentNullException());
            BuyerService buyerService = new BuyerService(mockLogger.Object);
            var getAll = buyerService.GetAll();
            var buyerModel = buyerService.GetById(getAll.First().BuyerId);

            // Act
            var resultAction = () => buyerService.Update(buyerModel);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("BuyerService_Update"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerService buyerService = new BuyerService(mockLogger.Object);
            var getAll = buyerService.GetAll();
            var buyerModel = buyerService.GetById(getAll.First().BuyerId);

            // Act
            await buyerService.UpdateAsync(buyerModel);

            // Assert
            mockLogger.Verify(x => x.Trace("BuyerService_UpdateAsync_Entry"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("BuyerService_UpdateAsync_Exit"), Times.Exactly(1));
        }

        [TestMethod]
        public void UpdateAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("BuyerService_UpdateAsync_Entry")).Throws(new ArgumentNullException());
            BuyerService buyerService = new BuyerService(mockLogger.Object);
            var getAll = buyerService.GetAll();
            var buyerModel = buyerService.GetById(getAll.First().BuyerId);

            // Act
            var resultAction = () => buyerService.UpdateAsync(buyerModel);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("BuyerService_UpdateAsync"), Times.Exactly(1));
        }


        [TestMethod]
        public void UpdateCustomersNameInCommand_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerService buyerService = new BuyerService(mockLogger.Object);
            CommandService commandService = new CommandService(mockLogger.Object);
            var getAll = commandService.GetAll();
            var buyerModel = buyerService.GetById(getAll.First().BuyerId);

            // Act
            buyerService.UpdateCustomersNameInCommand(buyerModel);

            // Assert
            mockLogger.Verify(x => x.Trace("BuyerService_UpdateCustomersNameInCommand_Entry"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("BuyerService_UpdateCustomersNameInCommand_Exit"), Times.Exactly(1));
        }

        [TestMethod]
        public void UpdateCustomersNameInCommand_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("BuyerService_UpdateCustomersNameInCommand_Entry")).Throws(new ArgumentNullException());
            BuyerService buyerService = new BuyerService(mockLogger.Object);
            var getAll = buyerService.GetAll();
            BuyerModel buyerModel = new BuyerModel();
            buyerModel.BuyerId = getAll.First().BuyerId;

            // Act
            var resultAction = () => buyerService.UpdateCustomersNameInCommand(buyerModel);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("BuyerService_UpdateCustomersNameInCommand"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateCustomersNameInCommandAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerService buyerService = new BuyerService(mockLogger.Object);
            CommandService commandService = new CommandService(mockLogger.Object);
            var getAll = await commandService.GetAllAsync();
            var buyerModel = await buyerService.GetByIdAsync(getAll.First().BuyerId);

            // Act
            await buyerService.UpdateCustomersNameInCommandAsync(buyerModel);

            // Assert
            mockLogger.Verify(x => x.Trace("BuyerService_UpdateCustomersNameInCommandAsync_Entry"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("BuyerService_UpdateCustomersNameInCommandAsync_Exit"), Times.Exactly(1));
        }

        [TestMethod]
        public void UpdateCustomersNameInCommandAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("BuyerService_UpdateCustomersNameInCommandAsync_Entry")).Throws(new ArgumentNullException());
            BuyerService buyerService = new BuyerService(mockLogger.Object);
            var getAll = buyerService.GetAll();
            BuyerModel buyerModel = new BuyerModel();
            buyerModel.BuyerId = getAll.First().BuyerId;

            // Act
            var resultAction = () => buyerService.UpdateCustomersNameInCommandAsync(buyerModel);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("BuyerService_UpdateCustomersNameInCommandAsync"), Times.Exactly(1));
        }

    }
}
