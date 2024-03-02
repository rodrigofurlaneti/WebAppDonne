using AutoFixture;
using Business.Donne;
using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Donne.Business.UserBusinessTest
{
    [TestClass]
    [TestCategory("Donne > Business > UserBusiness")]
    public class UserBusinessTest
    {
        [TestMethod]
        public void SimpleAuthentication_Sucesso()
        {
            //Arrange
            string userPassword = Faker.Name.First();
            Fixture fixture = new Fixture();
            AuthenticationUserModel authenticationUserModel = fixture.Build<AuthenticationUserModel>()
                .With(authenticationUserModel => authenticationUserModel.UserPassword, userPassword)
                .Create<AuthenticationUserModel>();
            UserModel userModel = fixture.Build<UserModel>()
                .With(userModel => userModel.UserPassword, userPassword)
                .Create<UserModel>();

            //Act
            var result = UserBusiness.SimpleAuthentication(authenticationUserModel, userModel);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SimpleAuthentication_Erro()
        {
            //Arrange
            string userPassword = Faker.Name.First();
            string userPasswordBd = Faker.Name.First();
            Fixture fixture = new Fixture();
            AuthenticationUserModel authenticationUserModel = fixture.Build<AuthenticationUserModel>()
                .With(authenticationUserModel => authenticationUserModel.UserPassword, userPassword)
                .Create<AuthenticationUserModel>();
            UserModel userModel = fixture.Build<UserModel>()
                .With(userModel => userModel.UserPassword, userPasswordBd)
                .Create<UserModel>();

            //Act
            var result = UserBusiness.SimpleAuthentication(authenticationUserModel, userModel);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result);
        }
    }
}
