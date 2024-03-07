using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Service;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Service.CommandServiceTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Service > CommandService")]
    public class CommandServiceTest
    {
        [TestMethod]
        public void GetAll_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandService commandService = new CommandService(mockLogger.Object);

            // Act
            var result = commandService.GetAll();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("CommandService_GetAll_Entry"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CommandService_GetAll_Exit"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAll_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("CommandService_GetAll_Entry")).Throws(new ArgumentNullException());
            CommandService commandService = new CommandService(mockLogger.Object);

            // Act
            var resultAction = () => commandService.GetAll();
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("CommandService_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandService commandService = new CommandService(mockLogger.Object);
            var command = commandService.GetAll();

            // Act
            commandService.Update(command.First());

            // Assert
            mockLogger.Verify(x => x.Trace("CommandService_Update_Entry"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CommandService_Update_Exit"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("CommandService_Update_Entry")).Throws(new ArgumentNullException());
            CommandService commandService = new CommandService(mockLogger.Object);
            var command = commandService.GetAll();

            // Act
            var resultAction = () => commandService.Update(command.First());
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("CommandService_Update"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandService commandService = new CommandService(mockLogger.Object);
            var command = await commandService.GetAllAsync();

            // Act
            await commandService.UpdateAsync(command.First());

            // Assert
            mockLogger.Verify(x => x.Trace("CommandService_UpdateAsync_Entry"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CommandService_UpdateAsync_Exit"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("CommandService_UpdateAsync_Entry")).Throws(new ArgumentNullException());
            CommandService commandService = new CommandService(mockLogger.Object);
            var command = await commandService.GetAllAsync();

            // Act
            var resultAction = () => commandService.UpdateAsync(command.First());
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("CommandService_UpdateAsync"), Times.Exactly(1));
        }
    }
}
