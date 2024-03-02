using AutoFixture;
using Domain.Donne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Donne.Domain.VehicleTest
{
    [TestClass]
    [TestCategory("Donne > Domain > Vehicle")]
    public class VehicleTest
    {
        [TestMethod]
        public void Vehicle_Type_Property_Sucesso()
        {
            //Arrange
            Fixture fixture = new Fixture();

            //Act
            Vehicle vehicle = fixture.Create<Vehicle>();

            //Assert
            Assert.IsNotNull(vehicle);
            Assert.AreEqual(vehicle.UserName.GetType(), typeof(string));
            Assert.AreEqual(vehicle.VehicleTypeName.GetType(), typeof(string));
            Assert.AreEqual(vehicle.VehicleBrandName.GetType(), typeof(string));
            Assert.AreEqual(vehicle.VehicleModelName.GetType(), typeof(string));
            Assert.AreEqual(vehicle.VehicleColorName.GetType(), typeof(string));
            Assert.AreEqual(vehicle.Plate.GetType(), typeof(string));
            Assert.AreEqual(vehicle.EntryDate.GetType(), typeof(string));
            Assert.AreEqual(vehicle.EntryTime.GetType(), typeof(string));
            Assert.AreEqual(vehicle.DepartureDate.GetType(), typeof(string));
            Assert.AreEqual(vehicle.DepartureTime.GetType(), typeof(string));
            Assert.AreEqual(vehicle.VehicleId.GetType(), typeof(int));
            Assert.AreEqual(vehicle.VehicleTypeId.GetType(), typeof(int));
            Assert.AreEqual(vehicle.VehicleBrandId.GetType(), typeof(int));
            Assert.AreEqual(vehicle.VehicleModelId.GetType(), typeof(int));
            Assert.AreEqual(vehicle.VehicleColorId.GetType(), typeof(int));
            Assert.AreEqual(vehicle.Parked.GetType(), typeof(int));
        }

        [TestMethod]
        public void Vehicle_Constructor_Sucesso()
        {
            //Arrange
            Fixture fixture = new Fixture();
            Vehicle vehicle = fixture.Create<Vehicle>();
            List<DateTime> listDateTime = new List<DateTime>() {
                vehicle.DateInsert,
                vehicle.DateUpdate
                };

            //Act
            var result = new Vehicle(vehicle.VehicleId, vehicle.VehicleTypeId, vehicle.VehicleTypeName,
                vehicle.VehicleBrandId, vehicle.VehicleBrandName, vehicle.VehicleModelId, vehicle.VehicleModelName,
                vehicle.VehicleColorId, vehicle.VehicleColorName, vehicle.Plate, vehicle.EntryDate, vehicle.EntryTime,
                vehicle.DepartureDate, vehicle.DepartureTime, vehicle.Parked, listDateTime, vehicle.UserId,
                vehicle.UserName);

            //Assert
            Assert.IsNotNull(vehicle);
            Assert.AreEqual(vehicle.UserName, result.UserName);
            Assert.AreEqual(vehicle.VehicleTypeName, result.VehicleTypeName);
            Assert.AreEqual(vehicle.VehicleBrandName, result.VehicleBrandName);
        }
    }
}
