using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure.FormOfPayment;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Infrastructure.FormOfPaymentRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > FormOfPaymentRepository")]
    public class FormOfPaymentRepositoryTest
    {
        [TestMethod]
        public void GetAll_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);

            // Act
            var result = formOfPaymentRepository.GetAll();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("FormOfPayment_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAll_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);

            // Act
            var result = formOfPaymentRepository.GetAll();

            // Assert
            Assert.IsTrue(result.Any());
            mockLogger.Verify(x => x.Trace("FormOfPayment_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetAllAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);

            // Act
            var result = await formOfPaymentRepository.GetAllAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("FormOfPayment_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            // Setup
            mockLogger.Setup(x => x.Trace("FormOfPayment_GetAllAsync")).Throws(new Exception());
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => formOfPaymentRepository.GetAllAsync());
            mockLogger.Verify(x => x.TraceException("FormOfPayment_GetAllAsync"), Times.Exactly(0));
        }

        [TestMethod]
        public void GetAll_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace(It.IsAny<string>())).Throws(new ArgumentNullException());
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);

            // Act
            var resultAction = () => formOfPaymentRepository.GetAll();

            // Assert
            Assert.ThrowsException<ArgumentNullException>(resultAction);
        }

        [TestMethod]
        public void GetById_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);
            var getAll = formOfPaymentRepository.GetAll();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].FormOfPaymentId;

            // Act
            var result = formOfPaymentRepository.GetById(idUltimo);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("FormOfPayment_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("FormOfPayment_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);
            var getAll = await formOfPaymentRepository.GetAllAsync();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].FormOfPaymentId;

            // Act
            var result = await formOfPaymentRepository.GetByIdAsync(idUltimo);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("FormOfPayment_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("FormOfPayment_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("FormOfPayment_GetByIdAsync")).Throws(new Exception());
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);
            var getAll = formOfPaymentRepository.GetAll();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].FormOfPaymentId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => formOfPaymentRepository.GetByIdAsync(idUltimo));
            
            // Assert
            mockLogger.Verify(x => x.TraceException("FormOfPayment_GetByIdAsync"), Times.Exactly(0));
        }

        [TestMethod]
        public void GetById_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);
            var getAll = formOfPaymentRepository.GetAll();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].FormOfPaymentId;

            // Act
            var result = formOfPaymentRepository.GetById(idUltimo);

            // Assert
            Assert.IsTrue(result.UserName != string.Empty);
            Assert.IsTrue(result.UserId != 0);
            Assert.IsTrue(result.FormOfPaymentName != string.Empty);
            Assert.IsTrue(result.FormOfPaymentId != 0);
            mockLogger.Verify(x => x.Trace("FormOfPayment_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("FormOfPayment_GetById"), Times.Exactly(1));
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
            mockLogger.Verify(x => x.Trace("FormOfPayment_Insert"), Times.Exactly(1));
        }

        [TestMethod]
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
            mockLogger.Verify(x => x.Trace("FormOfPayment_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void InsertAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            int formOfPaymentId = Faker.RandomNumber.Next(0, 100);
            string formOfPaymentName = Faker.Name.FullName();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            FormOfPaymentModel formOfPaymentModel = new FormOfPaymentModel(formOfPaymentId,
                formOfPaymentName, listDateTime, userId, userName);

            // Setup
            mockLogger.Setup(x => x.Trace("FormOfPayment_InsertAsync")).Throws(new Exception());
            mockLogger.Setup(x => x.TraceException("FormOfPayment_InsertAsync")).Throws(new Exception());
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => formOfPaymentRepository.InsertAsync(formOfPaymentModel));

            // Assert
            mockLogger.Verify(x => x.Trace("FormOfPayment_InsertAsync"), Times.Exactly(0));
            mockLogger.Verify(x => x.TraceException("FormOfPayment_InsertAsync"), Times.Exactly(0));
        }

        [TestMethod]
        public void Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);
            var getAll = formOfPaymentRepository.GetAll();
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
            mockLogger.Verify(x => x.Trace("FormOfPayment_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("FormOfPayment_Update"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);
            var getAll = formOfPaymentRepository.GetAll();
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
            mockLogger.Verify(x => x.Trace("FormOfPayment_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("FormOfPayment_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void UpdateAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("FormOfPayment_UpdateAsync")).Throws(new Exception());
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);
            var getAll = formOfPaymentRepository.GetAll();
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
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => formOfPaymentRepository.UpdateAsync(formOfPaymentModel));
            
            // Assert
            mockLogger.Verify(x => x.TraceException("FormOfPayment_UpdateAsync"), Times.Exactly(0));
            mockLogger.Verify(x => x.Trace("FormOfPayment_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("FormOfPayment_UpdateAsync"), Times.Exactly(0));
        }

        [TestMethod]
        public void Delete_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);
            var getAll = formOfPaymentRepository.GetAll();
            int formOfPaymentId = getAll.ToList()[getAll.Count() - 1].FormOfPaymentId;

            // Act
            formOfPaymentRepository.Delete(formOfPaymentId);

            //Assert
            mockLogger.Verify(x => x.Trace("FormOfPayment_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("FormOfPayment_Delete"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task DeleteAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);
            var getAll = formOfPaymentRepository.GetAll();
            int formOfPaymentId = getAll.ToList()[getAll.Count() - 1].FormOfPaymentId;

            // Act
            await formOfPaymentRepository.DeleteAsync(formOfPaymentId);

            //Assert
            mockLogger.Verify(x => x.Trace("FormOfPayment_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("FormOfPayment_DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void DeleteAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("DeleteAsync")).Throws(new Exception());
            FormOfPaymentRepository formOfPaymentRepository = new FormOfPaymentRepository(mockLogger.Object);
            var getAll = formOfPaymentRepository.GetAll();
            int formOfPaymentId = getAll.ToList()[getAll.Count() - 1].FormOfPaymentId;

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => formOfPaymentRepository.DeleteAsync(formOfPaymentId));
            mockLogger.Verify(x => x.Trace("FormOfPayment_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("FormOfPayment_DeleteAsync"), Times.Exactly(0));
        }
    }
}
