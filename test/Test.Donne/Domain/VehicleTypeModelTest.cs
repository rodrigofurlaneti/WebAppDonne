using AutoFixture;
using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Donne.Domain.VehicleTypeModelTest
{
    [TestClass]
    [TestCategory("Donne > Domain > VehicleTypeModel")]
    public class VehicleTypeModelTest
    {
        [TestMethod]
        public void Vehicle_Type_Type_Property_Sucesso()
        {
            //Arrange
            Fixture fixture = new Fixture();

            //Act
            VehicleTypeModel vehicleType = fixture.Create<VehicleTypeModel>();

            //Assert
            Assert.IsNotNull(vehicleType);
            Assert.AreEqual(vehicleType.VehicleTypeId.GetType(), typeof(int));
            Assert.AreEqual(vehicleType.VehicleTypeName.GetType(), typeof(string));
        }
    }
}
