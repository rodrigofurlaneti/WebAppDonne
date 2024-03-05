using AutoFixture;
using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure.SeedWork;
using WebApi.Donne.Infrastructure.Vehicle;

namespace Test.Donne.WebApi.Infrastructure.VehicleRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > VehicleRepository")]
    public class VehicleRepositoryTest
    {
        [TestMethod]
        public void GetAll_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleRepository vehicleRepository = new VehicleRepository(mockLogger.Object);

            // Act
            var result = vehicleRepository.GetAll();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Vehicle_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAll_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Vehicle_GetAll")).Throws(new ArgumentNullException());
            VehicleRepository vehicleRepository = new VehicleRepository(mockLogger.Object);

            // Act
            var resultAction = () => vehicleRepository.GetAll();
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.Trace("Vehicle_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("Vehicle_GetAll"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetAllAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleRepository vehicleRepository = new VehicleRepository(mockLogger.Object);

            // Act
            var result = await vehicleRepository.GetAllAsync();

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Vehicle_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAllAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Vehicle_GetAllAsync")).Throws(new ArgumentNullException());
            VehicleRepository vehicleRepository = new VehicleRepository(mockLogger.Object);

            // Act
            var resultAction = () => vehicleRepository.GetAllAsync();
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.Trace("Vehicle_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("Vehicle_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleRepository vehicleRepository = new VehicleRepository(mockLogger.Object);
            var resultGetAll = vehicleRepository.GetAll();

            // Act
            var result = vehicleRepository.GetById(resultGetAll.First().VehicleId);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Vehicle_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Vehicle_GetById")).Throws(new ArgumentNullException());
            VehicleRepository vehicleRepository = new VehicleRepository(mockLogger.Object);
            var resultGetAll = vehicleRepository.GetAll();

            // Act
            var resultAction = () => vehicleRepository.GetById(resultGetAll.First().VehicleId);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("Vehicle_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleRepository vehicleRepository = new VehicleRepository(mockLogger.Object);
            var resultGetAll = await vehicleRepository.GetAllAsync();

            // Act
            var result = await vehicleRepository.GetByIdAsync(resultGetAll.First().VehicleId);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("Vehicle_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Vehicle_GetByIdAsync")).Throws(new ArgumentNullException());
            VehicleRepository vehicleRepository = new VehicleRepository(mockLogger.Object);
            var resultGetAll = vehicleRepository.GetAll();

            // Act
            var resultAction = () => vehicleRepository.GetByIdAsync(resultGetAll.First().VehicleId);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("Vehicle_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Insert_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleRepository vehicleRepository = new VehicleRepository(mockLogger.Object);
            Fixture fixture = new Fixture();
            Vehicle vehicle = fixture.Build<Vehicle>()
                .With(vehicle => vehicle.VehicleId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleTypeId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleTypeName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleBrandId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleBrandName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleModelId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleModelName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleColorId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleColorName, Faker.Name.First())
                .With(vehicle => vehicle.DateInsert, DateTime.Now)
                .With(vehicle => vehicle.DateUpdate, DateTime.Now)
                .With(vehicle => vehicle.DepartureDate, "01/01/1900")
                .With(vehicle => vehicle.DepartureTime, "01:01")
                .With(vehicle => vehicle.EntryDate, "01/01/1900")
                .With(vehicle => vehicle.EntryTime, "01:01")
                .With(vehicle => vehicle.Plate, "FTF-4398")
                .With(vehicle => vehicle.Parked, 1)
                .Create<Vehicle>();

            // Act
            vehicleRepository.Insert(vehicle);

            // Assert
            mockLogger.Verify(x => x.Trace("Vehicle_Insert"), Times.Exactly(1));
        }

        [TestMethod]
        public void Insert_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Vehicle_Insert")).Throws(new ArgumentNullException());
            VehicleRepository vehicleRepository = new VehicleRepository(mockLogger.Object);
            Fixture fixture = new Fixture();
            Vehicle vehicle = fixture.Build<Vehicle>()
                .With(vehicle => vehicle.VehicleId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleTypeId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleTypeName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleBrandId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleBrandName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleModelId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleModelName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleColorId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleColorName, Faker.Name.First())
                .With(vehicle => vehicle.DateInsert, DateTime.Now)
                .With(vehicle => vehicle.DateUpdate, DateTime.Now)
                .With(vehicle => vehicle.DepartureDate, "01/01/1900")
                .With(vehicle => vehicle.DepartureTime, "01:01")
                .With(vehicle => vehicle.EntryDate, "01/01/1900")
                .With(vehicle => vehicle.EntryTime, "01:01")
                .With(vehicle => vehicle.Plate, "FTF-4398")
                .With(vehicle => vehicle.Parked, 1)
                .Create<Vehicle>();

            // Act
            var resultAction = () => vehicleRepository.Insert(vehicle);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("Vehicle_Insert"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task InsertAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleRepository vehicleRepository = new VehicleRepository(mockLogger.Object);
            Fixture fixture = new Fixture();
            Vehicle vehicle = fixture.Build<Vehicle>()
                .With(vehicle => vehicle.VehicleId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleTypeId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleTypeName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleBrandId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleBrandName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleModelId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleModelName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleColorId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleColorName, Faker.Name.First())
                .With(vehicle => vehicle.DateInsert, DateTime.Now)
                .With(vehicle => vehicle.DateUpdate, DateTime.Now)
                .With(vehicle => vehicle.DepartureDate, "01/01/1900")
                .With(vehicle => vehicle.DepartureTime, "01:01")
                .With(vehicle => vehicle.EntryDate, "01/01/1900")
                .With(vehicle => vehicle.EntryTime, "01:01")
                .With(vehicle => vehicle.Plate, "FTF-4398")
                .With(vehicle => vehicle.Parked, 1)
                .Create<Vehicle>();

            // Act
            await vehicleRepository.InsertAsync(vehicle);

            // Assert
            mockLogger.Verify(x => x.Trace("Vehicle_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void InsertAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Vehicle_InsertAsync")).Throws(new ArgumentNullException());
            VehicleRepository vehicleRepository = new VehicleRepository(mockLogger.Object);
            Fixture fixture = new Fixture();
            Vehicle vehicle = fixture.Build<Vehicle>()
                .With(vehicle => vehicle.VehicleId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleTypeId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleTypeName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleBrandId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleBrandName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleModelId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleModelName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleColorId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleColorName, Faker.Name.First())
                .With(vehicle => vehicle.DateInsert, DateTime.Now)
                .With(vehicle => vehicle.DateUpdate, DateTime.Now)
                .With(vehicle => vehicle.DepartureDate, "01/01/1900")
                .With(vehicle => vehicle.DepartureTime, "01:01")
                .With(vehicle => vehicle.EntryDate, "01/01/1900")
                .With(vehicle => vehicle.EntryTime, "01:01")
                .With(vehicle => vehicle.Plate, "FTF-4398")
                .With(vehicle => vehicle.Parked, 1)
                .Create<Vehicle>();

            // Act
            var resultAction = () => vehicleRepository.InsertAsync(vehicle);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("Vehicle_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleRepository vehicleRepository = new VehicleRepository(mockLogger.Object);
            var resultGetAll = vehicleRepository.GetAll();

            // Act
            vehicleRepository.Delete(resultGetAll.First().VehicleId);

            // Assert
            mockLogger.Verify(x => x.Trace("Vehicle_Delete"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Vehicle_Delete")).Throws(new ArgumentNullException());
            VehicleRepository vehicleRepository = new VehicleRepository(mockLogger.Object);
            var resultGetAll = vehicleRepository.GetAll();

            // Act
            var resultAction = () => vehicleRepository.Delete(resultGetAll.First().VehicleId);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("Vehicle_Delete"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task DeleteAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleRepository vehicleRepository = new VehicleRepository(mockLogger.Object);
            var resultGetAll = await vehicleRepository.GetAllAsync();

            // Act
            await vehicleRepository.DeleteAsync(resultGetAll.First().VehicleId);

            // Assert
            mockLogger.Verify(x => x.Trace("Vehicle_DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void DeleteAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Vehicle_DeleteAsync")).Throws(new ArgumentNullException());
            VehicleRepository vehicleRepository = new VehicleRepository(mockLogger.Object);
            var resultGetAll = vehicleRepository.GetAll();

            // Act
            var resultAction = () => vehicleRepository.DeleteAsync(resultGetAll.First().VehicleId);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("Vehicle_DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleRepository vehicleRepository = new VehicleRepository(mockLogger.Object);
            var resultGetAll = vehicleRepository.GetAll();
            Fixture fixture = new Fixture();
            Vehicle vehicle = fixture.Build<Vehicle>()
                .With(vehicle => vehicle.VehicleId, resultGetAll.First().VehicleId)
                .With(vehicle => vehicle.VehicleTypeId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleTypeName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleBrandId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleBrandName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleModelId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleModelName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleColorId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleColorName, Faker.Name.First())
                .With(vehicle => vehicle.DateInsert, DateTime.Now)
                .With(vehicle => vehicle.DateUpdate, DateTime.Now)
                .With(vehicle => vehicle.DepartureDate, "01/01/1900")
                .With(vehicle => vehicle.DepartureTime, "01:01")
                .With(vehicle => vehicle.EntryDate, "01/01/1900")
                .With(vehicle => vehicle.EntryTime, "01:01")
                .With(vehicle => vehicle.Plate, "FTF-4398")
                .With(vehicle => vehicle.Parked, 1)
                .Create<Vehicle>();

            // Act
            vehicleRepository.Update(vehicle);

            // Assert
            mockLogger.Verify(x => x.Trace("Vehicle_Update"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Vehicle_Update")).Throws(new ArgumentNullException());
            VehicleRepository vehicleRepository = new VehicleRepository(mockLogger.Object);
            var resultGetAll = vehicleRepository.GetAll();
            Fixture fixture = new Fixture();
            Vehicle vehicle = fixture.Build<Vehicle>()
                .With(vehicle => vehicle.VehicleId, resultGetAll.First().VehicleId)
                .With(vehicle => vehicle.VehicleTypeId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleTypeName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleBrandId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleBrandName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleModelId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleModelName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleColorId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleColorName, Faker.Name.First())
                .With(vehicle => vehicle.DateInsert, DateTime.Now)
                .With(vehicle => vehicle.DateUpdate, DateTime.Now)
                .With(vehicle => vehicle.DepartureDate, "01/01/1900")
                .With(vehicle => vehicle.DepartureTime, "01:01")
                .With(vehicle => vehicle.EntryDate, "01/01/1900")
                .With(vehicle => vehicle.EntryTime, "01:01")
                .With(vehicle => vehicle.Plate, "FTF-4398")
                .With(vehicle => vehicle.Parked, 1)
                .Create<Vehicle>();

            // Act
            var resultAction = () => vehicleRepository.Update(vehicle);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("Vehicle_Update"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleRepository vehicleRepository = new VehicleRepository(mockLogger.Object);
            var resultGetAll = await vehicleRepository.GetAllAsync();
            Fixture fixture = new Fixture();
            Vehicle vehicle = fixture.Build<Vehicle>()
                .With(vehicle => vehicle.VehicleId, resultGetAll.First().VehicleId)
                .With(vehicle => vehicle.VehicleTypeId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleTypeName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleBrandId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleBrandName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleModelId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleModelName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleColorId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleColorName, Faker.Name.First())
                .With(vehicle => vehicle.DateInsert, DateTime.Now)
                .With(vehicle => vehicle.DateUpdate, DateTime.Now)
                .With(vehicle => vehicle.DepartureDate, "01/01/1900")
                .With(vehicle => vehicle.DepartureTime, "01:01")
                .With(vehicle => vehicle.EntryDate, "01/01/1900")
                .With(vehicle => vehicle.EntryTime, "01:01")
                .With(vehicle => vehicle.Plate, "FTF-4398")
                .With(vehicle => vehicle.Parked, 1)
                .Create<Vehicle>();

            // Act
            await vehicleRepository.UpdateAsync(vehicle);

            // Assert
            mockLogger.Verify(x => x.Trace("Vehicle_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void UpdateAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Vehicle_UpdateAsync")).Throws(new ArgumentNullException());
            VehicleRepository vehicleRepository = new VehicleRepository(mockLogger.Object);
            var resultGetAll = vehicleRepository.GetAll();
            Fixture fixture = new Fixture();
            Vehicle vehicle = fixture.Build<Vehicle>()
                .With(vehicle => vehicle.VehicleId, resultGetAll.First().VehicleId)
                .With(vehicle => vehicle.VehicleTypeId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleTypeName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleBrandId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleBrandName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleModelId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleModelName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleColorId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicle => vehicle.VehicleColorName, Faker.Name.First())
                .With(vehicle => vehicle.DateInsert, DateTime.Now)
                .With(vehicle => vehicle.DateUpdate, DateTime.Now)
                .With(vehicle => vehicle.DepartureDate, "01/01/1900")
                .With(vehicle => vehicle.DepartureTime, "01:01")
                .With(vehicle => vehicle.EntryDate, "01/01/1900")
                .With(vehicle => vehicle.EntryTime, "01:01")
                .With(vehicle => vehicle.Plate, "FTF-4398")
                .With(vehicle => vehicle.Parked, 1)
                .Create<Vehicle>();

            // Act
            var resultAction = () => vehicleRepository.UpdateAsync(vehicle);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("Vehicle_UpdateAsync"), Times.Exactly(1));
        }

    }
}
