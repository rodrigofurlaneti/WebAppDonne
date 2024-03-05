using AutoFixture;
using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure.SeedWork;
using WebApi.Donne.Infrastructure.VehicleBrand;

namespace Test.Donne.WebApi.Infrastructure.VehicleBrandRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > VehicleBrandRepository")]
    public class VehicleBrandRepositoryTest
    {
        [TestMethod]
        public void GetAll_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);

            // Act
            var result = vehicleBrandRepository.GetAll();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("VehicleBrand_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAll_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleBrand_GetAll")).Throws(new ArgumentNullException());
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);

            // Act
            var resultAction = () => vehicleBrandRepository.GetAll();
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.Trace("VehicleBrand_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("VehicleBrand_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetAllAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);

            // Act
            var result = await vehicleBrandRepository.GetAllAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("VehicleBrand_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleBrand_GetAllAsync")).Throws(new ArgumentNullException());
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);

            // Act
            var resultAction = () => vehicleBrandRepository.GetAllAsync();
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.Trace("VehicleBrand_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("VehicleBrand_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);
            var resultGetAll = vehicleBrandRepository.GetAll();

            // Act
            var result = vehicleBrandRepository.GetById(resultGetAll.First().VehicleBrandId);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("VehicleBrand_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleBrand_GetById")).Throws(new ArgumentNullException());
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);
            var resultGetAll = vehicleBrandRepository.GetAll();

            // Act
            var resultAction = () => vehicleBrandRepository.GetById(resultGetAll.First().VehicleBrandId);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleBrand_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);
            var resultGetAll = await vehicleBrandRepository.GetAllAsync();

            // Act
            var result = await vehicleBrandRepository.GetByIdAsync(resultGetAll.First().VehicleBrandId);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("VehicleBrand_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleBrand_GetByIdAsync")).Throws(new ArgumentNullException());
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);
            var resultGetAll = await vehicleBrandRepository.GetAllAsync();

            // Act
            var resultAction = () => vehicleBrandRepository.GetByIdAsync(resultGetAll.First().VehicleBrandId);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleBrand_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Insert_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleBrandModel vehicleBrandModel = fixture.Build<VehicleBrandModel>()
                .With(vehicleBrandModel => vehicleBrandModel.VehicleBrandId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicleBrandModel => vehicleBrandModel.VehicleBrandName, Faker.Name.First())
                .Create<VehicleBrandModel>();

            // Act
            vehicleBrandRepository.Insert(vehicleBrandModel);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleBrand_Insert"), Times.Exactly(1));
        }

        [TestMethod]
        public void Insert_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleBrand_Insert")).Throws(new ArgumentNullException());
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleBrandModel vehicleBrandModel = fixture.Build<VehicleBrandModel>()
                .With(vehicleBrandModel => vehicleBrandModel.VehicleBrandId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicleBrandModel => vehicleBrandModel.VehicleBrandName, Faker.Name.First())
                .Create<VehicleBrandModel>();

            // Act
            var resultAction = () => vehicleBrandRepository.Insert(vehicleBrandModel);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleBrand_Insert"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task InsertAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleBrandModel vehicleBrandModel = fixture.Build<VehicleBrandModel>()
                .With(vehicleBrandModel => vehicleBrandModel.VehicleBrandId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicleBrandModel => vehicleBrandModel.VehicleBrandName, Faker.Name.First())
                .Create<VehicleBrandModel>();

            // Act
            await vehicleBrandRepository.InsertAsync(vehicleBrandModel);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleBrand_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void InsertAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleBrand_InsertAsync")).Throws(new ArgumentNullException());
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleBrandModel vehicleBrandModel = fixture.Build<VehicleBrandModel>()
                .With(vehicleBrandModel => vehicleBrandModel.VehicleBrandId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicleBrandModel => vehicleBrandModel.VehicleBrandName, Faker.Name.First())
                .Create<VehicleBrandModel>();

            // Act
            var resultAction = () => vehicleBrandRepository.InsertAsync(vehicleBrandModel);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleBrand_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);
            var resultGetAll = vehicleBrandRepository.GetAll();

            // Act
            vehicleBrandRepository.Delete(resultGetAll.First().VehicleBrandId);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleBrand_Delete"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleBrand_Delete")).Throws(new ArgumentNullException());
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);
            var resultGetAll = vehicleBrandRepository.GetAll();

            // Act
            var resultAction = () => vehicleBrandRepository.Delete(resultGetAll.First().VehicleBrandId);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleBrand_Delete"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task DeleteAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);
            var resultGetAll = await vehicleBrandRepository.GetAllAsync();

            // Act
            await vehicleBrandRepository.DeleteAsync(resultGetAll.First().VehicleBrandId);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleBrand_DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task DeleteAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleBrand_DeleteAsync")).Throws(new ArgumentNullException());
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);
            var resultGetAll = await vehicleBrandRepository.GetAllAsync();

            // Act
            var resultAction = () => vehicleBrandRepository.DeleteAsync(resultGetAll.First().VehicleBrandId);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleBrand_DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);
            var resultGetAll = vehicleBrandRepository.GetAll();
            Fixture fixture = new Fixture();
            VehicleBrandModel vehicleBrandModel = fixture.Build<VehicleBrandModel>()
                .With(vehicleBrandModel => vehicleBrandModel.VehicleBrandId, resultGetAll.First().VehicleBrandId)
                .With(vehicleBrandModel => vehicleBrandModel.VehicleBrandName, Faker.Name.First())
                .Create<VehicleBrandModel>();

            // Act
            vehicleBrandRepository.Update(vehicleBrandModel);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleBrand_Update"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleBrand_Update")).Throws(new ArgumentNullException());
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);
            var resultGetAll = vehicleBrandRepository.GetAll();
            Fixture fixture = new Fixture();
            VehicleBrandModel vehicleBrandModel = fixture.Build<VehicleBrandModel>()
                .With(vehicleBrandModel => vehicleBrandModel.VehicleBrandId, resultGetAll.First().VehicleBrandId)
                .With(vehicleBrandModel => vehicleBrandModel.VehicleBrandName, Faker.Name.First())
                .Create<VehicleBrandModel>();

            // Act
            var resultAction = () => vehicleBrandRepository.Update(vehicleBrandModel);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleBrand_Update"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);
            var resultGetAll = await vehicleBrandRepository.GetAllAsync();
            Fixture fixture = new Fixture();
            VehicleBrandModel vehicleBrandModel = fixture.Build<VehicleBrandModel>()
                .With(vehicleBrandModel => vehicleBrandModel.VehicleBrandId, resultGetAll.First().VehicleBrandId)
                .With(vehicleBrandModel => vehicleBrandModel.VehicleBrandName, Faker.Name.First())
                .Create<VehicleBrandModel>();

            // Act
            await vehicleBrandRepository.UpdateAsync(vehicleBrandModel);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleBrand_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleBrand_UpdateAsync")).Throws(new ArgumentNullException());
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);
            var resultGetAll = await vehicleBrandRepository.GetAllAsync();
            Fixture fixture = new Fixture();
            VehicleBrandModel vehicleBrandModel = fixture.Build<VehicleBrandModel>()
                .With(vehicleBrandModel => vehicleBrandModel.VehicleBrandId, resultGetAll.First().VehicleBrandId)
                .With(vehicleBrandModel => vehicleBrandModel.VehicleBrandName, Faker.Name.First())
                .Create<VehicleBrandModel>();

            // Act
            var resultAction = () => vehicleBrandRepository.UpdateAsync(vehicleBrandModel);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleBrand_UpdateAsync"), Times.Exactly(1));
        }

    }
}
