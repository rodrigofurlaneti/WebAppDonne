using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Controllers.ProfileControllerTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Controllers > ProfileController")]
    public class ProfileControllerTest
    {
        [TestMethod]
        public async Task GetProfileAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            ProfileController profileController = new ProfileController(mockLogger.Object);

            // Act
            var result = await profileController.Get();
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("GetProfileAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetAllProfilesAsync"), Times.Exactly(1));
        }
    }
}
