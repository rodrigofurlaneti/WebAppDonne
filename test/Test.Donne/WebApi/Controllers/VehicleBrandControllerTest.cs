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
    [TestCategory("Donne > WebApi > Controllers > VehicleBrandController")]
    public class VehicleBrandControllerTest
    {
        [TestMethod]
        public async Task Get_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleBrandController vehicleBrandController = new VehicleBrandController(mockLogger.Object);

            // Act
            var result = await vehicleBrandController.Get();
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("VehicleBrand_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetAllBrandsAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Get_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>(); 
            mockLogger.Setup(x => x.Trace("VehicleBrand_GetAllAsync")).Throws(new Exception());
            VehicleBrandController vehicleBrandController = new VehicleBrandController(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleBrandController.Get());

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleBrand_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetById_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleBrandController vehicleBrandController = new VehicleBrandController(mockLogger.Object);
            var getAll = await vehicleBrandController.Get();
            var okResult = getAll as OkObjectResult;
            var listVehicleBrandModel = (List<VehicleBrandModel>)okResult.Value;
            var obj = listVehicleBrandModel.First();
            
            // Act
            var result = await vehicleBrandController.Get(obj.VehicleBrandId);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("VehicleBrand_GetByIdAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public async Task GetById_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleBrand_GetByIdAsync")).Throws(new Exception());
            VehicleBrandController vehicleBrandController = new VehicleBrandController(mockLogger.Object);
            var getAll = await vehicleBrandController.Get();
            var okResult = getAll as OkObjectResult;
            var listVehicleBrandModel = (List<VehicleBrandModel>)okResult.Value;
            var obj = listVehicleBrandModel.First();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleBrandController.Get(obj.VehicleBrandId));

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleBrand_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Post_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleBrandController vehicleBrandController = new VehicleBrandController(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleBrandModel vehicleBrandModel = fixture.Create<VehicleBrandModel>();

            // Act
            await vehicleBrandController.Post(vehicleBrandModel);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleBrand_InsertAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public async Task Post_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleBrand_InsertAsync")).Throws(new Exception());
            VehicleBrandController vehicleBrandController = new VehicleBrandController(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleBrandModel vehicleBrandModel = fixture.Create<VehicleBrandModel>();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleBrandController.Post(vehicleBrandModel));

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleBrand_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleBrandController vehicleBrandController = new VehicleBrandController(mockLogger.Object);

            var getAll = await vehicleBrandController.Get();
            var okResult = getAll as OkObjectResult;
            var listVehicleBrandModel = (List<VehicleBrandModel>)okResult.Value;
            var obj = listVehicleBrandModel.First();
            Fixture fixture = new Fixture();
            VehicleBrandModel vehicleBrandModel = fixture.Build<VehicleBrandModel>()
                .With(vehicleBrandModel => vehicleBrandModel.VehicleBrandId, obj.VehicleBrandId)
                .Create<VehicleBrandModel>();

            // Act
            await vehicleBrandController.Update(vehicleBrandModel);
            var result = await vehicleBrandController.Get(obj.VehicleBrandId);
            ObjectResult objectResult = (ObjectResult)result;
            var vehicleBrandModelResult = (VehicleBrandModel)objectResult.Value;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual(vehicleBrandModelResult.VehicleBrandId, vehicleBrandModel.VehicleBrandId);
            Assert.AreNotEqual(vehicleBrandModelResult.VehicleBrandName, vehicleBrandModel.VehicleBrandName);
            mockLogger.Verify(x => x.Trace("VehicleBrand_UpdateAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public async Task Update_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleBrand_UpdateAsync")).Throws(new Exception());
            VehicleBrandController vehicleBrandController = new VehicleBrandController(mockLogger.Object);
            var getAll = await vehicleBrandController.Get();
            var okResult = getAll as OkObjectResult;
            var listVehicleBrandModel = (List<VehicleBrandModel>)okResult.Value;
            var obj = listVehicleBrandModel.First();
            Fixture fixture = new Fixture();
            VehicleBrandModel vehicleBrandModel = fixture.Build<VehicleBrandModel>()
                .With(vehicleBrandModel => vehicleBrandModel.VehicleBrandId, obj.VehicleBrandId)
                .Create<VehicleBrandModel>();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleBrandController.Update(vehicleBrandModel));

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleBrand_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Delete_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleBrandController vehicleBrandController = new VehicleBrandController(mockLogger.Object);
            var getAll = await vehicleBrandController.Get();
            var okResult = getAll as OkObjectResult;
            var listVehicleBrandModel = (List<VehicleBrandModel>)okResult.Value;
            var obj = listVehicleBrandModel.First();

            // Act
            await vehicleBrandController.Delete(obj.VehicleBrandId);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleBrand_DeleteAsync"), Times.Exactly(2));
        }
    }
}
