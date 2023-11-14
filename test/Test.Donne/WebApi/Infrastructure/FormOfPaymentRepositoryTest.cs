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
        [TestMethod][Ignore]
        public void GetAllFormOfPayment_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);

            // Act
            var result = formOfPaymentRepository.GetAllFormOfPayment();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllFormOfPayment"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public void GetAllFormOfPayment_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);

            // Act
            var result = formOfPaymentRepository.GetAllFormOfPayment();

            // Assert
            Assert.IsTrue(result.Any());
            mockLogger.Verify(x => x.Trace("GetAllFormOfPayment"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public async Task GetAllFormOfPaymentAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);

            // Act
            var result = await formOfPaymentRepository.GetAllFormOfPaymentAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllFormOfPaymentAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public void GetAllFormOfPaymentAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            // Setup
            mockLogger.Setup(x => x.Trace("GetAllFormOfPaymentAsync")).Throws(new Exception());
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => formOfPaymentRepository.GetAllFormOfPaymentAsync());
            mockLogger.Verify(x => x.TraceException("GetAllFormOfPaymentAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
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

        [TestMethod][Ignore]
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
            mockLogger.Verify(x => x.Trace("GetAllFormOfPayment"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetById"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);
            var getAll = await formOfPaymentRepository.GetAllFormOfPaymentAsync();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].FormOfPaymentId;

            // Act
            var result = await formOfPaymentRepository.GetByIdAsync(idUltimo);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllFormOfPaymentAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetByIdAsync")).Throws(new Exception());
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);
            var getAll = formOfPaymentRepository.GetAllFormOfPayment();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].FormOfPaymentId;

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => formOfPaymentRepository.GetByIdAsync(idUltimo));
            mockLogger.Verify(x => x.TraceException("GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
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
            mockLogger.Verify(x => x.Trace("GetAllFormOfPayment"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetById"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
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

        [TestMethod][Ignore]
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
            mockLogger.Verify(x => x.Trace("Insert"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public async Task InsertAsync_Sucesso()
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
            await formOfPaymentRepository.InsertAsync(formOfPaymentModel);

            //Assert
            mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public void InsertAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("InsertAsync")).Throws(new Exception());
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
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => formOfPaymentRepository.InsertAsync(formOfPaymentModel));
            mockLogger.Verify(x => x.TraceException("InsertAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
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
            mockLogger.Verify(x => x.Trace("GetAllFormOfPayment"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Update"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public async Task UpdateAsync_Sucesso()
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
            await formOfPaymentRepository.UpdateAsync(formOfPaymentModel);

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllFormOfPayment"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public void UpdateAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("UpdateAsync")).Throws(new Exception());
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
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => formOfPaymentRepository.UpdateAsync(formOfPaymentModel));
            mockLogger.Verify(x => x.TraceException("UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
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
            mockLogger.Verify(x => x.Trace("GetAllFormOfPayment"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Delete"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public async Task DeleteAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);
            var getAll = formOfPaymentRepository.GetAllFormOfPayment();
            int formOfPaymentId = getAll.ToList()[getAll.Count() - 1].FormOfPaymentId;

            // Act
            await formOfPaymentRepository.DeleteAsync(formOfPaymentId);

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllFormOfPayment"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod][Ignore]
        public void DeleteAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("DeleteAsync")).Throws(new Exception());
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);
            var getAll = formOfPaymentRepository.GetAllFormOfPayment();
            int formOfPaymentId = getAll.ToList()[getAll.Count() - 1].FormOfPaymentId;

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => formOfPaymentRepository.DeleteAsync(formOfPaymentId));
            mockLogger.Verify(x => x.TraceException("DeleteAsync"), Times.Exactly(1));
        }
    }
}
