using AutoFixture;
using Domain.Donne;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.SeedWork;
using WebApi.Donne.Infrastructure.VehicleBrand;

namespace Test.Donne.WebApi.Controllers.VehicleBrandControllerTest
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
            var result = await vehicleBrandController.GetVehicleBrand();
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("VehicleBrand_GetAllAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void Get_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>(); 
            mockLogger.Setup(x => x.Trace("VehicleBrand_GetAllAsync")).Throws(new Exception());
            VehicleBrandController vehicleBrandController = new VehicleBrandController(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleBrandController.GetVehicleBrand());

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleBrand_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetById_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleBrandController vehicleBrandController = new VehicleBrandController(mockLogger.Object);
            List<VehicleBrandModel> listVehicleBrandModel = new List<VehicleBrandModel>();
            VehicleBrandModel vehicleBrandModel = new VehicleBrandModel();
            var getAll = await vehicleBrandController.GetVehicleBrand();
            var okResult = getAll as OkObjectResult;
            if(okResult != null && okResult.Value != null)
                listVehicleBrandModel = (List<VehicleBrandModel>)okResult.Value;
            if(listVehicleBrandModel.Count > 0)
                vehicleBrandModel = listVehicleBrandModel.First();
            
            // Act
            var result = await vehicleBrandController.GetVehicleBrand(vehicleBrandModel.VehicleBrandId);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("VehicleBrand_GetByIdAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void GetById_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleBrand_GetByIdAsync")).Throws(new Exception());
            VehicleBrandController vehicleBrandController = new VehicleBrandController(mockLogger.Object);
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);
            var getAll = vehicleBrandRepository.GetAll();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleBrandController.GetVehicleBrand(getAll.First().VehicleBrandId));

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
        public void Post_Erro()
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
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);
            var getAll = vehicleBrandRepository.GetAll();
            Fixture fixture = new Fixture();
            VehicleBrandModel vehicleBrandModel = fixture.Build<VehicleBrandModel>()
                .With(vehicleBrandModel => vehicleBrandModel.VehicleBrandId, getAll.First().VehicleBrandId)
                .With(vehicleBrandModel => vehicleBrandModel.VehicleBrandName, Faker.Name.First())
                .Create<VehicleBrandModel>();

            // Act
            await vehicleBrandController.Update(vehicleBrandModel);
            var result = await vehicleBrandController.GetVehicleBrand(getAll.First().VehicleBrandId);
            ObjectResult objectResult = (ObjectResult)result;
            var vehicleBrandModelResult = (VehicleBrandModel)objectResult.Value;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual(vehicleBrandModel.VehicleBrandId, vehicleBrandModelResult.VehicleBrandId);
            Assert.AreEqual(vehicleBrandModel.VehicleBrandName, vehicleBrandModelResult.VehicleBrandName);
            Assert.AreNotEqual(getAll.First().VehicleBrandName, vehicleBrandModelResult.VehicleBrandName);
            mockLogger.Verify(x => x.Trace("VehicleBrand_UpdateAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void Update_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleBrand_UpdateAsync")).Throws(new Exception());
            VehicleBrandController vehicleBrandController = new VehicleBrandController(mockLogger.Object);
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);
            var getAll = vehicleBrandRepository.GetAll();
            Fixture fixture = new Fixture();
            VehicleBrandModel vehicleBrandModel = fixture.Build<VehicleBrandModel>()
                .With(vehicleBrandModel => vehicleBrandModel.VehicleBrandId, getAll.First().VehicleBrandId)
                .With(vehicleBrandModel => vehicleBrandModel.VehicleBrandName, Faker.Name.First())
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
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);
            var getAll = vehicleBrandRepository.GetAll();

            // Act
            await vehicleBrandController.Delete(getAll.First().VehicleBrandId);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleBrand_DeleteAsync"), Times.Exactly(2));
        }

        [TestMethod]
        public void Delete_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleBrand_DeleteAsync")).Throws(new Exception());
            VehicleBrandController vehicleBrandController = new VehicleBrandController(mockLogger.Object);
            VehicleBrandRepository vehicleBrandRepository = new VehicleBrandRepository(mockLogger.Object);
            var getAll = vehicleBrandRepository.GetAll();

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => vehicleBrandController.Delete(getAll.First().VehicleBrandId));

            // Assert
            mockLogger.Verify(x => x.TraceException("VehicleBrand_DeleteAsync"), Times.Exactly(1));
        }
    }
}
