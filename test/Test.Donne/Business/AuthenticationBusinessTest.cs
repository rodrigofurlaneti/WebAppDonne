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
            string authenticatedExpectedValue = "1";
            string statusExpectedValue = "Success";
            AuthenticationModel authenticationModel = new AuthenticationModel();
            authenticationModel.HostedServerName = "HostedServerName";
            authenticationModel.AuthenticationDateTime = DateTime.Now.ToString();

            // Act
            AuthenticationBusiness.SimpleAuthenticationSuccess(authenticationModel);

            // Assert
            Assert.AreEqual(authenticatedExpectedValue, authenticationModel.Authenticated);
            Assert.AreEqual(statusExpectedValue, authenticationModel.Status);
        }

        [TestMethod]
        public void SimpleAuthenticationInvalidPassword_Sucesso()
        {
            // Arrange
            string authenticatedExpectedValue = "0";
            string statusExpectedValue = "Invalid password";
            AuthenticationModel authenticationModel = new AuthenticationModel();
            authenticationModel.HostedServerName = "HostedServerName";
            authenticationModel.AuthenticationDateTime = DateTime.Now.ToString();

            // Act
            AuthenticationBusiness.SimpleAuthenticationInvalidPassword(authenticationModel);

            // Assert
            Assert.AreEqual(authenticatedExpectedValue, authenticationModel.Authenticated);
            Assert.AreEqual(statusExpectedValue, authenticationModel.Status);
        }

        [TestMethod]
        public void SimpleAuthenticationInvalidUserName_Sucesso()
        {
            // Arrange
            string authenticatedExpectedValue = "0";
            string statusExpectedValue = "Invalid user name";
            AuthenticationModel authenticationModel = new AuthenticationModel();
            authenticationModel.HostedServerName = "HostedServerName";
            authenticationModel.AuthenticationDateTime = DateTime.Now.ToString();

            // Act
            AuthenticationBusiness.SimpleAuthenticationInvalidUserName(authenticationModel);

            // Assert
            Assert.AreEqual(authenticatedExpectedValue, authenticationModel.Authenticated);
            Assert.AreEqual(statusExpectedValue, authenticationModel.Status);
        }

    }
}
