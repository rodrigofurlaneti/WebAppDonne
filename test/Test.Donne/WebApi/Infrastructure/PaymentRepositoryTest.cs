﻿using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure.Payment;
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
            var result = paymentRepository.GetAll();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Payment_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllPayment_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            PaymentRepository paymentRepository = new PaymentRepository(mockLogger.Object);

            // Act
            var result = paymentRepository.GetAll();

            // Assert
            Assert.IsTrue(result.Any());
            mockLogger.Verify(x => x.Trace("Payment_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetAllPaymentAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            PaymentRepository paymentRepository = new PaymentRepository(mockLogger.Object);

            // Act
            var result = await paymentRepository.GetAllAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Payment_GetAll"), Times.Exactly(0));
        }

        [TestMethod]
        public void GetAllPaymentAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            // Setup
            mockLogger.Setup(x => x.Trace("GetAllAsync")).Throws(new Exception());
            PaymentRepository paymentRepository = new PaymentRepository(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => paymentRepository.GetAllAsync());

            // Assert
            mockLogger.Verify(x => x.TraceException("GetAllAsync"), Times.Exactly(0));
        }

        [TestMethod]
        public void GetById_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            PaymentRepository paymentRepository = new PaymentRepository(mockLogger.Object);
            var getAll = paymentRepository.GetAll();
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
            mockLogger.Verify(x => x.Trace("GetById"), Times.Exactly(1));
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
            mockLogger.Verify(x => x.Trace("Payment_Insert"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            PaymentRepository paymentRepository = new PaymentRepository(mockLogger.Object);
            var getAll = paymentRepository.GetAll();
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
            mockLogger.Verify(x => x.Trace("Payment_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Payment_Update"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            PaymentRepository paymentRepository = new PaymentRepository(mockLogger.Object);
            var getAll = paymentRepository.GetAll();
            int paymentId = getAll.ToList()[getAll.Count() - 1].PaymentId;

            // Act
            paymentRepository.Delete(paymentId);

            // Assert
            mockLogger.Verify(x => x.Trace("Payment_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Payment_Delete"), Times.Exactly(1));
        }
    }
}
