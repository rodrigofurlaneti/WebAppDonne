using AutoFixture;
using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Donne.Domain.VehicleColorModelTest
{
    [TestClass]
    [TestCategory("Donne > Domain > VehicleColorModel")]
    public class VehicleColorModelTest
    {
        [TestMethod]
        public void Vehicle_Color_Type_Property_Sucesso()
        {
            //Arrange
            Fixture fixture = new Fixture();

            //Act
            VehicleColorModel vehicleColor = fixture.Create<VehicleColorModel>();

            //Assert
            Assert.IsNotNull(vehicleColor);
            Assert.AreEqual(vehicleColor.VehicleColorId.GetType(), typeof(int));
            Assert.AreEqual(vehicleColor.VehicleColorName.GetType(), typeof(string));
        }
    }
}
