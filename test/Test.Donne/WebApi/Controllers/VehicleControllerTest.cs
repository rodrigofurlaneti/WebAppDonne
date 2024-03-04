using AutoFixture;
using Domain.Donne;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Controllers
{
    [TestClass]
    [TestCategory("Donne > WebApi > Controllers > VehicleController")]
    public class VehicleControllerTest
    {
        [TestMethod]
        public async Task Get_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleController vehicleController = new VehicleController(mockLogger.Object);

            // Act
            var result = await vehicleController.Get();
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("Vehicle_GetAllAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void Get_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Vehicle_GetAllAsync")).Throws(new Exception());
            VehicleController vehicleController = new VehicleController(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleController.Get());

            // Assert
            mockLogger.Verify(x => x.TraceException("Vehicle_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetById_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleController vehicleController = new VehicleController(mockLogger.Object);
            var getAll = await vehicleController.Get();
            var okResult = getAll as OkObjectResult;
            var listVehicleModel = (List<Vehicle>)okResult.Value;
            var obj = listVehicleModel.First();

            // Act
            var result = await vehicleController.Get(obj.VehicleId);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("Vehicle_GetByIdAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public async Task GetById_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Vehicle_GetByIdAsync")).Throws(new Exception());
            VehicleController vehicleController = new VehicleController(mockLogger.Object);
            var getAll = await vehicleController.Get();
            var okResult = getAll as OkObjectResult;
            var listVehicleModel = (List<Vehicle>)okResult.Value;
            var obj = listVehicleModel.First();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleController.Get(obj.VehicleId));

            // Assert
            mockLogger.Verify(x => x.TraceException("Vehicle_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Post_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleController vehicleController = new VehicleController(mockLogger.Object);
            Fixture fixture = new Fixture();
            Vehicle vehicle = fixture.Build<Vehicle>()
                .With(vehicle => vehicle.EntryTime, DateTime.Now.ToString())
                .With(vehicle => vehicle.DepartureTime, DateTime.Now.ToString())
                .With(vehicle => vehicle.EntryDate, DateTime.Now.ToString())
                .With(vehicle => vehicle.DateInsert, DateTime.Now)
                .With(vehicle => vehicle.DateUpdate, DateTime.Now)
                .With(vehicle => vehicle.DepartureDate, DateTime.Now.ToString())
                .With(vehicle => vehicle.DepartureTime, DateTime.Now.ToString())
                .With(vehicle => vehicle.Parked, 1)
                .With(vehicle => vehicle.VehicleBrandName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleColorName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleTypeName, Faker.Name.First())
                .With(vehicle => vehicle.VehicleModelName, Faker.Name.First())
                .With(vehicle => vehicle.Plate, Faker.Name.First())
                .With(vehicle => vehicle.UserId, Faker.RandomNumber.Next(1, 100))
                .With(vehicle => vehicle.UserName, Faker.Name.First())
                .Create<Vehicle>();

            // Act
            await vehicleController.Post(vehicle);

            // Assert
            mockLogger.Verify(x => x.Trace("Vehicle_InsertAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public async Task Post_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Vehicle_InsertAsync")).Throws(new Exception());
            VehicleController vehicleController = new VehicleController(mockLogger.Object);
            Fixture fixture = new Fixture();
            Vehicle vehicle = fixture.Create<Vehicle>();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleController.Post(vehicle));

            // Assert
            mockLogger.Verify(x => x.TraceException("Vehicle_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleController vehicleController = new VehicleController(mockLogger.Object);

            var getAll = await vehicleController.Get();
            var okResult = getAll as OkObjectResult;
            var listVehicleModel = (List<Vehicle>)okResult.Value;
            var obj = listVehicleModel.First();
            Fixture fixture = new Fixture();
            Vehicle vehicle = fixture.Build<Vehicle>()
                    .With(vehicle => vehicle.VehicleId, obj.VehicleId)
                    .With(vehicle => vehicle.EntryTime,"00:00")
                    .With(vehicle => vehicle.DepartureTime, "00:00")
                    .With(vehicle => vehicle.EntryDate, "01/01/1900")
                    .With(vehicle => vehicle.DateInsert, DateTime.Now)
                    .With(vehicle => vehicle.DateUpdate, DateTime.Now)
                    .With(vehicle => vehicle.DepartureDate, "01/01/1900")
                    .With(vehicle => vehicle.DepartureTime, "00:00")
                    .With(vehicle => vehicle.Parked, 1)
                    .With(vehicle => vehicle.VehicleBrandName, Faker.Name.First())
                    .With(vehicle => vehicle.VehicleColorName, Faker.Name.First())
                    .With(vehicle => vehicle.VehicleTypeName, Faker.Name.First())
                    .With(vehicle => vehicle.VehicleModelName, Faker.Name.First())
                    .With(vehicle => vehicle.Plate, "FTF1529")
                    .With(vehicle => vehicle.UserId, Faker.RandomNumber.Next(1, 100))
                    .With(vehicle => vehicle.UserName, Faker.Name.First())
                    .Create<Vehicle>();

            // Act
            await vehicleController.Update(vehicle);
            var result = await vehicleController.Get(obj.VehicleId);
            ObjectResult objectResult = (ObjectResult)result;
            var vehicleResult = (Vehicle)objectResult.Value;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual(vehicleResult.VehicleId, vehicle.VehicleId);
            Assert.AreNotEqual(vehicleResult.Plate, obj.Plate);
            mockLogger.Verify(x => x.Trace("Vehicle_UpdateAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public async Task Update_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("Vehicle_UpdateAsync")).Throws(new Exception());
            VehicleController vehicleController = new VehicleController(mockLogger.Object);
            var getAll = await vehicleController.Get();
            var okResult = getAll as OkObjectResult;
            var listVehicleModel = (List<Vehicle>)okResult.Value;
            var obj = listVehicleModel.First();
            Fixture fixture = new Fixture();
            Vehicle vehicle = fixture.Build<Vehicle>()
                .With(vehicle => vehicle.VehicleId, obj.VehicleId)
                .Create<Vehicle>();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleController.Update(vehicle));

            // Assert
            mockLogger.Verify(x => x.TraceException("Vehicle_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Delete_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleController vehicleController = new VehicleController(mockLogger.Object);
            var getAll = await vehicleController.Get();
            var okResult = getAll as OkObjectResult;
            var listVehicleModel = (List<Vehicle>)okResult.Value;
            var obj = listVehicleModel.First();

            // Act
            await vehicleController.Delete(obj.VehicleId);

            // Assert
            mockLogger.Verify(x => x.Trace("Vehicle_DeleteAsync"), Times.Exactly(2));
        }
    }
}
