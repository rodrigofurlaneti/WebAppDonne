using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Donne.Domain.FormOfPaymentModelTest
{
    [TestClass]
    [TestCategory("Donne > Domain > FormOfPaymentModel")]
    public class FormOfPaymentModelTest
    {
        [TestMethod]
        public void FormOfPaymentModel_Tipo_Sucesso()
        {
            // Arrange
            FormOfPaymentModel formOfPaymentModel = new FormOfPaymentModel();
            formOfPaymentModel.FormOfPaymentId = Faker.RandomNumber.Next(0, 100);
            formOfPaymentModel.FormOfPaymentName = Faker.Name.FullName();
            formOfPaymentModel.DateInsert = Faker.Finance.Maturity();
            formOfPaymentModel.DateUpdate = Faker.Finance.Maturity();
            formOfPaymentModel.UserId = Faker.RandomNumber.Next(0, 1000);
            formOfPaymentModel.UserName = Faker.Name.Last();

            // Act
            // Assert
            Assert.IsNotNull(formOfPaymentModel);
            Assert.AreEqual(formOfPaymentModel.FormOfPaymentId.GetType(), typeof(int));
            Assert.AreEqual(formOfPaymentModel.FormOfPaymentName.GetType(), typeof(string));
            Assert.AreEqual(formOfPaymentModel.DateInsert.GetType(), typeof(DateTime));
            Assert.AreEqual(formOfPaymentModel.DateUpdate.GetType(), typeof(DateTime));
            Assert.AreEqual(formOfPaymentModel.UserId.GetType(), typeof(int));
            Assert.AreEqual(formOfPaymentModel.UserName.GetType(), typeof(string));
        }

        [TestMethod]
        public void FormOfPaymentModel_Construtor_Sucesso()
        {
            // Arrange
            int formOfPaymentId = Faker.RandomNumber.Next(0, 100);
            string formOfPaymentName = Faker.Name.FullName();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();

            // Act
            FormOfPaymentModel formOfPaymentModel = new FormOfPaymentModel(formOfPaymentId, 
                formOfPaymentName, dateInsert, dateUpdate, userId, userName);

            // Assert
            Assert.IsNotNull(formOfPaymentModel);
            Assert.AreEqual(formOfPaymentId, formOfPaymentModel.FormOfPaymentId);
            Assert.AreEqual(formOfPaymentName, formOfPaymentModel.FormOfPaymentName);
            Assert.AreEqual(dateInsert, formOfPaymentModel.DateInsert);
            Assert.AreEqual(dateUpdate, formOfPaymentModel.DateUpdate);
            Assert.AreEqual(userId, formOfPaymentModel.UserId);
            Assert.AreEqual(userName, formOfPaymentModel.UserName);
        }
    }
}
