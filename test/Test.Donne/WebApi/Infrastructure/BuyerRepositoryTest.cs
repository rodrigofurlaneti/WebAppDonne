using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Donne.Infrastructure;

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
            BuyerRepository buyerRepository = new BuyerRepository();

            // Act
            var result = buyerRepository.GetAllBuyers();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetAllBuyersAsync_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();

            // Act
            var result = await buyerRepository.GetAllBuyersAsync();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAllBuyers_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();

            // Act
            var result = buyerRepository.GetAllBuyers();

            // Assert
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public async Task GetAllBuyersAsync_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();

            // Act
            var result = await buyerRepository.GetAllBuyersAsync();

            // Assert
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void GetByStatus_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();

            // Act
            var result = buyerRepository.GetByStatus(1);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetByStatusAsync_Ativo_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();

            // Act
            var result = await buyerRepository.GetByStatusAsync(1);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetByStatusAsync_Desativado_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();

            // Act
            var result = await buyerRepository.GetByStatusAsync(0);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetByStatus_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();

            // Act
            var result = buyerRepository.GetByStatus(1);

            // Assert
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public async Task GetByStatusAsync_Ativo_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();

            // Act
            var result = await buyerRepository.GetByStatusAsync(1);

            // Assert
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public async Task GetByStatusAsync_Desativado_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();

            // Act
            var result = await buyerRepository.GetByStatusAsync(0);

            // Assert
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void GetById_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();
            var getAll = buyerRepository.GetAllBuyers();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].BuyerId;

            // Act
            var result = buyerRepository.GetById(idUltimo);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetById_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();
            var getAll = buyerRepository.GetAllBuyers();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].BuyerId;

            // Act
            var result = buyerRepository.GetById(idUltimo);

            // Assert
            Assert.IsTrue(result.BuyerName != string.Empty);
            Assert.IsTrue(result.BuyerId != 0);
        }

        [TestMethod]
        public async Task GetByIdAsync_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();
            var getAll = buyerRepository.GetAllBuyers();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].BuyerId;

            // Act
            var result = await buyerRepository.GetByIdAsync(idUltimo);

            // Assert
            Assert.IsTrue(result.BuyerName != string.Empty);
            Assert.IsTrue(result.BuyerId != 0);
        }

        [TestMethod]
        public async Task GetByIdAsync_Retorno_Objeto_Nulo_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();
            var getAll = buyerRepository.GetAllBuyers();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].BuyerId;

            // Act
            var result = await buyerRepository.GetByIdAsync(idUltimo);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Insert_Sem_Retorno_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();
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
        }

        [TestMethod]
        public void Insert_Async_Sem_Retorno_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();
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
        }

        [TestMethod]
        public void Delete_Sem_Retorno_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();
            var getAll = buyerRepository.GetAllBuyers();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].BuyerId;
            
            // Act
            buyerRepository.Delete(idUltimo);
        }

        [TestMethod]
        public void Delete_Async_Sem_Retorno_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();
            var getAll = buyerRepository.GetAllBuyers();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].BuyerId;

            // Act
            buyerRepository.DeleteAsync(idUltimo);
        }

        [TestMethod]
        public void Update_Sem_Retorno_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();
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
        }

        [TestMethod]
        public void UpdateAsync_Sem_Retorno_Sucesso()
        {
            // Arrange
            BuyerRepository buyerRepository = new BuyerRepository();
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
        }
    }
}
