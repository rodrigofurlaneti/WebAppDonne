using Business.Donne;
using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Donne.Business.AuthenticationBusinessTest
{
    [TestClass]
    [TestCategory("Donne > Business > AuthenticationBusiness")]
    public class AuthenticationBusinessTest
    {
        [TestMethod]
        public void SimpleAuthenticationSuccess_Sucesso()
        {
            // Arrange
            AuthenticationModel authenticationModel = new AuthenticationModel();
            authenticationModel.HostedServerName = "HostedServerName";
            authenticationModel.AuthenticationDateTime = DateTime.Now.ToString();

            // Act
            AuthenticationBusiness.SimpleAuthenticationSuccess(authenticationModel);

            // Assert
            Assert.AreEqual(authenticationModel.Authenticated, "1");
            Assert.AreEqual(authenticationModel.Status, "Success");
        }

        [TestMethod]
        public void SimpleAuthenticationInvalidPassword_Sucesso()
        {
            // Arrange
            AuthenticationModel authenticationModel = new AuthenticationModel();
            authenticationModel.HostedServerName = "HostedServerName";
            authenticationModel.AuthenticationDateTime = DateTime.Now.ToString();

            // Act
            AuthenticationBusiness.SimpleAuthenticationInvalidPassword(authenticationModel);

            // Assert
            Assert.AreEqual(authenticationModel.Authenticated, "0");
            Assert.AreEqual(authenticationModel.Status, "Invalid password");
        }

        [TestMethod]
        public void SimpleAuthenticationInvalidUserName_Sucesso()
        {
            // Arrange
            AuthenticationModel authenticationModel = new AuthenticationModel();
            authenticationModel.HostedServerName = "HostedServerName";
            authenticationModel.AuthenticationDateTime = DateTime.Now.ToString();

            // Act
            AuthenticationBusiness.SimpleAuthenticationInvalidUserName(authenticationModel);

            // Assert
            Assert.AreEqual(authenticationModel.Authenticated, "0");
            Assert.AreEqual(authenticationModel.Status, "Invalid user name");
        }

    }
}
