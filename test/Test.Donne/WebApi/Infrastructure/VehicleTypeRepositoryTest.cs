﻿using AutoFixture;
using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Donne.Infrastructure;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Infrastructure.VehicleTypeRepositoryTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Infrastructure > VehicleTypeRepository")]
    public class VehicleTypeRepositoryTest
    {
        [TestMethod]
        public void GetAll_Sucesso()
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
        public void GetAll_Erro()
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
        public async Task GetAllAsync_Sucesso()
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
        public void GetAllAsync_Erro()
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

        [TestMethod]
        public void GetById_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);
            var resultGetAll = vehicleTypeRepository.GetAllVehicleTypes();

            // Act
            var result = vehicleTypeRepository.GetById(resultGetAll.First().VehicleTypeId);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("VehicleType_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetById_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleType_GetById")).Throws(new ArgumentNullException());
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);
            var resultGetAll = vehicleTypeRepository.GetAllVehicleTypes();

            // Act
            var resultAction = () => vehicleTypeRepository.GetById(resultGetAll.First().VehicleTypeId);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.Trace("VehicleType_GetAll"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("VehicleType_GetById"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);
            var resultGetAll = await vehicleTypeRepository.GetAllVehicleTypesAsync();

            // Act
            var result = await vehicleTypeRepository.GetByIdAsync(resultGetAll.First().VehicleTypeId);

            // Assert
            Assert.IsNotNull(result);
            mockLogger.Verify(x => x.Trace("VehicleType_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleType_GetByIdAsync")).Throws(new ArgumentNullException());
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);
            var resultGetAll = await vehicleTypeRepository.GetAllVehicleTypesAsync();

            // Act
            var resultAction = () => vehicleTypeRepository.GetByIdAsync(resultGetAll.First().VehicleTypeId);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.Trace("VehicleType_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("VehicleType_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Insert_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleTypeModel vehicleTypeModel = fixture.Build<VehicleTypeModel>()
                .With(vehicleTypeModel => vehicleTypeModel.VehicleTypeId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicleTypeModel => vehicleTypeModel.VehicleTypeName, Faker.Name.First())
                .Create<VehicleTypeModel>();

            // Act
            vehicleTypeRepository.Insert(vehicleTypeModel);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleType_Insert"), Times.Exactly(1));
        }

        [TestMethod]
        public void Insert_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleType_Insert")).Throws(new ArgumentNullException());
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleTypeModel vehicleTypeModel = fixture.Build<VehicleTypeModel>()
                .With(vehicleTypeModel => vehicleTypeModel.VehicleTypeId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicleTypeModel => vehicleTypeModel.VehicleTypeName, Faker.Name.First())
                .Create<VehicleTypeModel>();

            // Act
            var resultAction = () => vehicleTypeRepository.Insert(vehicleTypeModel);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleType_Insert"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task InsertAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleTypeModel vehicleTypeModel = fixture.Build<VehicleTypeModel>()
                .With(vehicleTypeModel => vehicleTypeModel.VehicleTypeId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicleTypeModel => vehicleTypeModel.VehicleTypeName, Faker.Name.First())
                .Create<VehicleTypeModel>();

            // Act
            await vehicleTypeRepository.InsertAsync(vehicleTypeModel);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleType_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void InsertAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleType_InsertAsync")).Throws(new ArgumentNullException());
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);
            Fixture fixture = new Fixture();
            VehicleTypeModel vehicleTypeModel = fixture.Build<VehicleTypeModel>()
                .With(vehicleTypeModel => vehicleTypeModel.VehicleTypeId, Faker.RandomNumber.Next(1, 1000))
                .With(vehicleTypeModel => vehicleTypeModel.VehicleTypeName, Faker.Name.First())
                .Create<VehicleTypeModel>();

            // Act
            var resultAction = () => vehicleTypeRepository.InsertAsync(vehicleTypeModel);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleType_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);
            var resultGetAll = vehicleTypeRepository.GetAllVehicleTypes();

            // Act
            vehicleTypeRepository.Delete(resultGetAll.First().VehicleTypeId);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleType_Delete"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleType_Delete")).Throws(new ArgumentNullException());
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);
            var resultGetAll = vehicleTypeRepository.GetAllVehicleTypes();

            // Act
            var resultAction = () => vehicleTypeRepository.Delete(resultGetAll.First().VehicleTypeId);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleType_Delete"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task DeleteAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);
            var resultGetAll = await vehicleTypeRepository.GetAllVehicleTypesAsync();

            // Act
            await vehicleTypeRepository.DeleteAsync(resultGetAll.First().VehicleTypeId);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleType_DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task DeleteAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleType_DeleteAsync")).Throws(new ArgumentNullException());
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);
            var resultGetAll = await vehicleTypeRepository.GetAllVehicleTypesAsync();

            // Act
            var resultAction = () => vehicleTypeRepository.DeleteAsync(resultGetAll.First().VehicleTypeId);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleType_DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);
            var resultGetAll = vehicleTypeRepository.GetAllVehicleTypes();
            Fixture fixture = new Fixture();
            VehicleTypeModel vehicleTypeModel = fixture.Build<VehicleTypeModel>()
                .With(vehicleTypeModel => vehicleTypeModel.VehicleTypeId, resultGetAll.First().VehicleTypeId)
                .With(vehicleTypeModel => vehicleTypeModel.VehicleTypeName, Faker.Name.First())
                .Create<VehicleTypeModel>();

            // Act
            vehicleTypeRepository.Update(vehicleTypeModel);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleType_Update"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleType_Update")).Throws(new ArgumentNullException());
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);
            var resultGetAll = vehicleTypeRepository.GetAllVehicleTypes();
            Fixture fixture = new Fixture();
            VehicleTypeModel vehicleTypeModel = fixture.Build<VehicleTypeModel>()
                .With(vehicleTypeModel => vehicleTypeModel.VehicleTypeId, resultGetAll.First().VehicleTypeId)
                .With(vehicleTypeModel => vehicleTypeModel.VehicleTypeName, Faker.Name.First())
                .Create<VehicleTypeModel>();

            // Act
            var resultAction = () => vehicleTypeRepository.Update(vehicleTypeModel);
            Assert.ThrowsException<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleType_Update"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);
            var resultGetAll = await vehicleTypeRepository.GetAllVehicleTypesAsync();
            Fixture fixture = new Fixture();
            VehicleTypeModel vehicleTypeModel = fixture.Build<VehicleTypeModel>()
                .With(vehicleTypeModel => vehicleTypeModel.VehicleTypeId, resultGetAll.First().VehicleTypeId)
                .With(vehicleTypeModel => vehicleTypeModel.VehicleTypeName, Faker.Name.First())
                .Create<VehicleTypeModel>();

            // Act
            await vehicleTypeRepository.UpdateAsync(vehicleTypeModel);

            // Assert
            mockLogger.Verify(x => x.Trace("VehicleType_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task UpdateAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("VehicleType_UpdateAsync")).Throws(new ArgumentNullException());
            VehicleTypeRepository vehicleTypeRepository = new VehicleTypeRepository(mockLogger.Object);
            var resultGetAll = await vehicleTypeRepository.GetAllVehicleTypesAsync();
            Fixture fixture = new Fixture();
            VehicleTypeModel vehicleTypeModel = fixture.Build<VehicleTypeModel>()
                .With(vehicleTypeModel => vehicleTypeModel.VehicleTypeId, resultGetAll.First().VehicleTypeId)
                .With(vehicleTypeModel => vehicleTypeModel.VehicleTypeName, Faker.Name.First())
                .Create<VehicleTypeModel>();

            // Act
            var resultAction = () => vehicleTypeRepository.UpdateAsync(vehicleTypeModel);
            Assert.ThrowsExceptionAsync<ArgumentNullException>(resultAction);

            // Assert
            Assert.IsNotNull(resultAction);
            mockLogger.Verify(x => x.TraceException("VehicleType_UpdateAsync"), Times.Exactly(1));
        }

    }
}
