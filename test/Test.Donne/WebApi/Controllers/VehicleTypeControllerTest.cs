using AutoFixture;
using Domain.Donne;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.SeedWork;
using WebApi.Donne.Infrastructure.VehicleTypeRepository;

namespace Test.Donne.WebApi.Controllers.VehicleTypeControllerTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Controllers > VehicleTypeController")]
    public class VehicleTypeControllerTest
    {
        [TestMethod]
        public async Task Get_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleTypeController vehicleTypeController = new VehicleTypeController(mockLogger.Object);

            // Act
            var result = await vehicleTypeController.GetVehicleType();
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("VehicleType_GetAllAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void Get_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleType_GetAllAsync")).Throws(new Exception());
            VehicleTypeController vehicleTypeController = new VehicleTypeController(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleTypeController.GetVehicleType());

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleType_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetById_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleTypeController vehicleTypeController = new VehicleTypeController(mockLogger.Object);
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);
            var getAll = await vehicleTypeRepository.GetAllAsync();

            // Act
            var result = await vehicleTypeController.GetVehicleType(getAll.First().VehicleTypeId);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("VehicleType_GetByIdAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void GetById_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleType_GetByIdAsync")).Throws(new Exception());
            VehicleTypeController vehicleTypeController = new VehicleTypeController(mockLogger.Object);
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);
            var getAll = vehicleTypeRepository.GetAll();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleTypeController.GetVehicleType(getAll.First().VehicleTypeId));

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleType_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Post_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleTypeController vehicleTypeController = new VehicleTypeController(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleTypeModel vehicleTypeModel = fixture.Build<VehicleTypeModel>()
                .With(vehicleTypeModel => vehicleTypeModel.VehicleTypeName, Faker.Name.First())
                .Create<VehicleTypeModel>();

            // Act
            await vehicleTypeController.Post(vehicleTypeModel);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleType_InsertAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void Post_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleType_InsertAsync")).Throws(new Exception());
            VehicleTypeController vehicleTypeController = new VehicleTypeController(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleTypeModel vehicleTypeModel = fixture.Build<VehicleTypeModel>()
                .With(vehicleTypeModel => vehicleTypeModel.VehicleTypeName, Faker.Name.First())
                .Create<VehicleTypeModel>();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleTypeController.Post(vehicleTypeModel));

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleType_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleTypeController vehicleTypeController = new VehicleTypeController(mockLogger.Object);
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);
            var getAll = vehicleTypeRepository.GetAll();
            Fixture fixture = new Fixture();
            VehicleTypeModel vehicleTypeModel = fixture.Build<VehicleTypeModel>()
                .With(vehicleTypeModel => vehicleTypeModel.VehicleTypeId, getAll.First().VehicleTypeId)
                .With(vehicleTypeModel => vehicleTypeModel.VehicleTypeName, Faker.Name.First())
                .Create<VehicleTypeModel>();

            // Act
            await vehicleTypeController.Update(vehicleTypeModel);
            var result = await vehicleTypeController.GetVehicleType(getAll.First().VehicleTypeId);
            ObjectResult objectResult = (ObjectResult)result;
            var vehicleTypeModelResult = (VehicleTypeModel)objectResult.Value;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual(vehicleTypeModelResult.VehicleTypeId, vehicleTypeModel.VehicleTypeId);
            Assert.AreEqual(vehicleTypeModelResult.VehicleTypeName, vehicleTypeModel.VehicleTypeName);
            Assert.AreNotEqual(vehicleTypeModelResult.VehicleTypeName, getAll.First().VehicleTypeName);
            mockLogger.Verify(x => x.Trace("VehicleType_UpdateAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void Update_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleType_UpdateAsync")).Throws(new Exception());
            VehicleTypeController vehicleTypeController = new VehicleTypeController(mockLogger.Object);
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);
            var getAll = vehicleTypeRepository.GetAll();
            Fixture fixture = new Fixture();
            VehicleTypeModel vehicleTypeModel = fixture.Build<VehicleTypeModel>()
                .With(vehicleTypeModel => vehicleTypeModel.VehicleTypeId, getAll.First().VehicleTypeId)
                .With(vehicleTypeModel => vehicleTypeModel.VehicleTypeName, Faker.Name.First())
                .Create<VehicleTypeModel>();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleTypeController.Update(vehicleTypeModel));

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleType_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Delete_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleTypeController vehicleTypeController = new VehicleTypeController(mockLogger.Object);
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);
            var getAll = vehicleTypeRepository.GetAll();

            // Act
            await vehicleTypeController.Delete(getAll.First().VehicleTypeId);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleType_DeleteAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void Delete_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleType_DeleteAsync")).Throws(new Exception());
            VehicleTypeController vehicleTypeController = new VehicleTypeController(mockLogger.Object);
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);
            var getAll = vehicleTypeRepository.GetAll();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleTypeController.Delete(getAll.First().VehicleTypeId));

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleType_DeleteAsync"), Times.Exactly(1));
        }
    }
}
