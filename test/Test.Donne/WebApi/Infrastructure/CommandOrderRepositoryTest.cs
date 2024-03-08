using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure.Command;
using WebApi.Donne.Infrastructure.CommandOrder;
using WebApi.Donne.Infrastructure.Order;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Infrastructure
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > CommandOrderRepository")]
    public class CommandOrderRepositoryTest
    {
        [TestMethod]
        public void GetAll_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandOrderRepository commandOrderRepository = new CommandOrderRepository(mockLogger.Object);

            // Act
            var result = commandOrderRepository.GetAll();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("CommandOrder_GetAll_Entry"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CommandOrder_GetAll_Exit"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAll_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("CommandOrder_GetAll_Entry")).Throws(new ArgumentNullException());
            CommandOrderRepository commandOrderRepository = new CommandOrderRepository(mockLogger.Object);

            // Act
            Assert.ThrowsException<ArgumentNullException>(() => commandOrderRepository.GetAll());

            // Assert
            mockLogger.Verify(x => x.TraceException("CommandOrder_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetAllAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandOrderRepository commandOrderRepository = new CommandOrderRepository(mockLogger.Object);

            // Act
            var result = await commandOrderRepository.GetAllAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("CommandOrder_GetAllAsync_Entry"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CommandOrder_GetAllAsync_Exit"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("CommandOrder_GetAllAsync_Entry")).Throws(new ArgumentNullException());
            CommandOrderRepository commandOrderRepository = new CommandOrderRepository(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => commandOrderRepository.GetAllAsync());

            // Assert
            mockLogger.Verify(x => x.TraceException("CommandOrder_GetAllAsync"), Times.Exactly(1));
        }


        [TestMethod]
        public void GetById_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandOrderRepository commandOrderRepository = new CommandOrderRepository(mockLogger.Object);
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAll();

            // Act
            var result = commandOrderRepository.GetById(getAll.First().CommandId);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("CommandOrder_GetById_Entry"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CommandOrder_GetById_Exit"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("CommandOrder_GetById_Entry")).Throws(new ArgumentNullException());
            CommandOrderRepository commandOrderRepository = new CommandOrderRepository(mockLogger.Object);
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAll();

            // Act
            Assert.ThrowsException<ArgumentNullException>(() => commandOrderRepository.GetById(getAll.First().CommandId));

            // Assert
            mockLogger.Verify(x => x.TraceException("CommandOrder_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandOrderRepository commandOrderRepository = new CommandOrderRepository(mockLogger.Object);
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAll();

            // Act
            var result = await commandOrderRepository.GetByIdAsync(getAll.First().CommandId);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("CommandOrder_GetByIdAsync_Entry"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CommandOrder_GetByIdAsync_Exit"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("CommandOrder_GetByIdAsync_Entry")).Throws(new ArgumentNullException());
            CommandOrderRepository commandOrderRepository = new CommandOrderRepository(mockLogger.Object);
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAll();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => commandOrderRepository.GetByIdAsync(getAll.First().CommandId));

            // Assert
            mockLogger.Verify(x => x.TraceException("CommandOrder_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Order_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandOrderRepository commandOrderRepository = new CommandOrderRepository(mockLogger.Object);
            var getAllCommandOrder = commandOrderRepository.GetAll();

            // Act
            var result = commandOrderRepository.GetById(getAllCommandOrder.First().CommandId);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("CommandOrder_GetById_Entry"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CommandOrder_GetById_Exit"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Order_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("CommandOrder_GetById_Entry")).Throws(new ArgumentNullException());
            CommandOrderRepository commandOrderRepository = new CommandOrderRepository(mockLogger.Object);
            var getAllCommandOrder = commandOrderRepository.GetAll();

            // Act
            Assert.ThrowsException<ArgumentNullException>(() => commandOrderRepository.GetById(getAllCommandOrder.First().CommandId));

            // Assert
            mockLogger.Verify(x => x.TraceException("CommandOrder_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Order_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandOrderRepository commandOrderRepository = new CommandOrderRepository(mockLogger.Object);
            var getAllCommandOrder = commandOrderRepository.GetAll();

            // Act
            var result = await commandOrderRepository.GetByIdAsync(getAllCommandOrder.First().CommandId);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("CommandOrder_GetByIdAsync_Entry"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CommandOrder_GetByIdAsync_Exit"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByIdAsync_Order_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("CommandOrder_GetByIdAsync_Entry")).Throws(new ArgumentNullException());
            CommandOrderRepository commandOrderRepository = new CommandOrderRepository(mockLogger.Object);
            var getAllCommandOrder = commandOrderRepository.GetAll();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => commandOrderRepository.GetByIdAsync(getAllCommandOrder.First().CommandId));

            // Assert
            mockLogger.Verify(x => x.TraceException("CommandOrder_GetByIdAsync"), Times.Exactly(1));
        }



    }
}
