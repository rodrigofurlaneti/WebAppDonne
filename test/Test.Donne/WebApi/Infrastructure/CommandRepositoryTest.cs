using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure.Command;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Infrastructure.CommandRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > CommandRepository")]
    public class CommandRepositoryTest
    {
        [TestMethod]
        public void GetAll_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);

            // Act
            var result = commandRepository.GetAll();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Command_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAll_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);

            // Act
            var result = commandRepository.GetAll();

            // Assert
            Assert.IsTrue(result.Any());
            mockLogger.Verify(x => x.Trace("Command_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetAllAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);

            // Act
            var result = await commandRepository.GetAllAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Command_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Command_GetAllAsync")).Throws(new Exception());
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => commandRepository.GetAllAsync());
            
            // Assert
            mockLogger.Verify(x => x.Trace("Command_GetAllAsync"), Times.Exactly(0));
            mockLogger.Verify(x => x.TraceException("Command_GetAllAsync"), Times.Exactly(0));
        }

        [TestMethod]
        public void GetById_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAll();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].CommandId;

            // Act
            var result = commandRepository.GetById(idUltimo);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Command_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Command_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAll();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].CommandId;

            // Act
            var result = commandRepository.GetById(idUltimo);

            // Assert
            Assert.AreEqual(idUltimo, result.CommandId);
            Assert.AreNotEqual(string.Empty, result.UserName);
            mockLogger.Verify(x => x.Trace("Command_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Command_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAll();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].CommandId;

            // Act
            var result = await commandRepository.GetByIdAsync(idUltimo);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Command_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Command_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            // Setup 
            mockLogger.Setup(x => x.Trace("Command_GetByIdAsync")).Throws(new Exception());
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAll();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].CommandId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => commandRepository.GetByIdAsync(idUltimo));

            // Assert
            mockLogger.Verify(x => x.Trace("Command_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByStatus_Ativo_Sucesso()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAll();
            foreach (var item in getAll)
                if(item.Status.Equals(true))
                    id = 1;

            // Act
            var result = commandRepository.GetByStatus(id);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Command_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByStatus"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByStatusAsync_Ativo_Sucesso()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAll();
            foreach (var item in getAll)
                if (item.Status.Equals(true))
                    id = 1;

            // Act
            var result = await commandRepository.GetByStatusAsync(id);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Command_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Command_GetByStatusAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByStatusAsync_Ativo_Erro()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetByStatusAsync")).Throws(new Exception());
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAll();
            foreach (var item in getAll)
                if (item.Status.Equals(true))
                    id = 1;

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => commandRepository.GetByStatusAsync(id));
            mockLogger.Verify(x => x.Trace("Command_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByStatusAsync_Desativo_Erro()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetByStatusAsync")).Throws(new Exception());
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAll();
            foreach (var item in getAll)
                if (item.Status.Equals(false))
                    id = 0;

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => commandRepository.GetByStatusAsync(id));
            mockLogger.Verify(x => x.Trace("Command_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByStatus_Desativo_Sucesso()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAll();
            foreach (var item in getAll)
                if (item.Status.Equals(false))
                    id = 0;

            // Act
            var result = commandRepository.GetByStatus(id);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Command_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByStatus"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByStatusAsync_Desativo_Sucesso()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAll();
            foreach (var item in getAll)
                if (item.Status.Equals(false))
                    id = 0;

            // Act
            var result = await commandRepository.GetByStatusAsync(id);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Command_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Command_GetByStatusAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Insert_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            int buyerId = Faker.RandomNumber.Next(0, 100);
            string buyerName = Faker.Name.FullName();
            int commandId = Faker.RandomNumber.Next(0, 100);
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            int status = 1;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CommandModel commandModel = new CommandModel(commandId, buyerId, buyerName, status, listDateTime,
                userId, userName);

            // Act
            commandRepository.Insert(commandModel);

            //Assert
            mockLogger.Verify(x => x.Trace("Command_Insert"), Times.Exactly(1));
        }

        [TestMethod]
        public void Insert_Retorno_Id_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            int buyerId = Faker.RandomNumber.Next(0, 100);
            string buyerName = Faker.Name.FullName();
            int commandId = Faker.RandomNumber.Next(0, 100);
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            int status = 1;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CommandModel commandModel = new CommandModel(commandId, buyerId, buyerName, status, listDateTime,
                userId, userName);

            // Act
            var result = commandRepository.InsertReturnId(commandModel);

            //Assert
            mockLogger.Verify(x => x.Trace("Command_InsertReturnId"), Times.Exactly(1));
            Assert.IsNotNull(result);
            Assert.AreNotEqual(commandId, result);
        }

        [TestMethod]
        public void Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAll();
            int commandId = getAll.ToList()[getAll.Count() - 1].CommandId;
            int buyerId = Faker.RandomNumber.Next(0, 100);
            string buyerName = Faker.Name.FullName();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = getAll.ToList()[getAll.Count() - 1].DateInsert;
            int status = 1;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CommandModel commandModel = new CommandModel(commandId, buyerId, buyerName, status, listDateTime,
                userId, userName);

            // Act
            commandRepository.Update(commandModel);

            //Assert
            mockLogger.Verify(x => x.Trace("Command_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Command_Update"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAll();
            int commandId = getAll.ToList()[getAll.Count() - 1].CommandId;
            int buyerId = Faker.RandomNumber.Next(0, 100);
            string buyerName = Faker.Name.FullName();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = getAll.ToList()[getAll.Count() - 1].DateInsert;
            int status = 1;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CommandModel commandModel = new CommandModel(commandId, buyerId, buyerName, status, listDateTime,
                userId, userName);

            // Act
            await commandRepository.UpdateAsync(commandModel);

            //Assert
            mockLogger.Verify(x => x.Trace("Command_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Command_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void UpdateAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("UpdateAsync")).Throws(new Exception());
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAll();
            int commandId = getAll.ToList()[getAll.Count() - 1].CommandId;
            int buyerId = Faker.RandomNumber.Next(0, 100);
            string buyerName = Faker.Name.FullName();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = getAll.ToList()[getAll.Count() - 1].DateInsert;
            int status = 1;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CommandModel commandModel = new CommandModel(commandId, buyerId, buyerName, status, listDateTime,
                userId, userName);

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => commandRepository.UpdateAsync(commandModel));
            mockLogger.Verify(x => x.Trace("Command_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Sucesso()
        {
            // Arrange
            Insert_Sucesso();
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAll();
            int commandId = getAll.ToList()[getAll.Count() - 1].CommandId;

            // Act
            commandRepository.Delete(commandId);

            //Assert
            mockLogger.Verify(x => x.Trace("Command_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Command_Delete"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task DeleteAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAll();
            int commandId = getAll.ToList()[getAll.Count() - 1].CommandId;

            // Act
            await commandRepository.DeleteAsync(commandId);

            //Assert
            mockLogger.Verify(x => x.Trace("Command_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Command_DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task DeleteAsync_Erro()
        {
            // Arrange
            await InsertAsync_Sucesso();
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Command_DeleteAsync")).Throws(new Exception());
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAll();
            int commandId = getAll.ToList()[getAll.Count() - 1].CommandId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => commandRepository.DeleteAsync(commandId));

            // Assert
            mockLogger.Verify(x => x.Trace("Command_DeleteAsync"), Times.Exactly(0));
            mockLogger.Verify(x => x.TraceException("Command_DeleteAsync"), Times.Exactly(0));
        }

        [TestMethod]
        public async Task InsertAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            int buyerId = Faker.RandomNumber.Next(0, 100);
            string buyerName = Faker.Name.FullName();
            int commandId = Faker.RandomNumber.Next(0, 100);
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            int status = 1;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CommandModel commandModel = new CommandModel(commandId, buyerId, buyerName, status, listDateTime,
                userId, userName);

            // Act
            await commandRepository.InsertAsync(commandModel);

            //Assert
            mockLogger.Verify(x => x.Trace("Command_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void InsertAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            int buyerId = Faker.RandomNumber.Next(0, 100);
            string buyerName = Faker.Name.FullName();
            int commandId = Faker.RandomNumber.Next(0, 100);
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            int status = 1;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CommandModel commandModel = new CommandModel(commandId, buyerId, buyerName, status, listDateTime,
                userId, userName);

            // Setup
            mockLogger.Setup(x => x.Trace("Command_InsertAsync")).Throws(new Exception());

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => commandRepository.InsertAsync(commandModel));

            // Assert
            mockLogger.Verify(x => x.Trace("Command_InsertAsync"), Times.Exactly(0));
            mockLogger.Verify(x => x.TraceException("Command_InsertAsync"), Times.Exactly(0));
        }

        [TestMethod]
        public async Task InsertReturnIdAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            int buyerId = Faker.RandomNumber.Next(0, 100);
            string buyerName = Faker.Name.FullName();
            int commandId = Faker.RandomNumber.Next(0, 100);
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            int status = 1;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CommandModel commandModel = new CommandModel(commandId, buyerId, buyerName, status, listDateTime,
                userId, userName);

            // Act
            var result = await commandRepository.InsertReturnIdAsync(commandModel);

            //Assert
            mockLogger.Verify(x => x.Trace("InsertReturnIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void InsertReturnIdAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("InsertReturnIdAsync")).Throws(new Exception());
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            int buyerId = Faker.RandomNumber.Next(0, 100);
            string buyerName = Faker.Name.FullName();
            int commandId = Faker.RandomNumber.Next(0, 100);
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = DateTime.Now;
            int status = 1;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CommandModel commandModel = new CommandModel(commandId, buyerId, buyerName, status, listDateTime,
                userId, userName);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => commandRepository.InsertReturnIdAsync(commandModel));

            // Assert
            mockLogger.Verify(x => x.Trace("InsertReturnIdAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("Command_InsertReturnIdAsync"), Times.Exactly(1));
        }
    }
}
