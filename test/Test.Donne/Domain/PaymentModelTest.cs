using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Donne.Domain.PaymentModelTest
{
    [TestClass]
    [TestCategory("Donne > Domain > PaymentModel")]
    public class PaymentModelTest
    {
        [TestMethod][Ignore]
        public void PaymentModel_Tipo_Sucesso()
        {
            // Arrange
            PaymentModel paymentModel = new PaymentModel();
            paymentModel.PaymentId = Faker.RandomNumber.Next(0, 100);
            paymentModel.CommandId = Faker.RandomNumber.Next(0, 100);
            paymentModel.FormOfPaymentId = Faker.RandomNumber.Next(0, 100);
            paymentModel.FormOfPaymentName = Faker.Name.First();
            paymentModel.PaymentAmount = Faker.RandomNumber.Next(0, 1000).ToString();
            paymentModel.PaymentType = Faker.RandomNumber.Next(0, 1000).ToString();
            paymentModel.DateInsert = Faker.Finance.Maturity();
            paymentModel.DateUpdate = Faker.Finance.Maturity();
            paymentModel.UserId = Faker.RandomNumber.Next(0, 1000);
            paymentModel.UserName = Faker.Name.Last();

            // Act
            // Assert
            Assert.IsNotNull(paymentModel);
            Assert.AreEqual(paymentModel.PaymentId.GetType(), typeof(int));
            Assert.AreEqual(paymentModel.CommandId.GetType(), typeof(int));
            Assert.AreEqual(paymentModel.FormOfPaymentId.GetType(), typeof(int));
            Assert.AreEqual(paymentModel.FormOfPaymentName.GetType(), typeof(string));
            Assert.AreEqual(paymentModel.PaymentAmount.GetType(), typeof(string));
            Assert.AreEqual(paymentModel.PaymentType.GetType(), typeof(string));
            Assert.AreEqual(paymentModel.DateInsert.GetType(), typeof(DateTime));
            Assert.AreEqual(paymentModel.DateUpdate.GetType(), typeof(DateTime));
            Assert.AreEqual(paymentModel.UserId.GetType(), typeof(int));
            Assert.AreEqual(paymentModel.UserName.GetType(), typeof(string));
        }

        [TestMethod][Ignore]
        public void OrderModel_Construtor_Sucesso()
        {
            // Arrange
            int paymentId = Faker.RandomNumber.Next(0, 100);
            int commandId = Faker.RandomNumber.Next(0, 100);
            int formOfPaymentId = Faker.RandomNumber.Next(0, 100);
            string formOfPaymentName = Faker.Name.First();
            string paymentAmount = Faker.RandomNumber.Next(0, 1000).ToString();
            string paymentType = Faker.RandomNumber.Next(0, 1000).ToString();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };

            // Act
            PaymentModel paymentModel = new PaymentModel(paymentId, commandId, 
                formOfPaymentId, formOfPaymentName, paymentAmount, paymentType, listDateTime, 
                userId, userName);

            // Assert
            Assert.IsNotNull(paymentModel);
            Assert.AreEqual(paymentId, paymentModel.PaymentId);
            Assert.AreEqual(commandId, paymentModel.CommandId);
            Assert.AreEqual(formOfPaymentId, paymentModel.FormOfPaymentId);
            Assert.AreEqual(formOfPaymentName, paymentModel.FormOfPaymentName);
            Assert.AreEqual(paymentAmount, paymentModel.PaymentAmount);
            Assert.AreEqual(paymentType, paymentModel.PaymentType);
            Assert.AreEqual(dateInsert, paymentModel.DateInsert);
            Assert.AreEqual(dateUpdate, paymentModel.DateUpdate);
            Assert.AreEqual(userId, paymentModel.UserId);
            Assert.AreEqual(userName, paymentModel.UserName);

        }
    }
}
