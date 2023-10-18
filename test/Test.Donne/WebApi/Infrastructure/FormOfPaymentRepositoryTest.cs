using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Infrastructure.FormOfPaymentRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > FormOfPaymentRepository")]
    public class FormOfPaymentRepositoryTest
    {
        [TestMethod]
        public void GetAllFormOfPayment_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);

            // Act
            var result = formOfPaymentRepository.GetAllFormOfPayment();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAllFormOfPayment_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);

            // Act
            var result = formOfPaymentRepository.GetAllFormOfPayment();

            // Assert
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetAllFormOfPayment_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace(It.IsAny<string>())).Throws(new ArgumentNullException());
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);

            // Act
            var resultAction = () => formOfPaymentRepository.GetAllFormOfPayment();

            // Assert
            Assert.ThrowsException<ArgumentNullException>(resultAction);
        }

        [TestMethod]
        public void GetById_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);
            var getAll = formOfPaymentRepository.GetAllFormOfPayment();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].FormOfPaymentId;

            // Act
            var result = formOfPaymentRepository.GetById(idUltimo);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetById_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);
            var getAll = formOfPaymentRepository.GetAllFormOfPayment();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].FormOfPaymentId;

            // Act
            var result = formOfPaymentRepository.GetById(idUltimo);

            // Assert
            Assert.IsTrue(result.UserName != string.Empty);
            Assert.IsTrue(result.UserId != 0);
            Assert.IsTrue(result.FormOfPaymentName != string.Empty);
            Assert.IsTrue(result.FormOfPaymentId != 0);
        }

        [TestMethod]
        public void GetById_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace(It.IsAny<string>())).Throws(new ArgumentNullException());
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);

            // Act
            var resultAction = () => formOfPaymentRepository.GetById(0);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(resultAction);
        }

        [TestMethod]
        public void Insert_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);
            int formOfPaymentId = Faker.RandomNumber.Next(0, 100);
            string formOfPaymentName = Faker.Name.FullName();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            FormOfPaymentModel formOfPaymentModel = new FormOfPaymentModel(formOfPaymentId,
                formOfPaymentName, listDateTime, userId, userName);

            // Act
            formOfPaymentRepository.Insert(formOfPaymentModel);

            //Assert
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(1));
        }

        [TestMethod]
        public void InsertAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);
            int formOfPaymentId = Faker.RandomNumber.Next(0, 100);
            string formOfPaymentName = Faker.Name.FullName();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            FormOfPaymentModel formOfPaymentModel = new FormOfPaymentModel(formOfPaymentId,
                formOfPaymentName, listDateTime, userId, userName);

            // Act
            formOfPaymentRepository.InsertAsync(formOfPaymentModel);

            //Assert
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);
            var getAll = formOfPaymentRepository.GetAllFormOfPayment();
            int formOfPaymentId = getAll.ToList()[getAll.Count() - 1].FormOfPaymentId;
            string formOfPaymentName = Faker.Name.FullName();
            DateTime dateInsert = getAll.ToList()[getAll.Count() - 1].DateInsert;
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            FormOfPaymentModel formOfPaymentModel = new FormOfPaymentModel(formOfPaymentId,
                formOfPaymentName, listDateTime, userId, userName);

            // Act
            formOfPaymentRepository.Update(formOfPaymentModel);

            //Assert
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(2));
        }

        [TestMethod]
        public void UpdateAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);
            var getAll = formOfPaymentRepository.GetAllFormOfPayment();
            int formOfPaymentId = getAll.ToList()[getAll.Count() - 1].FormOfPaymentId;
            string formOfPaymentName = Faker.Name.FullName();
            DateTime dateInsert = getAll.ToList()[getAll.Count() - 1].DateInsert;
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            FormOfPaymentModel formOfPaymentModel = new FormOfPaymentModel(formOfPaymentId,
                formOfPaymentName, listDateTime, userId, userName);

            // Act
            formOfPaymentRepository.UpdateAsync(formOfPaymentModel);

            //Assert
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(2));
        }

        [TestMethod]
        public void Delete_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);
            var getAll = formOfPaymentRepository.GetAllFormOfPayment();
            int formOfPaymentId = getAll.ToList()[getAll.Count() - 1].FormOfPaymentId;

            // Act
            formOfPaymentRepository.Delete(formOfPaymentId);

            //Assert
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(2));
        }

        [TestMethod]
        public void DeleteAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);
            var getAll = formOfPaymentRepository.GetAllFormOfPayment();
            int formOfPaymentId = getAll.ToList()[getAll.Count() - 1].FormOfPaymentId;

            // Act
            formOfPaymentRepository.DeleteAsync(formOfPaymentId);

            //Assert
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
