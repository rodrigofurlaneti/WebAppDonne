using AutoFixture;
using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Donne.Domain.VehicleBrandModelTest
{
    [TestClass]
    [TestCategory("Donne > Domain > VehicleBrandModel")]
    public class VehicleBrandModelTest
    {
        [TestMethod]
        public void Vehicle_Brand_Type_Property_Sucesso()
        {
            //Arrange
            Fixture fixture = new Fixture();

            //Act
            VehicleBrandModel vehicleBrand = fixture.Create<VehicleBrandModel>();

            //Assert
            Assert.IsNotNull(vehicleBrand);
            Assert.AreEqual(vehicleBrand.VehicleBrandId.GetType(), typeof(int));
            Assert.AreEqual(vehicleBrand.VehicleBrandName.GetType(), typeof(string));
        }
    }
}
