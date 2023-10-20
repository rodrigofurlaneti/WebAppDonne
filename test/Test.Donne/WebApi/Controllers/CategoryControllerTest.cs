using Domain.Donne;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Controllers.CategoryControllerTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Controllers > CategoryController")]
    public class CategoryControllerTest
    {
        [TestMethod]
        public async Task GetCategorysAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CategoryController categoryController = new CategoryController(mockLogger.Object);

            // Act
            var result = await categoryController.Get();
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("GetCategorysAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetAllCategorysAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetCategorysAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetCategorysAsync")).Throws(new Exception());
            CategoryController categoryController = new CategoryController(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => categoryController.Get());
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CategoryController categoryController = new CategoryController(mockLogger.Object);
            var getAll = categoryController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listCategorys = objResult.Value as List<CategoryModel>;

            // Act
            var result = await categoryController.Get(listCategorys[0].CategoryId);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("GetCategorysAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetAllCategorysAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            // Setup
            mockLogger.Setup(x => x.Trace("GetByIdAsync")).Throws(new Exception());
            CategoryController categoryController = new CategoryController(mockLogger.Object);
            var getAll = categoryController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listCategorys = objResult.Value as List<CategoryModel>;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => categoryController.Get(listCategorys[0].CategoryId));
        }
    }
}
