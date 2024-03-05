using AutoFixture;
using Domain.Donne;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Controllers.VehicleColorControllerTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Controllers > VehicleColorController")]
    public class VehicleColorControllerTest
    {
        [TestMethod]
        public async Task Get_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleColorController vehicleColorController = new VehicleColorController(mockLogger.Object);

            // Act
            var result = await vehicleColorController.GetVehicleColor();
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("VehicleColor_GetAllAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void Get_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleColor_GetAllAsync")).Throws(new Exception());
            VehicleColorController vehicleColorController = new VehicleColorController(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleColorController.GetVehicleColor());

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleColor_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetById_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleColorController vehicleColorController = new VehicleColorController(mockLogger.Object);
            var getAll = await vehicleColorController.GetVehicleColor();
            var okResult = getAll as OkObjectResult;
            var listVehicleColorModel = (List<VehicleColorModel>)okResult.Value;
            var obj = listVehicleColorModel.First();

            // Act
            var result = await vehicleColorController.GetVehicleColor(obj.VehicleColorId);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("VehicleColor_GetByIdAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public async Task GetById_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleColor_GetByIdAsync")).Throws(new Exception());
            VehicleColorController vehicleColorController = new VehicleColorController(mockLogger.Object);
            var getAll = await vehicleColorController.GetVehicleColor();
            var okResult = getAll as OkObjectResult;
            var listVehicleColorModel = (List<VehicleColorModel>)okResult.Value;
            var obj = listVehicleColorModel.First();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleColorController.GetVehicleColor(obj.VehicleColorId));

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleColor_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Post_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleColorController vehicleColorController = new VehicleColorController(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleColorModel vehicleColorModel = fixture.Create<VehicleColorModel>();

            // Act
            await vehicleColorController.Post(vehicleColorModel);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleColor_InsertAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public async Task Post_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleColor_InsertAsync")).Throws(new Exception());
            VehicleColorController vehicleColorController = new VehicleColorController(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleColorModel vehicleColorModel = fixture.Create<VehicleColorModel>();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleColorController.Post(vehicleColorModel));

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleColor_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleColorController vehicleColorController = new VehicleColorController(mockLogger.Object);

            var getAll = await vehicleColorController.GetVehicleColor();
            var okResult = getAll as OkObjectResult;
            var listVehicleColorModel = (List<VehicleColorModel>)okResult.Value;
            var obj = listVehicleColorModel.First();
            Fixture fixture = new Fixture();
            VehicleColorModel vehicleColorModel = fixture.Build<VehicleColorModel>()
                .With(vehicleColorModel => vehicleColorModel.VehicleColorId, obj.VehicleColorId)
                .Create<VehicleColorModel>();

            // Act
            await vehicleColorController.Update(vehicleColorModel);
            var result = await vehicleColorController.GetVehicleColor(obj.VehicleColorId);
            ObjectResult objectResult = (ObjectResult)result;
            var vehicleColorModelResult = (VehicleColorModel)objectResult.Value;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual(vehicleColorModelResult.VehicleColorId, vehicleColorModel.VehicleColorId);
            Assert.AreNotEqual(vehicleColorModelResult.VehicleColorName, vehicleColorModel.VehicleColorName);
            mockLogger.Verify(x => x.Trace("VehicleColor_UpdateAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public async Task Update_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleColor_UpdateAsync")).Throws(new Exception());
            VehicleColorController vehicleColorController = new VehicleColorController(mockLogger.Object);
            var getAll = await vehicleColorController.GetVehicleColor();
            var okResult = getAll as OkObjectResult;
            var listVehicleColorModel = (List<VehicleColorModel>)okResult.Value;
            var obj = listVehicleColorModel.First();
            Fixture fixture = new Fixture();
            VehicleColorModel vehicleColorModel = fixture.Build<VehicleColorModel>()
                .With(vehicleColorModel => vehicleColorModel.VehicleColorId, obj.VehicleColorId)
                .Create<VehicleColorModel>();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleColorController.Update(vehicleColorModel));

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleColor_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Delete_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleColorController vehicleColorController = new VehicleColorController(mockLogger.Object);
            var getAll = await vehicleColorController.GetVehicleColor();
            var okResult = getAll as OkObjectResult;
            var listVehicleColorModel = (List<VehicleColorModel>)okResult.Value;
            var obj = listVehicleColorModel.First();

            // Act
            await vehicleColorController.Delete(obj.VehicleColorId);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleColor_DeleteAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public async Task Delete_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleColor_DeleteAsync")).Throws(new Exception());
            VehicleColorController vehicleColorController = new VehicleColorController(mockLogger.Object);
            var getAll = await vehicleColorController.GetVehicleColor();
            var okResult = getAll as OkObjectResult;
            var listVehicleColorModel = (List<VehicleColorModel>)okResult.Value;
            var obj = listVehicleColorModel.First();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleColorController.Delete(obj.VehicleColorId));

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleColor_DeleteAsync"), Times.Exactly(1));
        }
    }
}
