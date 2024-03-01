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
            mockLogger.Verify(x => x.Trace("Category_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetCategorysAsync"), Times.Exactly(1));
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
            await InsertAsync_Sucesso();
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CategoryController categoryController = new CategoryController(mockLogger.Object);
            var getAll = categoryController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listCategorys = objResult.Value as List<CategoryModel>;
            if (listCategorys != null)
                id = listCategorys[0].CategoryId;

            // Act
            var result = await categoryController.Get(id);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);

            mockLogger.Verify(x => x.Trace("Category_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetCategorysAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Category_GetByIdAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            InsertAsync_Sucesso();
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            // Setup
            mockLogger.Setup(x => x.Trace("GetByIdAsync")).Throws(new Exception());
            CategoryController categoryController = new CategoryController(mockLogger.Object);
            var getAll = categoryController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listCategorys = objResult.Value as List<CategoryModel>;
            if (listCategorys != null)
                id = listCategorys[0].CategoryId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => categoryController.Get(id));
        }

        [TestMethod]
        public async Task InsertAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CategoryController categoryController = new CategoryController(mockLogger.Object);
            string categoryName = Faker.Name.Last();
            int categoryId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CategoryModel categoryModel = new CategoryModel(categoryId, categoryName, listDateTime,
                userId, userName);


            // Act
            await categoryController.Post(categoryModel);

            // Assert
            mockLogger.Verify(x => x.Trace("Category_InsertAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void InsertAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            string categoryName = Faker.Name.Last();
            int categoryId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CategoryModel categoryModel = new CategoryModel(categoryId, categoryName, listDateTime,
                userId, userName);

            mockLogger.Setup(x => x.Trace("InsertAsync")).Throws(new Exception());
            CategoryController categoryController = new CategoryController(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => categoryController.Post(categoryModel));

            // Assert
            mockLogger.Verify(x => x.Trace("Category_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Sucesso()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CategoryController categoryController = new CategoryController(mockLogger.Object);
            var getAll = categoryController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listCategorys = objResult.Value as List<CategoryModel>;
            if (listCategorys != null)
                id = listCategorys[0].CategoryId;
            string categoryName = Faker.Name.Last();
            string userName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CategoryModel categoryModel = new CategoryModel(id, categoryName, listDateTime,
                userId, userName);


            // Act
            await categoryController.Update(categoryModel);

            // Assert
            mockLogger.Verify(x => x.Trace("Category_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetCategorysAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Category_UpdateAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void UpdateAsync_Erro()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("UpdateAsync")).Throws(new Exception());
            CategoryController categoryController = new CategoryController(mockLogger.Object);
            var getAll = categoryController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listCategorys = objResult.Value as List<CategoryModel>;
            if (listCategorys != null)
                id = listCategorys[0].CategoryId;
            string categoryName = Faker.Name.Last();
            string userName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CategoryModel categoryModel = new CategoryModel(id, categoryName, listDateTime,
                userId, userName);


            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => categoryController.Update(categoryModel));

            // Assert
            mockLogger.Verify(x => x.Trace("Category_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetCategorysAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Category_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task DeleteAsync_Sucesso()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CategoryController categoryController = new CategoryController(mockLogger.Object);
            var getAll = categoryController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listCategorys = objResult.Value as List<CategoryModel>;
            if (listCategorys != null)
                id = listCategorys[0].CategoryId;

            // Act
            await categoryController.Delete(id);

            // Assert
            mockLogger.Verify(x => x.Trace("Category_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetCategorysAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Category_DeleteAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void DeleteAsync_Erro()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("DeleteAsync")).Throws(new Exception());
            CategoryController categoryController = new CategoryController(mockLogger.Object);
            var getAll = categoryController.Get();
            var objResult = (OkObjectResult)getAll.Result;
            var listCategorys = objResult.Value as List<CategoryModel>;
            if (listCategorys != null)
                id = listCategorys[0].CategoryId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => categoryController.Delete(id));

            // Assert
            mockLogger.Verify(x => x.Trace("Category_GetAllAsync"), Times.Exactly(1));
        }

    }
}
