using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Infrastructure.PaymentRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > PaymentRepository")]
    public class PaymentRepositoryTest
    {
        [TestMethod]
        public void GetAllPayment_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            PaymentRepository paymentRepository = new PaymentRepository(mockLogger.Object);

            // Act
            var result = paymentRepository.GetAllPayments();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAllPayment_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            PaymentRepository paymentRepository = new PaymentRepository(mockLogger.Object);

            // Act
            var result = paymentRepository.GetAllPayments();

            // Assert
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetById_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            PaymentRepository paymentRepository = new PaymentRepository(mockLogger.Object);
            var getAll = paymentRepository.GetAllPayments();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].PaymentId;

            // Act
            var result = paymentRepository.GetById(idUltimo);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.UserName != string.Empty);
            Assert.IsTrue(result.UserId != 0);
            Assert.IsTrue(result.PaymentType != string.Empty);
            Assert.IsTrue(result.PaymentId != 0);
            Assert.IsTrue(result.FormOfPaymentName != string.Empty);
            Assert.IsTrue(result.FormOfPaymentId != 0);
        }

        [TestMethod]
        public void Insert_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            PaymentRepository paymentRepository = new PaymentRepository(mockLogger.Object);
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
            PaymentModel paymentModel = new PaymentModel(paymentId, commandId,
                formOfPaymentId, formOfPaymentName, paymentAmount, paymentType, listDateTime,
                userId, userName);

            // Act
            paymentRepository.Insert(paymentModel);

            // Assert
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            PaymentRepository paymentRepository = new PaymentRepository(mockLogger.Object);
            var getAll = paymentRepository.GetAllPayments();
            int paymentId = getAll.ToList()[getAll.Count() - 1].PaymentId;
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
            PaymentModel paymentModel = new PaymentModel(paymentId, commandId,
                formOfPaymentId, formOfPaymentName, paymentAmount, paymentType, listDateTime,
                userId, userName);

            // Act
            paymentRepository.Update(paymentModel);

            // Assert
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(2));
        }

        [TestMethod]
        public void Delete_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            PaymentRepository paymentRepository = new PaymentRepository(mockLogger.Object);
            var getAll = paymentRepository.GetAllPayments();
            int paymentId = getAll.ToList()[getAll.Count() - 1].PaymentId;

            // Act
            paymentRepository.Delete(paymentId);

            // Assert
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
