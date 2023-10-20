using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Controllers.BuyerControllerTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Controllers > BuyerController")]
    public class BuyerControllerTest
    {
        [TestMethod]
        public void GetBuyers_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerController buyerController = new BuyerController(mockLogger.Object);

            // Act
            var result = buyerController.GetBuyers();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.IsTrue(0 < result.Count());
            mockLogger.Verify(x => x.Trace("GetAllBuyers"), Times.Exactly(1));
        }
    }
}
