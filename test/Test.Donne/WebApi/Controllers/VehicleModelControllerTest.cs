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
    [TestCategory("Donne > WebApi > Controllers > StockInventoryController")]
    public class VehicleModelControllerTest
    {
        [TestMethod]
        public async Task Get_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleModelController vehicleModelController = new VehicleModelController(mockLogger.Object);

            // Act
            var result = await vehicleModelController.Get();
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("VehicleModel_GetAllAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void Get_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleModel_GetAllAsync")).Throws(new Exception());
            VehicleModelController vehicleModelController = new VehicleModelController(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleModelController.Get());

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleModel_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetById_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleModelController vehicleModelController = new VehicleModelController(mockLogger.Object);
            var getAll = await vehicleModelController.Get();
            var okResult = getAll as OkObjectResult;
            var listVehicleModelModel = (List<VehicleModel>)okResult.Value;
            var obj = listVehicleModelModel.First();

            // Act
            var result = await vehicleModelController.Get(obj.VehicleModelId);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("VehicleModel_GetByIdAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public async Task GetById_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleModel_GetByIdAsync")).Throws(new Exception());
            VehicleModelController vehicleModelController = new VehicleModelController(mockLogger.Object);
            var getAll = await vehicleModelController.Get();
            var okResult = getAll as OkObjectResult;
            var listVehicleModelModel = (List<VehicleModel>)okResult.Value;
            var obj = listVehicleModelModel.First();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleModelController.Get(obj.VehicleModelId));

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleModel_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Post_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleModelController vehicleModelController = new VehicleModelController(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleModel vehicleModelModel = fixture.Create<VehicleModel>();

            // Act
            await vehicleModelController.Post(vehicleModelModel);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleModel_InsertAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public async Task Post_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleModel_InsertAsync")).Throws(new Exception());
            VehicleModelController vehicleModelController = new VehicleModelController(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleModel vehicleModelModel = fixture.Create<VehicleModel>();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleModelController.Post(vehicleModelModel));

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleModel_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleModelController vehicleModelController = new VehicleModelController(mockLogger.Object);

            var getAll = await vehicleModelController.Get();
            var okResult = getAll as OkObjectResult;
            var listVehicleModel = (List<VehicleModel>)okResult.Value;
            var obj = listVehicleModel.First();
            Fixture fixture = new Fixture();
            VehicleModel vehicleModel = fixture.Build<VehicleModel>()
                .With(vehicleModel => vehicleModel.VehicleModelId, obj.VehicleModelId)
                .With(vehicleModel => vehicleModel.VehicleModelName, Faker.Name.First())
                .Create<VehicleModel>();

            // Act
            await vehicleModelController.Update(vehicleModel);
            var result = await vehicleModelController.Get(obj.VehicleModelId);
            ObjectResult objectResult = (ObjectResult)result;
            var vehicleModelResult = (VehicleModel)objectResult.Value;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual(vehicleModelResult.VehicleModelId, vehicleModel.VehicleModelId);
            Assert.AreNotEqual(vehicleModelResult.VehicleModelName, obj.VehicleModelName);
            mockLogger.Verify(x => x.Trace("VehicleModel_UpdateAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public async Task Update_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleModel_UpdateAsync")).Throws(new Exception());
            VehicleModelController vehicleModelController = new VehicleModelController(mockLogger.Object);
            var getAll = await vehicleModelController.Get();
            var okResult = getAll as OkObjectResult;
            var listVehicleModel = (List<VehicleModel>)okResult.Value;
            var obj = listVehicleModel.First();
            Fixture fixture = new Fixture();
            VehicleModel vehicleModel = fixture.Build<VehicleModel>()
                .With(vehicleModel => vehicleModel.VehicleModelId, obj.VehicleModelId)
                .Create<VehicleModel>();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleModelController.Update(vehicleModel));

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleModel_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Delete_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleModelController vehicleModelController = new VehicleModelController(mockLogger.Object);
            var getAll = await vehicleModelController.Get();
            var okResult = getAll as OkObjectResult;
            var listVehicleModelModel = (List<VehicleModel>)okResult.Value;
            var obj = listVehicleModelModel.First();

            // Act
            await vehicleModelController.Delete(obj.VehicleModelId);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleModel_GetAllAsync"), Times.Exactly(2));
            mockLogger.Verify(x => x.Trace("DeleteAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("VehicleModel_DeleteAsync"), Times.Exactly(1));
        }
    }
}
