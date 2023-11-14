using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Donne.Domain.CategoryModelTest
{
    [Ignore] // you can ignore this test
    [TestClass]
    [TestCategory("Donne > Domain > CategoryModel")]
    public class CategoryModelTest
    {
        [TestMethod][Ignore]
        public void CategoryModel_Tipo_Sucesso()
        {
            // Arrange
            CategoryModel categoryModel = new CategoryModel();
            categoryModel.CategoryName = Faker.Name.Last();
            categoryModel.CategoryId = Faker.RandomNumber.Next(0, 100);
            categoryModel.UserName = Faker.Name.First();
            categoryModel.UserId = Faker.RandomNumber.Next(0, 100);
            categoryModel.DateUpdate = DateTime.Now;
            categoryModel.DateInsert = DateTime.Now;
            
            // Act
            // Assert
            Assert.IsNotNull(categoryModel);
            Assert.AreEqual(categoryModel.CategoryName.GetType(), typeof(string));
            Assert.AreEqual(categoryModel.UserName.GetType(), typeof(string));
            Assert.AreEqual(categoryModel.CategoryId.GetType(), typeof(int));
            Assert.AreEqual(categoryModel.UserId.GetType(), typeof(int));
            Assert.AreEqual(categoryModel.DateUpdate.GetType(), typeof(DateTime));
            Assert.AreEqual(categoryModel.DateInsert.GetType(), typeof(DateTime));
        }

        [TestMethod][Ignore]
        public void CategoryModel_Construtor_Sucesso()
        {
            // Arrange
            string categoryName = Faker.Name.Last();
            int categoryId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            int userId = Faker.RandomNumber.Next(0, 100);
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };

            // Act
            CategoryModel categoryModel = new CategoryModel(categoryId, categoryName, listDateTime,
                userId, userName);

            // Assert
            Assert.IsNotNull(categoryModel);
            Assert.AreEqual(categoryModel.CategoryName.GetType(), typeof(string));
            Assert.AreEqual(categoryModel.UserName.GetType(), typeof(string));
            Assert.AreEqual(categoryModel.CategoryId.GetType(), typeof(int));
            Assert.AreEqual(categoryModel.UserId.GetType(), typeof(int));
            Assert.AreEqual(categoryModel.DateUpdate.GetType(), typeof(DateTime));
            Assert.AreEqual(categoryModel.DateInsert.GetType(), typeof(DateTime));
        }
    }
}
