using AutoFixture;
using Domain.Donne;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.SeedWork;
using WebApi.Donne.Infrastructure.Vehicle;
using WebApi.Donne.Infrastructure.VehicleColor;

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
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);
            var getAll = vehicleColorRepository.GetAll();

            // Act
            var result = await vehicleColorController.GetVehicleColor(getAll.First().VehicleColorId);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("VehicleColor_GetByIdAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void GetById_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleColor_GetByIdAsync")).Throws(new Exception());
            VehicleColorController vehicleColorController = new VehicleColorController(mockLogger.Object);
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);
            var getAll = vehicleColorRepository.GetAll();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleColorController.GetVehicleColor(getAll.First().VehicleColorId));

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
        public void Post_Erro()
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
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);
            var getAll = vehicleColorRepository.GetAll();
            Fixture fixture = new Fixture();
            VehicleColorModel vehicleColorModel = fixture.Build<VehicleColorModel>()
                .With(vehicleColorModel => vehicleColorModel.VehicleColorId, getAll.First().VehicleColorId)
                .With(vehicleColorModel => vehicleColorModel.VehicleColorName, Faker.Name.First())
                .Create<VehicleColorModel>();

            // Act
            await vehicleColorController.Update(vehicleColorModel);
            var result = await vehicleColorController.GetVehicleColor(getAll.First().VehicleColorId);
            ObjectResult objectResult = (ObjectResult)result;
            var vehicleColorModelResult = (VehicleColorModel)objectResult.Value;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual(vehicleColorModelResult.VehicleColorId, vehicleColorModel.VehicleColorId);
            Assert.AreNotEqual(vehicleColorModelResult.VehicleColorName, getAll.First().VehicleColorName);
            mockLogger.Verify(x => x.Trace("VehicleColor_UpdateAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void Update_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleColor_UpdateAsync")).Throws(new Exception());
            VehicleColorController vehicleColorController = new VehicleColorController(mockLogger.Object);
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);
            var getAll = vehicleColorRepository.GetAll();
            Fixture fixture = new Fixture();
            VehicleColorModel vehicleColorModel = fixture.Build<VehicleColorModel>()
                .With(vehicleColorModel => vehicleColorModel.VehicleColorId, getAll.First().VehicleColorId)
                .With(vehicleColorModel => vehicleColorModel.VehicleColorName, Faker.Name.First())
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
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);
            var getAll = vehicleColorRepository.GetAll();

            // Act
            await vehicleColorController.Delete(getAll.First().VehicleColorId);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleColor_DeleteAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void Delete_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleColor_DeleteAsync")).Throws(new Exception());
            VehicleColorController vehicleColorController = new VehicleColorController(mockLogger.Object);
            VehicleColorRepository vehicleColorRepository = new VehicleColorRepository(mockLogger.Object);
            var getAll = vehicleColorRepository.GetAll();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleColorController.Delete(getAll.First().VehicleColorId));

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleColor_DeleteAsync"), Times.Exactly(1));
        }
    }
}
