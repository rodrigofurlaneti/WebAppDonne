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
        public void GetAllFormOfPayment_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);

            // Act
            var result = commandRepository.GetAllCommand();

            // Assert
            Assert.IsNotNull(result);
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
            Assert.AreNotEqual(0, result.UserId);
            Assert.AreNotEqual(string.Empty, result.UserName);
        }

        [TestMethod]
        public void GetByStatus_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAllCommand();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].CommandId;

            // Act
            var result = commandRepository.GetByStatus(idUltimo);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetCommandOrder_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CommandRepository commandRepository = new CommandRepository(mockLogger.Object);
            var getAll = commandRepository.GetAllCommand();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].CommandId;

            // Act
            var result = commandRepository.GetCommandOrder(idUltimo);

            // Assert
            Assert.IsNotNull(result);
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
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(1));
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
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(2));
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
            mockLogger.Verify(x => x.Trace(It.IsAny<string>()), Times.Exactly(2));
        }


    }
}
