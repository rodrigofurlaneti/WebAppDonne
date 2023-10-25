using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Infrastructure.CommandRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > CommandRepository")]
    public class CommandRepositoryTest
    {
        [TestMethod]
        public void GetAllCommand_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);

            // Act
            var result = commandRepository.GetAllCommand();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllCommand"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllCommand_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);

            // Act
            var result = commandRepository.GetAllCommand();

            // Assert
            Assert.IsTrue(result.Any());
            mockLogger.Verify(x => x.Trace("GetAllCommand"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetAllCommandAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);

            // Act
            var result = await commandRepository.GetAllCommandAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllCommandAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllCommandAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetAllCommandAsync")).Throws(new Exception());
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => commandRepository.GetAllCommandAsync());
            mockLogger.Verify(x => x.Trace("GetAllCommandAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAllCommand();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].CommandId;

            // Act
            var result = commandRepository.GetById(idUltimo);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAllCommand();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].CommandId;

            // Act
            var result = commandRepository.GetById(idUltimo);

            // Assert
            Assert.AreEqual(idUltimo, result.CommandId);
            Assert.AreNotEqual(string.Empty, result.UserName);
            mockLogger.Verify(x => x.Trace("GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByStatus_Ativo_Sucesso()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAllCommand();
            foreach (var item in getAll)
                if(item.Status.Equals(true))
                    id = 1;

            // Act
            var result = commandRepository.GetByStatus(id);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllCommand"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByStatus"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByStatusAsync_Ativo_Sucesso()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAllCommand();
            foreach (var item in getAll)
                if (item.Status.Equals(true))
                    id = 1;

            // Act
            var result = await commandRepository.GetByStatusAsync(id);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllCommand"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByStatusAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByStatusAsync_Ativo_Erro()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetByStatusAsync")).Throws(new Exception());
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAllCommand();
            foreach (var item in getAll)
                if (item.Status.Equals(true))
                    id = 1;

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => commandRepository.GetByStatusAsync(id));
            mockLogger.Verify(x => x.Trace("GetAllCommand"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByStatusAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByStatusAsync_Desativo_Erro()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetByStatusAsync")).Throws(new Exception());
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAllCommand();
            foreach (var item in getAll)
                if (item.Status.Equals(false))
                    id = 0;

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => commandRepository.GetByStatusAsync(id));
            mockLogger.Verify(x => x.Trace("GetAllCommand"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByStatusAsync"), Times.Exactly(1));

        }

        [TestMethod]
        public void GetByStatus_Desativo_Sucesso()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAllCommand();
            foreach (var item in getAll)
                if (item.Status.Equals(false))
                    id = 0;

            // Act
            var result = commandRepository.GetByStatus(id);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllCommand"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByStatus"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByStatusAsync_Desativo_Sucesso()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAllCommand();
            foreach (var item in getAll)
                if (item.Status.Equals(false))
                    id = 0;

            // Act
            var result = await commandRepository.GetByStatusAsync(id);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetAllCommand"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByStatusAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetCommandOrder_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAllCommand();
            foreach (var item in getAll)
                if (item.Status.Equals(true))
                    id = item.CommandId;

            // Act
            var result = commandRepository.GetCommandOrder(id);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("GetCommandOrder"), Times.Exactly(1));
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
            bool status = true;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CommandModel commandModel = new CommandModel(commandId, buyerId, buyerName, status, listDateTime,
                userId, userName);

            // Act
            commandRepository.Insert(commandModel);

            //Assert
            mockLogger.Verify(x => x.Trace("Insert"), Times.Exactly(1));
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
            bool status = true;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CommandModel commandModel = new CommandModel(commandId, buyerId, buyerName, status, listDateTime,
                userId, userName);

            // Act
            var result = commandRepository.InsertReturnId(commandModel);

            //Assert
            mockLogger.Verify(x => x.Trace("InsertReturnId"), Times.Exactly(1));
            Assert.IsNotNull(result);
            Assert.AreNotEqual(commandId, result);
        }

        [TestMethod]
        public void Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAllCommand();
            int commandId = getAll.ToList()[getAll.Count() - 1].CommandId;
            int buyerId = Faker.RandomNumber.Next(0, 100);
            string buyerName = Faker.Name.FullName();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = getAll.ToList()[getAll.Count() - 1].DateInsert;
            bool status = true;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CommandModel commandModel = new CommandModel(commandId, buyerId, buyerName, status, listDateTime,
                userId, userName);

            // Act
            commandRepository.Update(commandModel);

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllCommand"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Update"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAllCommand();
            int commandId = getAll.ToList()[getAll.Count() - 1].CommandId;
            int buyerId = Faker.RandomNumber.Next(0, 100);
            string buyerName = Faker.Name.FullName();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = getAll.ToList()[getAll.Count() - 1].DateInsert;
            bool status = true;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CommandModel commandModel = new CommandModel(commandId, buyerId, buyerName, status, listDateTime,
                userId, userName);

            // Act
            await commandRepository.UpdateAsync(commandModel);

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllCommand"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void UpdateAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("UpdateAsync")).Throws(new Exception());
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAllCommand();
            int commandId = getAll.ToList()[getAll.Count() - 1].CommandId;
            int buyerId = Faker.RandomNumber.Next(0, 100);
            string buyerName = Faker.Name.FullName();
            int userId = Faker.RandomNumber.Next(0, 100);
            string userName = Faker.Name.First();
            DateTime dateUpdate = DateTime.Now;
            DateTime dateInsert = getAll.ToList()[getAll.Count() - 1].DateInsert;
            bool status = true;
            List<DateTime> listDateTime = new List<DateTime>() { dateInsert, dateUpdate };
            CommandModel commandModel = new CommandModel(commandId, buyerId, buyerName, status, listDateTime,
                userId, userName);

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => commandRepository.UpdateAsync(commandModel));
            mockLogger.Verify(x => x.Trace("GetAllCommand"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAllCommand();
            int commandId = getAll.ToList()[getAll.Count() - 1].CommandId;

            // Act
            commandRepository.Delete(commandId);

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllCommand"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("Delete"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task DeleteAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAllCommand();
            int commandId = getAll.ToList()[getAll.Count() - 1].CommandId;

            // Act
            await commandRepository.DeleteAsync(commandId);

            //Assert
            mockLogger.Verify(x => x.Trace("GetAllCommand"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void DeleteAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("DeleteAsync")).Throws(new Exception());
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAllCommand();
            int commandId = getAll.ToList()[getAll.Count() - 1].CommandId;

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => commandRepository.DeleteAsync(commandId));
            mockLogger.Verify(x => x.Trace("GetAllCommand"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("DeleteAsync"), Times.Exactly(1));
        }
    }
}
