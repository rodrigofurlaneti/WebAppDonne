using AutoFixture;
using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Donne.Domain.VehicleModellTest;

[TestClass]
[TestCategory("Donne > Domain > VehicleModelModel")]
public class VehicleModelTest
{
    [TestMethod]
    public void Vehicle_Model_Property_Sucesso()
    {
        //Arrange
        Fixture fixture = new Fixture();

        //Act
        VehicleModel vehicleModel = fixture.Create<VehicleModel>();

        //Assert
        Assert.IsNotNull(vehicleModel);
        Assert.AreEqual(vehicleModel.VehicleModelId.GetType(), typeof(int));
        Assert.AreEqual(vehicleModel.VehicleModelName.GetType(), typeof(string));
    }
}
