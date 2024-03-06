using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure.CompanyAsset;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Infrastructure.CompanyAssetRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > CompanyAssetRepository")]
    public class CompanyAssetRepositoryTest
    {
        [TestMethod]
        public void GetAll_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CompanyAssetRepository companyAssetRepository = new CompanyAssetRepository(mockLogger.Object);

            // Act
            var result = companyAssetRepository.GetAll();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("CompanyAsset_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAll_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CompanyAssetRepository companyAssetRepository = new CompanyAssetRepository(mockLogger.Object);

            // Act
            var result = companyAssetRepository.GetAll();

            // Assert
            Assert.IsTrue(result.Any());
            mockLogger.Verify(x => x.Trace("CompanyAsset_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetAllAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CompanyAssetRepository companyAssetRepository = new CompanyAssetRepository(mockLogger.Object);

            // Act
            var result = await companyAssetRepository.GetAllAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("CompanyAsset_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            // Setup
            mockLogger.Setup(x => x.Trace("CompanyAsset_GetAllAsync")).Throws(new Exception());
            CompanyAssetRepository companyAssetRepository = new CompanyAssetRepository(mockLogger.Object);

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => companyAssetRepository.GetAllAsync());
            mockLogger.Verify(x => x.TraceException("CompanyAsset_GetAllAsync"), Times.Exactly(0));
        }

        [TestMethod]
        public void GetAll_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace(It.IsAny<string>())).Throws(new ArgumentNullException());
            CompanyAssetRepository companyAssetRepository = new CompanyAssetRepository(mockLogger.Object);

            // Act
            var resultAction = () => companyAssetRepository.GetAll();

            // Assert
            Assert.ThrowsException<ArgumentNullException>(resultAction);
        }

        [TestMethod]
        public void GetById_Retorno_Diferente_Nulo_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CompanyAssetRepository companyAssetRepository = new CompanyAssetRepository(mockLogger.Object);
            var getAll = companyAssetRepository.GetAll();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].CompanyAssetId;

            // Act
            var result = companyAssetRepository.GetById(idUltimo);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("CompanyAsset_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CompanyAsset_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CompanyAssetRepository companyAssetRepository = new CompanyAssetRepository(mockLogger.Object);
            var getAll = await companyAssetRepository.GetAllAsync();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].CompanyAssetId;

            // Act
            var result = await companyAssetRepository.GetByIdAsync(idUltimo);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("CompanyAsset_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CompanyAsset_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("CompanyAsset_GetByIdAsync")).Throws(new Exception());
            CompanyAssetRepository companyAssetRepository = new CompanyAssetRepository(mockLogger.Object);
            var getAll = companyAssetRepository.GetAll();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].CompanyAssetId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => companyAssetRepository.GetByIdAsync(idUltimo));

            // Assert
            mockLogger.Verify(x => x.TraceException("CompanyAsset_GetByIdAsync"), Times.Exactly(0));
        }

        [TestMethod]
        public void GetById_Retorno_Objeto_Populado_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CompanyAssetRepository companyAssetRepository = new CompanyAssetRepository(mockLogger.Object);
            var getAll = companyAssetRepository.GetAll();
            int idUltimo = getAll.ToList()[getAll.Count() - 1].CompanyAssetId;

            // Act
            var result = companyAssetRepository.GetById(idUltimo);

            // Assert
            Assert.IsTrue(result.UserName != string.Empty);
            Assert.IsTrue(result.UserId != 0);
            Assert.IsTrue(result.CompanyAssetName != string.Empty);
            Assert.IsTrue(result.CompanyAssetId != 0);
            mockLogger.Verify(x => x.Trace("CompanyAsset_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CompanyAsset_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //Setup
            mockLogger.Setup(x => x.Trace(It.IsAny<string>())).Throws(new ArgumentNullException());
            CompanyAssetRepository companyAssetRepository = new CompanyAssetRepository(mockLogger.Object);

            // Act
            var resultAction = () => companyAssetRepository.GetById(0);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(resultAction);
        }

        [TestMethod]
        public void Insert_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CompanyAssetRepository companyAssetRepository = new CompanyAssetRepository(mockLogger.Object);
            int companyAssetId = Faker.RandomNumber.Next(0, 100);
            string companyAssetName = Faker.Name.FullName();
            string costPrice = Faker.Finance.Coupon().ToString();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            CompanyAssetModel companyAssetModel = new CompanyAssetModel(companyAssetId,
                companyAssetName, costPrice, dateInsert, dateUpdate, userId, userName);

            // Act
            companyAssetRepository.Insert(companyAssetModel);

            //Assert
            mockLogger.Verify(x => x.Trace("CompanyAsset_Insert"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task InsertAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CompanyAssetRepository companyAssetRepository = new CompanyAssetRepository(mockLogger.Object);
            int companyAssetId = Faker.RandomNumber.Next(0, 100);
            string companyAssetName = Faker.Name.FullName();
            string costPrice = Faker.Finance.Coupon().ToString();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            CompanyAssetModel companyAssetModel = new CompanyAssetModel(companyAssetId,
                companyAssetName, costPrice, dateInsert, dateUpdate, userId, userName);

            // Act
            await companyAssetRepository.InsertAsync(companyAssetModel);

            //Assert
            mockLogger.Verify(x => x.Trace("CompanyAsset_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void InsertAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            int companyAssetId = Faker.RandomNumber.Next(0, 100);
            string companyAssetName = Faker.Name.FullName();
            string costPrice = Faker.Finance.Coupon().ToString();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            CompanyAssetModel companyAssetModel = new CompanyAssetModel(companyAssetId,
                companyAssetName, costPrice, dateInsert, dateUpdate, userId, userName);

            // Setup
            mockLogger.Setup(x => x.Trace("CompanyAsset_InsertAsync")).Throws(new Exception());
            mockLogger.Setup(x => x.TraceException("CompanyAsset_InsertAsync")).Throws(new Exception());
            CompanyAssetRepository companyAssetRepository = new CompanyAssetRepository(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => companyAssetRepository.InsertAsync(companyAssetModel));

            // Assert
            mockLogger.Verify(x => x.Trace("CompanyAsset_InsertAsync"), Times.Exactly(0));
            mockLogger.Verify(x => x.TraceException("CompanyAsset_InsertAsync"), Times.Exactly(0));
        }

        [TestMethod]
        public void Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CompanyAssetRepository companyAssetRepository = new CompanyAssetRepository(mockLogger.Object);
            var getAll = companyAssetRepository.GetAll();
            int companyAssetId = getAll.ToList()[getAll.Count() - 1].CompanyAssetId;
            string companyAssetName = Faker.Name.FullName();
            DateTime dateInsert = getAll.ToList()[getAll.Count() - 1].DateInsert;
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            string costPrice = Faker.Finance.Coupon().ToString();
            CompanyAssetModel companyAssetModel = new CompanyAssetModel(companyAssetId,
                companyAssetName, costPrice, dateInsert, dateUpdate, userId, userName);

            // Act
            companyAssetRepository.Update(companyAssetModel);

            //Assert
            mockLogger.Verify(x => x.Trace("CompanyAsset_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CompanyAsset_Update"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CompanyAssetRepository companyAssetRepository = new CompanyAssetRepository(mockLogger.Object);
            var getAll = companyAssetRepository.GetAll();
            int companyAssetId = getAll.ToList()[getAll.Count() - 1].CompanyAssetId;
            string costPrice = Faker.Finance.Coupon().ToString();
            string companyAssetName = Faker.Name.FullName();
            DateTime dateInsert = getAll.ToList()[getAll.Count() - 1].DateInsert;
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            CompanyAssetModel companyAssetModel = new CompanyAssetModel(companyAssetId,
                companyAssetName, costPrice, dateInsert, dateUpdate, userId, userName);

            // Act
            await companyAssetRepository.UpdateAsync(companyAssetModel);

            //Assert
            mockLogger.Verify(x => x.Trace("CompanyAsset_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CompanyAsset_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void UpdateAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("CompanyAsset_UpdateAsync")).Throws(new Exception());
            CompanyAssetRepository companyAssetRepository = new CompanyAssetRepository(mockLogger.Object);
            var getAll = companyAssetRepository.GetAll();
            int companyAssetId = getAll.ToList()[getAll.Count() - 1].CompanyAssetId;
            string companyAssetName = Faker.Name.FullName();
            DateTime dateInsert = getAll.ToList()[getAll.Count() - 1].DateInsert;
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            string costPrice = Faker.Finance.Coupon().ToString();
            CompanyAssetModel companyAssetModel = new CompanyAssetModel(companyAssetId,
                companyAssetName, costPrice, dateInsert, dateUpdate, userId, userName);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => companyAssetRepository.UpdateAsync(companyAssetModel));

            // Assert
            mockLogger.Verify(x => x.TraceException("CompanyAsset_UpdateAsync"), Times.Exactly(0));
            mockLogger.Verify(x => x.Trace("CompanyAsset_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CompanyAsset_UpdateAsync"), Times.Exactly(0));
        }

        [TestMethod]
        public void Delete_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CompanyAssetRepository companyAssetRepository = new CompanyAssetRepository(mockLogger.Object);
            var getAll = companyAssetRepository.GetAll();
            int companyAssetId = getAll.ToList()[getAll.Count() - 1].CompanyAssetId;

            // Act
            companyAssetRepository.Delete(companyAssetId);

            //Assert
            mockLogger.Verify(x => x.Trace("CompanyAsset_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CompanyAsset_Delete"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task DeleteAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CompanyAssetRepository companyAssetRepository = new CompanyAssetRepository(mockLogger.Object);
            var getAll = companyAssetRepository.GetAll();
            int companyAssetId = getAll.ToList()[getAll.Count() - 1].CompanyAssetId;

            // Act
            await companyAssetRepository.DeleteAsync(companyAssetId);

            //Assert
            mockLogger.Verify(x => x.Trace("CompanyAsset_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CompanyAsset_DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void DeleteAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("DeleteAsync")).Throws(new Exception());
            CompanyAssetRepository companyAssetRepository = new CompanyAssetRepository(mockLogger.Object);
            var getAll = companyAssetRepository.GetAll();
            int companyAssetId = getAll.ToList()[getAll.Count() - 1].CompanyAssetId;

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => companyAssetRepository.DeleteAsync(companyAssetId));
            mockLogger.Verify(x => x.Trace("CompanyAsset_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("CompanyAsset_DeleteAsync"), Times.Exactly(0));
        }
    }
}
