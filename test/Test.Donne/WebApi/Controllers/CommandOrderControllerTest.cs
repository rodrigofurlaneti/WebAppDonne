using Domain.Donne;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Controllers.CommandOrderControllerTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Controllers > CommandOrderController")]
    public class CommandOrderControllerTest
    {
        [TestMethod]
        public async Task GetCommandsAsync_Sucesso()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandOrderController commandOrderController = new CommandOrderController(mockLogger.Object);
            CommandController commandController = new CommandController(mockLogger.Object);
            var getAll = commandController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var list = objResult.Value as List<CommandModel>;
            if (list != null)
                id = list[0].CommandId;


            // Act
            var result = await commandOrderController.Get(id);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("GetCommandOrdersByIdAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void GetCommandsAsync_Erro()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            Mock<ILogger> mockOrderLogger = new Mock<ILogger>();
            mockOrderLogger.Setup(x => x.Trace("GetCommandOrdersByIdAsync")).Throws(new Exception());
            CommandOrderController commandOrderController = new CommandOrderController(mockOrderLogger.Object);
            CommandController commandController = new CommandController(mockLogger.Object);
            var getAll = commandController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var list = objResult.Value as List<CommandModel>;
            if (list != null)
                id = list[0].CommandId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => commandOrderController.Get(id));

            // Assert
            mockOrderLogger.Verify(x => x.TraceException("GetCommandOrdersByIdAsync"), Times.Exactly(1));
        }

    }
}
