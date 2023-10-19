using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Infrastructure.CategoryRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > CategoryRepository")]
    public class CategoryRepositoryTest
    {
        [TestMethod]
        public void GetAllCategorys_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CategoryRepository categoryRepository = new CategoryRepository(mockLogger.Object);

            // Act
            var result = categoryRepository.GetAllCategorys();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAllCategorys_Retorno_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CategoryRepository categoryRepository = new CategoryRepository(mockLogger.Object);

            // Act
            var result = categoryRepository.GetAllCategorys();

            // Assert
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetAllCategorys_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace(It.IsAny<string>())).Throws(new ArgumentNullException());
            CategoryRepository categoryRepository = new CategoryRepository(mockLogger.Object);

            // Act
            var resultAction = () => categoryRepository.GetAllCategorys();

            // Assert
            Assert.ThrowsException<ArgumentNullException>(resultAction);
        }

        [TestMethod]
        public void GetById_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CategoryRepository categoryRepository = new CategoryRepository(mockLogger.Object);
            var getAll = categoryRepository.GetAllCategorys();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].CategoryId;

            // Act
            var result = categoryRepository.GetById(idUltimo);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetById_Retorno_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CategoryRepository categoryRepository = new CategoryRepository(mockLogger.Object);
            var getAll = categoryRepository.GetAllCategorys();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].CategoryId;

            // Act
            var result = categoryRepository.GetById(idUltimo);

            // Assert
            Assert.AreEqual(idUltimo, result.CategoryId);
        }

        [TestMethod]
        public void GetById_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace(It.IsAny<string>())).Throws(new ArgumentNullException());
            CategoryRepository categoryRepository = new CategoryRepository(mockLogger.Object);

            // Act
            var resultAction = () => categoryRepository.GetById(0);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(resultAction);
        }

        [TestMethod]
        public void Insert_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CategoryRepository categoryRepository = new CategoryRepository(mockLogger.Object);
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
            categoryRepository.Insert(categoryModel);

            //Assert
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(1));
        }

        [TestMethod]
        public void InsertAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CategoryRepository categoryRepository = new CategoryRepository(mockLogger.Object);
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
            categoryRepository.InsertAsync(categoryModel);

            //Assert
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CategoryRepository categoryRepository = new CategoryRepository(mockLogger.Object);
            var getAll = categoryRepository.GetAllCategorys();
            int categoryId = getAll.ToList()[getAll.Count() - 1].CategoryId;
            string categoryName = Faker.Name.Last();
            string userName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = getAll.ToList()[getAll.Count() - 1].DateInsert;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CategoryModel categoryModel = new CategoryModel(categoryId, categoryName, listDateTime,
                userId, userName);

            // Act
            categoryRepository.Update(categoryModel);

            //Assert
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(2));
        }

        [TestMethod]
        public void UpdateAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CategoryRepository categoryRepository = new CategoryRepository(mockLogger.Object);
            var getAll = categoryRepository.GetAllCategorys();
            int categoryId = getAll.ToList()[getAll.Count() - 1].CategoryId;
            string categoryName = Faker.Name.Last();
            string userName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = getAll.ToList()[getAll.Count() - 1].DateInsert;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CategoryModel categoryModel = new CategoryModel(categoryId, categoryName, listDateTime,
                userId, userName);

            // Act
            categoryRepository.UpdateAsync(categoryModel);

            //Assert
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(2));
        }

        [TestMethod]
        public void Delete_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CategoryRepository categoryRepository = new CategoryRepository(mockLogger.Object);
            var getAll = categoryRepository.GetAllCategorys();
            int categoryId = getAll.ToList()[getAll.Count() - 1].CategoryId;

            // Act
            categoryRepository.Delete(categoryId);

            //Assert
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(2));
        }

        [TestMethod]
        public void DeleteAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CategoryRepository categoryRepository = new CategoryRepository(mockLogger.Object);
            var getAll = categoryRepository.GetAllCategorys();
            int categoryId = getAll.ToList()[getAll.Count() - 1].CategoryId;

            // Act
            categoryRepository.DeleteAsync(categoryId);

            //Assert
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(2));
        }

    }
}
