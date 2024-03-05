using AutoFixture;
using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Infrastructure.VehicleColorRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > VehicleColorRepository")]
    public class VehicleColorRepositoryTest
    {
        [TestMethod]
        public void GetAll_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);

            // Act
            var result = vehicleColorRepository.GetAllVehicleColors();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("VehicleColor_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAll_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleColor_GetAll")).Throws(new ArgumentNullException());
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);

            // Act
            var resultAction = () => vehicleColorRepository.GetAllVehicleColors();
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.Trace("VehicleColor_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("VehicleColor_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetAllAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);

            // Act
            var result = await vehicleColorRepository.GetAllVehicleColorsAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("VehicleColor_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleColor_GetAllAsync")).Throws(new ArgumentNullException());
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);

            // Act
            var resultAction = () => vehicleColorRepository.GetAllVehicleColorsAsync();
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.Trace("VehicleColor_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("VehicleColor_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);
            var resultGetAll = vehicleColorRepository.GetAllVehicleColors();

            // Act
            var result = vehicleColorRepository.GetById(resultGetAll.First().VehicleColorId);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("VehicleColor_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleColor_GetById")).Throws(new ArgumentNullException());
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);
            var resultGetAll = vehicleColorRepository.GetAllVehicleColors();

            // Act
            var resultAction = () => vehicleColorRepository.GetById(resultGetAll.First().VehicleColorId);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.Trace("VehicleColor_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("VehicleColor_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);
            var resultGetAll = await vehicleColorRepository.GetAllVehicleColorsAsync();

            // Act
            var result = await vehicleColorRepository.GetByIdAsync(resultGetAll.First().VehicleColorId);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("VehicleColor_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleColor_GetByIdAsync")).Throws(new ArgumentNullException());
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);
            var resultGetAll = await vehicleColorRepository.GetAllVehicleColorsAsync();

            // Act
            var resultAction = () => vehicleColorRepository.GetByIdAsync(resultGetAll.First().VehicleColorId);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.Trace("VehicleColor_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("VehicleColor_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Insert_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleColorModel vehicleColorModel = fixture.Build<VehicleColorModel>()
                .With(vehicleColorModel => vehicleColorModel.VehicleColorId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicleColorModel => vehicleColorModel.VehicleColorName, Faker.Name.First())
                .Create<VehicleColorModel>();

            // Act
            vehicleColorRepository.Insert(vehicleColorModel);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleColor_Insert"), Times.Exactly(1));
        }

        [TestMethod]
        public void Insert_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleColor_Insert")).Throws(new ArgumentNullException());
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleColorModel vehicleColorModel = fixture.Build<VehicleColorModel>()
                .With(vehicleColorModel => vehicleColorModel.VehicleColorId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicleColorModel => vehicleColorModel.VehicleColorName, Faker.Name.First())
                .Create<VehicleColorModel>();

            // Act
            var resultAction = () => vehicleColorRepository.Insert(vehicleColorModel);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleColor_Insert"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task InsertAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleColorModel vehicleColorModel = fixture.Build<VehicleColorModel>()
                .With(vehicleColorModel => vehicleColorModel.VehicleColorId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicleColorModel => vehicleColorModel.VehicleColorName, Faker.Name.First())
                .Create<VehicleColorModel>();

            // Act
            await vehicleColorRepository.InsertAsync(vehicleColorModel);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleColor_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void InsertAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleColor_InsertAsync")).Throws(new ArgumentNullException());
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleColorModel vehicleColorModel = fixture.Build<VehicleColorModel>()
                .With(vehicleColorModel => vehicleColorModel.VehicleColorId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicleColorModel => vehicleColorModel.VehicleColorName, Faker.Name.First())
                .Create<VehicleColorModel>();

            // Act
            var resultAction = () => vehicleColorRepository.InsertAsync(vehicleColorModel);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleColor_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);
            var resultGetAll = vehicleColorRepository.GetAllVehicleColors();

            // Act
            vehicleColorRepository.Delete(resultGetAll.First().VehicleColorId);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleColor_Delete"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleColor_Delete")).Throws(new ArgumentNullException());
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);
            var resultGetAll = vehicleColorRepository.GetAllVehicleColors();

            // Act
            var resultAction = () => vehicleColorRepository.Delete(resultGetAll.First().VehicleColorId);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleColor_Delete"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task DeleteAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);
            var resultGetAll = await vehicleColorRepository.GetAllVehicleColorsAsync();

            // Act
            await vehicleColorRepository.DeleteAsync(resultGetAll.First().VehicleColorId);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleColor_DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task DeleteAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleColor_DeleteAsync")).Throws(new ArgumentNullException());
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);
            var resultGetAll = await vehicleColorRepository.GetAllVehicleColorsAsync();

            // Act
            var resultAction = () => vehicleColorRepository.DeleteAsync(resultGetAll.First().VehicleColorId);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleColor_DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);
            var resultGetAll = vehicleColorRepository.GetAllVehicleColors();
            Fixture fixture = new Fixture();
            VehicleColorModel vehicleColorModel = fixture.Build<VehicleColorModel>()
                .With(vehicleColorModel => vehicleColorModel.VehicleColorId, resultGetAll.First().VehicleColorId)
                .With(vehicleColorModel => vehicleColorModel.VehicleColorName, Faker.Name.First())
                .Create<VehicleColorModel>();

            // Act
            vehicleColorRepository.Update(vehicleColorModel);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleColor_Update"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleColor_Update")).Throws(new ArgumentNullException());
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);
            var resultGetAll = vehicleColorRepository.GetAllVehicleColors();
            Fixture fixture = new Fixture();
            VehicleColorModel vehicleColorModel = fixture.Build<VehicleColorModel>()
                .With(vehicleColorModel => vehicleColorModel.VehicleColorId, resultGetAll.First().VehicleColorId)
                .With(vehicleColorModel => vehicleColorModel.VehicleColorName, Faker.Name.First())
                .Create<VehicleColorModel>();

            // Act
            var resultAction = () => vehicleColorRepository.Update(vehicleColorModel);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleColor_Update"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);
            var resultGetAll = await vehicleColorRepository.GetAllVehicleColorsAsync();
            Fixture fixture = new Fixture();
            VehicleColorModel vehicleColorModel = fixture.Build<VehicleColorModel>()
                .With(vehicleColorModel => vehicleColorModel.VehicleColorId, resultGetAll.First().VehicleColorId)
                .With(vehicleColorModel => vehicleColorModel.VehicleColorName, Faker.Name.First())
                .Create<VehicleColorModel>();

            // Act
            await vehicleColorRepository.UpdateAsync(vehicleColorModel);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleColor_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleColor_UpdateAsync")).Throws(new ArgumentNullException());
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);
            var resultGetAll = await vehicleColorRepository.GetAllVehicleColorsAsync();
            Fixture fixture = new Fixture();
            VehicleColorModel vehicleColorModel = fixture.Build<VehicleColorModel>()
                .With(vehicleColorModel => vehicleColorModel.VehicleColorId, resultGetAll.First().VehicleColorId)
                .With(vehicleColorModel => vehicleColorModel.VehicleColorName, Faker.Name.First())
                .Create<VehicleColorModel>();

            // Act
            var resultAction = () => vehicleColorRepository.UpdateAsync(vehicleColorModel);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleColor_UpdateAsync"), Times.Exactly(1));
        }

    }
}
