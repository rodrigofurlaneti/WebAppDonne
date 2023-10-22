using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Infrastructure.BuyerRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > BuyerRepository")]
    public class BuyerRepositoryTest
    {
        [TestMethod]
        public void GetAllBuyers_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);

            // Act
            var result = buyerRepository.GetAllBuyers();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllBuyers"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllBuyers_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace(It.IsAny<string>())).Throws(new ArgumentNullException());
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);

            // Act
            var resultAction = () => buyerRepository.GetAllBuyers();

            // Assert
            Assert.ThrowsException<ArgumentNullException>(resultAction);
        }

        [TestMethod]
        public async Task GetAllBuyersAsync_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);

            // Act
            var result = await buyerRepository.GetAllBuyersAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllBuyersAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllBuyersAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace(It.IsAny<string>())).Throws(new ArgumentNullException());
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);

            // Act
            var resultAction = () => buyerRepository.GetAllBuyersAsync();

            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);
        }

        [TestMethod]
        public void GetAllBuyers_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);

            // Act
            var result = buyerRepository.GetAllBuyers();

            // Assert
            Assert.IsTrue(result.Any());
            mockLogger.Verify(x => x.Trace("GetAllBuyers"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetAllBuyersAsync_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);

            // Act
            var result = await buyerRepository.GetAllBuyersAsync();

            // Assert
            Assert.IsTrue(result.Any());
            mockLogger.Verify(x => x.Trace("GetAllBuyersAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByStatus_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);

            // Act
            var result = buyerRepository.GetByStatus(1);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetByStatus"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByStatus_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace(It.IsAny<string>())).Throws(new ArgumentNullException());
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);

            // Act
            var resultAction = () => buyerRepository.GetByStatus(1);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(resultAction);
        }

        [TestMethod]
        public async Task GetByStatusAsync_Ativo_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);

            // Act
            var result = await buyerRepository.GetByStatusAsync(1);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetByStatusAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByStatusAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace(It.IsAny<string>())).Throws(new ArgumentNullException());
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);

            // Act
            var resultAction = () => buyerRepository.GetByStatusAsync(1);

            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);
        }

        [TestMethod]
        public async Task GetByStatusAsync_Desativado_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);

            // Act
            var result = await buyerRepository.GetByStatusAsync(0);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetByStatusAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByStatus_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);

            // Act
            var result = buyerRepository.GetByStatus(1);

            // Assert
            mockLogger.Verify(x => x.Trace("GetByStatus"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByStatusAsync_Ativo_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);

            // Act
            var result = await buyerRepository.GetByStatusAsync(1);

            // Assert
            mockLogger.Verify(x => x.Trace("GetByStatusAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByStatusAsync_Desativado_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);

            // Act
            var result = await buyerRepository.GetByStatusAsync(0);

            // Assert
            Assert.IsTrue(result.Any());
            mockLogger.Verify(x => x.Trace("GetByStatusAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);
            var getAll = buyerRepository.GetAllBuyers();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].BuyerId;

            // Act
            var result = buyerRepository.GetById(idUltimo);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllBuyers"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace(It.IsAny<string>())).Throws(new ArgumentNullException());
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);

            // Act
            var resultAction = () => buyerRepository.GetById(1);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(resultAction);
        }

        [TestMethod]
        public void GetById_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);
            var getAll = buyerRepository.GetAllBuyers();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].BuyerId;

            // Act
            var result = buyerRepository.GetById(idUltimo);

            // Assert
            Assert.IsTrue(result.BuyerName != string.Empty);
            Assert.IsTrue(result.BuyerId != 0);
            mockLogger.Verify(x => x.Trace("GetAllBuyers"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);
            var getAll = buyerRepository.GetAllBuyers();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].BuyerId;

            // Act
            var result = await buyerRepository.GetByIdAsync(idUltimo);

            // Assert
            Assert.IsTrue(result.BuyerName != string.Empty);
            Assert.IsTrue(result.BuyerId != 0);
            mockLogger.Verify(x => x.Trace("GetAllBuyers"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace(It.IsAny<string>())).Throws(new ArgumentNullException());
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);

            // Act
            var resultAction = () => buyerRepository.GetByIdAsync(1);

            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);
        }

        [TestMethod]
        public async Task GetByIdAsync_Retorno_Objeto_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);
            var getAll = buyerRepository.GetAllBuyers();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].BuyerId;

            // Act
            var result = await buyerRepository.GetByIdAsync(idUltimo);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllBuyers"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Insert_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);
            string buyerAddress = Faker.Address.StreetAddress();
            string buyerName = Faker.Name.FullName();
            string userName = Faker.Name.First();
            int buyerId = Faker.RandomNumber.Next(0, 100);
            bool status = true;
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            string buyerPhone = Faker.RandomNumber.Next().ToString();
            int userId = Faker.RandomNumber.Next();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            BuyerModel buyerModel = new BuyerModel(buyerId, buyerName, buyerPhone, buyerAddress, status,
                listDateTime, userId, userName);

            // Act
            buyerRepository.Insert(buyerModel);

            //Assert
            mockLogger.Verify(x => x.Trace("Insert"), Times.Exactly(1));
        }

        [TestMethod]
        public void Insert_Async_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);
            string buyerAddress = Faker.Address.StreetAddress();
            string buyerName = Faker.Name.FullName();
            string userName = Faker.Name.First();
            int buyerId = Faker.RandomNumber.Next(0, 100);
            bool status = true;
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            string buyerPhone = Faker.RandomNumber.Next().ToString();
            int userId = Faker.RandomNumber.Next();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            BuyerModel buyerModel = new BuyerModel(buyerId, buyerName, buyerPhone, buyerAddress, status,
                listDateTime, userId, userName);

            // Act
            buyerRepository.InsertAsync(buyerModel);

            //Assert
            mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);
            var getAll = buyerRepository.GetAllBuyers();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].BuyerId;
            
            // Act
            buyerRepository.Delete(idUltimo);

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllBuyers"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Delete"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Async_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);
            var getAll = buyerRepository.GetAllBuyers();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].BuyerId;

            // Act
            buyerRepository.DeleteAsync(idUltimo);

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllBuyers"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);
            var getAll = buyerRepository.GetAllBuyers();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].BuyerId;
            string buyerAddress = Faker.Address.StreetAddress();
            string buyerName = Faker.Name.FullName();
            string userName = Faker.Name.First();
            int buyerId = idUltimo;
            bool status = true;
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = getAll.ToList()[getAll.Count() - 1].DateInsert;
            string buyerPhone = Faker.RandomNumber.Next().ToString();
            int userId = Faker.RandomNumber.Next();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            BuyerModel buyerModel = new BuyerModel(buyerId, buyerName, buyerPhone, buyerAddress, status,
                listDateTime, userId, userName);

            // Act
            buyerRepository.Update(buyerModel);

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllBuyers"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Update"), Times.Exactly(1));
        }

        [TestMethod]
        public void UpdateAsync_Sem_Retorno_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            BuyerRepository buyerRepository = new BuyerRepository(mockLogger.Object);
            var getAll = buyerRepository.GetAllBuyers();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].BuyerId;
            string buyerAddress = Faker.Address.StreetAddress();
            string buyerName = Faker.Name.FullName();
            string userName = Faker.Name.First();
            int buyerId = idUltimo;
            bool status = true;
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = getAll.ToList()[getAll.Count() - 1].DateInsert;
            string buyerPhone = Faker.RandomNumber.Next().ToString();
            int userId = Faker.RandomNumber.Next();
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            BuyerModel buyerModel = new BuyerModel(buyerId, buyerName, buyerPhone, buyerAddress, status,
                listDateTime, userId, userName);

            // Act
            buyerRepository.UpdateAsync(buyerModel);

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllBuyers"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("UpdateAsync"), Times.Exactly(1));
        }
    }
}
