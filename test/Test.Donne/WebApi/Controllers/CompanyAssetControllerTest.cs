using Domain.Donne;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using WebApi.Donne.Controllers;
using WebApi.Donne.Infrastructure.SeedWork;

namespace Test.Donne.WebApi.Controllers.CompanyAssetControllerTest
{
    [TestClass]
    [TestCategory("Donne > WebApi > Controllers > CompanyAssetController")]
    public class CompanyAssetControllerTest
    {
        [TestMethod]
        public async Task GetCompanyAssetAsync_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CompanyAssetController companyAssetController = new CompanyAssetController(mockLogger.Object);

            // Act
            var result = await companyAssetController.GetCompanyAsset();
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("GetCompanyAssetAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CompanyAsset_GetAllAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetCompanyAssetAsync_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetCompanyAssetAsync")).Throws(new ArgumentException());
            CompanyAssetController companyAssetController = new CompanyAssetController(mockLogger.Object);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => companyAssetController.GetCompanyAsset());

            // Assert
            mockLogger.Verify(x => x.Trace("GetCompanyAssetAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("GetCompanyAssetAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task GetByIdAsync_Sucesso()
        {
            // Arrange
            await Insert_Sucesso();
            int id = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CompanyAssetController companyAssetController = new CompanyAssetController(mockLogger.Object);
            var getAll = companyAssetController.GetCompanyAsset();
            var objResult = (OkObjectResult)getAll.Result;
            var listCompanyAsset = objResult.Value as List<CompanyAssetModel>;
            if (listCompanyAsset != null)
                id = listCompanyAsset[0].CompanyAssetId;

            // Act
            var result = await companyAssetController.Get(id);
            ObjectResult objectResult = (ObjectResult)result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(objectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.AreEqual((int)StatusCodes.Status200OK, objectResult.StatusCode);
            mockLogger.Verify(x => x.Trace("GetCompanyAssetAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CompanyAsset_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetByIdAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CompanyAsset_GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByIdAsync_Erro()
        {
            // Arrange
            int companyAssetId = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("GetByIdAsync")).Throws(new Exception());
            CompanyAssetController companyAssetController = new CompanyAssetController(mockLogger.Object);
            var getAll = companyAssetController.GetCompanyAsset();
            var objResult = (OkObjectResult)getAll.Result;
            var listCompanyAsset = objResult.Value as List<CompanyAssetModel>;
            if (listCompanyAsset != null)
                companyAssetId = listCompanyAsset[0].CompanyAssetId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => companyAssetController.Get(companyAssetId));

            // Assert
            mockLogger.Verify(x => x.Trace("GetByIdAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.TraceException("GetByIdAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Insert_Sucesso()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CompanyAssetController companyAssetController = new CompanyAssetController(mockLogger.Object);
            int companyAssetId = Faker.RandomNumber.Next(0, 100);
            string companyAssetName = Faker.Name.FullName();
            string costPrice = Faker.Finance.Coupon().ToString();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            CompanyAssetModel companyAssetModel = new CompanyAssetModel(companyAssetId,
                companyAssetName, costPrice, dateInsert, dateUpdate, userId, userName);

            // Act
            await companyAssetController.Post(companyAssetModel);

            // Assert
            mockLogger.Verify(x => x.Trace("InsertAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CompanyAsset_InsertAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Insert_Erro()
        {
            // Arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("InsertCompanyAssetAsync")).Throws(new Exception());
            CompanyAssetController companyAssetController = new CompanyAssetController(mockLogger.Object);
            int companyAssetId = Faker.RandomNumber.Next(0, 100);
            string companyAssetName = Faker.Name.FullName();
            string costPrice = Faker.Finance.Coupon().ToString();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            CompanyAssetModel companyAssetModel = new CompanyAssetModel(companyAssetId,
                companyAssetName, costPrice, dateInsert, dateUpdate, userId, userName);

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => companyAssetController.Post(companyAssetModel));

            // Assert
            mockLogger.Verify(x => x.Trace("CompanyAsset_InsertAsync"), Times.Exactly(0));
            mockLogger.Verify(x => x.Trace("InsertCompanyAssetAsync"), Times.Exactly(0));
        }

        [TestMethod]
        public async Task Update_Sucesso()
        {
            // Arrange
            int companyAssetId = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CompanyAssetController companyAssetController = new CompanyAssetController(mockLogger.Object);
            var getAll = companyAssetController.GetCompanyAsset();
            var objResult = (OkObjectResult)getAll.Result;
            string costPrice = Faker.Finance.Coupon().ToString();
            var listCompanyAsset = objResult.Value as List<CompanyAssetModel>;
            if (listCompanyAsset != null)
                companyAssetId = listCompanyAsset[0].CompanyAssetId;
            string companyAssetName = Faker.Name.FullName();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            CompanyAssetModel companyAssetModel = new CompanyAssetModel(companyAssetId,
                companyAssetName, costPrice, dateInsert, dateUpdate, userId, userName);

            // Act
            await companyAssetController.Update(companyAssetModel);

            // Assert
            mockLogger.Verify(x => x.Trace("UpdateAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("GetCompanyAssetAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("UpdateAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CompanyAsset_UpdateAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Update_Erro()
        {
            // Arrange
            int companyAssetId = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("UpdateCompanyAssetAsync")).Throws(new Exception());
            CompanyAssetController companyAssetController = new CompanyAssetController(mockLogger.Object);
            var getAll = companyAssetController.GetCompanyAsset();
            string costPrice = Faker.Finance.Coupon().ToString();
            var objResult = (OkObjectResult)getAll.Result;
            var listCompanyAsset = objResult.Value as List<CompanyAssetModel>;
            if (listCompanyAsset != null)
                companyAssetId = listCompanyAsset[0].CompanyAssetId;
            string companyAssetName = Faker.Name.FullName();
            DateTime dateInsert = Faker.Finance.Maturity();
            DateTime dateUpdate = Faker.Finance.Maturity();
            int userId = Faker.RandomNumber.Next(0, 1000);
            string userName = Faker.Name.Last();
            CompanyAssetModel companyAssetModel = new CompanyAssetModel(companyAssetId,
                companyAssetName, costPrice, dateInsert, dateUpdate, userId, userName);

            // Act
            // Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => companyAssetController.Update(companyAssetModel));
        }

        [TestMethod]
        public async Task Delete_Sucesso()
        {
            // Arrange
            await Insert_Sucesso();
            int companyAssetId = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            CompanyAssetController companyAssetController = new CompanyAssetController(mockLogger.Object);
            var getAll = companyAssetController.GetCompanyAsset();
            var objResult = (OkObjectResult)getAll.Result;
            var listCompanyAsset = objResult.Value as List<CompanyAssetModel>;
            if (listCompanyAsset != null)
                companyAssetId = listCompanyAsset[0].CompanyAssetId;

            // Act
            await companyAssetController.Delete(companyAssetId);

            // Assert
            mockLogger.Verify(x => x.Trace("GetCompanyAssetAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CompanyAsset_GetAllAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("DeleteAsync"), Times.Exactly(1));
            mockLogger.Verify(x => x.Trace("CompanyAsset_DeleteAsync"), Times.Exactly(1));
        }

        [TestMethod]
        public void Delete_Erro()
        {
            // Arrange
            int companyAssetId = 0;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Trace("DeleteAsync")).Throws(new Exception());
            CompanyAssetController companyAssetController = new CompanyAssetController(mockLogger.Object);
            var getAll = companyAssetController.GetCompanyAsset();
            var objResult = (OkObjectResult)getAll.Result;
            var listCompanyAsset = objResult.Value as List<CompanyAssetModel>;
            if (listCompanyAsset != null)
                companyAssetId = listCompanyAsset[0].CompanyAssetId;

            // Act
            Assert.ThrowsExceptionAsync<ArgumentException>(() => companyAssetController.Delete(companyAssetId));

            // Assert
            mockLogger.Verify(x => x.TraceException("DeleteAsync"), Times.Exactly(1));
        }
    }
}
