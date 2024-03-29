﻿using AutoFixture;
using Domain.Donne;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.SeedWork;
using WebApi.Donne.Infrastructure.VehicleModel;
using WebApi.Donne.Infrastructure.VehicleTypeRepository;

namespace Test.Donne.WebApi.Controllers.VehicleModelControllerTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Controllers > VehicleModelController")]
    public class VehicleModelControllerTest
    {
        [TestMethod]
        public async Task Get_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleModelController vehicleModelController = new VehicleModelController(mockLogger.Object);

            // Act
            var result = await vehicleModelController.GetVehicleModel();
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
            mockLogger.Setup(x => x.Trace("VehicleModel_GetAllAsync")).Throws(new ArgumentNullException());
            VehicleModelController vehicleModelController = new VehicleModelController(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => vehicleModelController.GetVehicleModel());

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleModel_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetById_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleModelController vehicleModelController = new VehicleModelController(mockLogger.Object);
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);
            var getAll = vehicleModelRepository.GetAll();

            // Act
            var result = await vehicleModelController.GetVehicleModel(getAll.First().VehicleModelId);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("VehicleModel_GetByIdAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void GetById_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleModel_GetByIdAsync")).Throws(new Exception());
            VehicleModelController vehicleModelController = new VehicleModelController(mockLogger.Object);
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);
            var getAll = vehicleModelRepository.GetAll();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleModelController.GetVehicleModel(getAll.First().VehicleModelId));

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
        public void Post_Erro()
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
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);
            var getAll = vehicleModelRepository.GetAll();
            Fixture fixture = new Fixture();
            VehicleModel vehicleModel = fixture.Build<VehicleModel>()
                .With(vehicleModel => vehicleModel.VehicleModelId, getAll.First().VehicleModelId)
                .With(vehicleModel => vehicleModel.VehicleModelName, Faker.Name.First())
                .Create<VehicleModel>();

            // Act
            await vehicleModelController.Update(vehicleModel);
            var result = await vehicleModelController.GetVehicleModel(getAll.First().VehicleModelId);
            ObjectResult objectResult = (ObjectResult)result;
            var vehicleModelResult = (VehicleModel)objectResult.Value;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual(vehicleModelResult.VehicleModelId, vehicleModel.VehicleModelId);
            Assert.AreNotEqual(vehicleModelResult.VehicleModelName, getAll.First().VehicleModelName);
            mockLogger.Verify(x => x.Trace("VehicleModel_UpdateAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void Update_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleModel_UpdateAsync")).Throws(new Exception());
            VehicleModelController vehicleModelController = new VehicleModelController(mockLogger.Object);
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);
            var getAll = vehicleModelRepository.GetAll();
            Fixture fixture = new Fixture();
            VehicleModel vehicleModel = fixture.Build<VehicleModel>()
                .With(vehicleModel => vehicleModel.VehicleModelId, getAll.First().VehicleModelId)
                .With(vehicleModel => vehicleModel.VehicleModelName, Faker.Name.First())
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
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);
            var getAll = vehicleModelRepository.GetAll();

            // Act
            await vehicleModelController.Delete(getAll.First().VehicleModelId);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleModel_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("VehicleModel_DeleteAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void Delete_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleModel_DeleteAsync")).Throws(new Exception());
            VehicleModelController vehicleModelController = new VehicleModelController(mockLogger.Object);
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(mockLogger.Object);
            var getAll = vehicleModelRepository.GetAll();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleModelController.Delete(getAll.First().VehicleModelId));

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleModel_DeleteAsync"), Times.Exactly(1));
        }
    }
}
