using AutoFixture;
using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Infrastructure.VehicleModelRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > VehicleModelRepository")]
    public class VehicleModelRepositoryTest
    {
        [TestMethod]
        public void GetAll_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);

            // Act
            var result = vehicleModelRepository.GetAllVehicleModels();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("VehicleModel_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAll_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleModel_GetAll")).Throws(new ArgumentNullException());
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);

            // Act
            var resultAction = () => vehicleModelRepository.GetAllVehicleModels();
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.Trace("VehicleModel_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("VehicleModel_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetAllAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);

            // Act
            var result = await vehicleModelRepository.GetAllVehicleModelsAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("VehicleModel_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleModel_GetAllAsync")).Throws(new ArgumentNullException());
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);

            // Act
            var resultAction = () => vehicleModelRepository.GetAllVehicleModelsAsync();
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.Trace("VehicleModel_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("VehicleModel_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);
            var resultGetAll = vehicleModelRepository.GetAllVehicleModels();

            // Act
            var result = vehicleModelRepository.GetById(resultGetAll.First().VehicleModelId);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("VehicleModel_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleModel_GetById")).Throws(new ArgumentNullException());
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);
            var resultGetAll = vehicleModelRepository.GetAllVehicleModels();

            // Act
            var resultAction = () => vehicleModelRepository.GetById(resultGetAll.First().VehicleModelId);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleModel_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);
            var resultGetAll = await vehicleModelRepository.GetAllVehicleModelsAsync();

            // Act
            var result = await vehicleModelRepository.GetByIdAsync(resultGetAll.First().VehicleModelId);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("VehicleModel_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleModel_GetByIdAsync")).Throws(new ArgumentNullException());
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);
            var resultGetAll = await vehicleModelRepository.GetAllVehicleModelsAsync();

            // Act
            var resultAction = () => vehicleModelRepository.GetByIdAsync(resultGetAll.First().VehicleModelId);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.Trace("VehicleModel_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("VehicleModel_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Insert_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleModel vehicleModel = fixture.Build<VehicleModel>()
                .With(vehicleModel => vehicleModel.VehicleModelId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicleModel => vehicleModel.VehicleModelName, Faker.Name.First())
                .Create<VehicleModel>();

            // Act
            vehicleModelRepository.Insert(vehicleModel);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleModel_Insert"), Times.Exactly(1));
        }

        [TestMethod]
        public void Insert_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleModel_Insert")).Throws(new ArgumentNullException());
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleModel vehicleModel = fixture.Build<VehicleModel>()
                .With(vehicleModel => vehicleModel.VehicleModelId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicleModel => vehicleModel.VehicleModelName, Faker.Name.First())
                .Create<VehicleModel>();

            // Act
            var resultAction = () => vehicleModelRepository.Insert(vehicleModel);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleModel_Insert"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task InsertAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleModel vehicleModel = fixture.Build<VehicleModel>()
                .With(vehicleModel => vehicleModel.VehicleModelId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicleModel => vehicleModel.VehicleModelName, Faker.Name.First())
                .Create<VehicleModel>();

            // Act
            await vehicleModelRepository.InsertAsync(vehicleModel);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleModel_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void InsertAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleModel_InsertAsync")).Throws(new ArgumentNullException());
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleModel vehicleModel = fixture.Build<VehicleModel>()
                .With(vehicleModel => vehicleModel.VehicleModelId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicleModel => vehicleModel.VehicleModelName, Faker.Name.First())
                .Create<VehicleModel>();

            // Act
            var resultAction = () => vehicleModelRepository.InsertAsync(vehicleModel);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleModel_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);
            var resultGetAll = vehicleModelRepository.GetAllVehicleModels();

            // Act
            vehicleModelRepository.Delete(resultGetAll.First().VehicleModelId);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleModel_Delete"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleModel_Delete")).Throws(new ArgumentNullException());
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);
            var resultGetAll = vehicleModelRepository.GetAllVehicleModels();

            // Act
            var resultAction = () => vehicleModelRepository.Delete(resultGetAll.First().VehicleModelId);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleModel_Delete"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task DeleteAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);
            var resultGetAll = await vehicleModelRepository.GetAllVehicleModelsAsync();

            // Act
            await vehicleModelRepository.DeleteAsync(resultGetAll.First().VehicleModelId);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleModel_DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task DeleteAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleModel_DeleteAsync")).Throws(new ArgumentNullException());
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);
            var resultGetAll = await vehicleModelRepository.GetAllVehicleModelsAsync();

            // Act
            var resultAction = () => vehicleModelRepository.DeleteAsync(resultGetAll.First().VehicleModelId);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleModel_DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);
            var resultGetAll = vehicleModelRepository.GetAllVehicleModels();
            Fixture fixture = new Fixture();
            VehicleModel vehicleModel = fixture.Build<VehicleModel>()
                .With(vehicleModel => vehicleModel.VehicleModelId, resultGetAll.First().VehicleModelId)
                .With(vehicleModel => vehicleModel.VehicleModelName, Faker.Name.First())
                .Create<VehicleModel>();

            // Act
            vehicleModelRepository.Update(vehicleModel);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleModel_Update"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleModel_Update")).Throws(new ArgumentNullException());
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);
            var resultGetAll = vehicleModelRepository.GetAllVehicleModels();
            Fixture fixture = new Fixture();
            VehicleModel vehicleModel = fixture.Build<VehicleModel>()
                .With(vehicleModel => vehicleModel.VehicleModelId, resultGetAll.First().VehicleModelId)
                .With(vehicleModel => vehicleModel.VehicleModelName, Faker.Name.First())
                .Create<VehicleModel>();

            // Act
            var resultAction = () => vehicleModelRepository.Update(vehicleModel);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleModel_Update"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);
            var resultGetAll = await vehicleModelRepository.GetAllVehicleModelsAsync();
            Fixture fixture = new Fixture();
            VehicleModel vehicleModel = fixture.Build<VehicleModel>()
                .With(vehicleModel => vehicleModel.VehicleModelId, resultGetAll.First().VehicleModelId)
                .With(vehicleModel => vehicleModel.VehicleModelName, Faker.Name.First())
                .Create<VehicleModel>();

            // Act
            await vehicleModelRepository.UpdateAsync(vehicleModel);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleModel_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleModel_UpdateAsync")).Throws(new ArgumentNullException());
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);
            var resultGetAll = await vehicleModelRepository.GetAllVehicleModelsAsync();
            Fixture fixture = new Fixture();
            VehicleModel vehicleModel = fixture.Build<VehicleModel>()
                .With(vehicleModel => vehicleModel.VehicleModelId, resultGetAll.First().VehicleModelId)
                .With(vehicleModel => vehicleModel.VehicleModelName, Faker.Name.First())
                .Create<VehicleModel>();

            // Act
            var resultAction = () => vehicleModelRepository.UpdateAsync(vehicleModel);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleModel_UpdateAsync"), Times.Exactly(1));
        }

    }
}
