using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Infrastructure.VehicleTypeRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > BuyerRepository")]
    public class VehicleTypeRepositoryTest
    {
        [TestMethod]
        public void GetAllVehicleType_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);

            // Act
            var result = vehicleTypeRepository.GetAllVehicleTypes();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("VehicleType_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllVehicleType_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleType_GetAll")).Throws(new ArgumentNullException());
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);

            // Act
            var resultAction = () => vehicleTypeRepository.GetAllVehicleTypes();
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.Trace("VehicleType_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("VehicleType_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetAllVehicleTypeAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);

            // Act
            var result = await vehicleTypeRepository.GetAllVehicleTypesAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("VehicleType_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllVehicleTypeAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleType_GetAllAsync")).Throws(new ArgumentNullException());
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);

            // Act
            var resultAction = () => vehicleTypeRepository.GetAllVehicleTypesAsync();
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.Trace("VehicleType_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("VehicleType_GetAllAsync"), Times.Exactly(1));
        }
    }
}
