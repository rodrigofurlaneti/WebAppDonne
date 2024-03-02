using System;
using System.Collections.Generic;

namespace Domain.Donne
{
    public class Vehicle : BaseLog
    {
        public int VehicleId { get; set; }
        public int VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }
        public int VehicleBrandId { get; set; }
        public string VehicleBrandName { get; set; }
        public int VehicleModelId { get; set; }
        public string VehicleModelName { get; set; }
        public int VehicleColorId { get; set; }
        public string VehicleColorName { get; set; }
        public string Plate { get; set; }
        public string EntryDate { get; set; }
        public string EntryTime { get; set; }
        public string DepartureDate { get; set; }
        public string DepartureTime { get; set; }
        public int Parked { get; set; }

        public Vehicle()
        {
            
        }

        public Vehicle(int vehicleId, int vehicleTypeId, string vehicleTypeName, int vehicleBrandId, 
            string vehicleBrandName, int vehicleModelId, string vehicleModelName, int vehicleColorId, 
            string vehicleColorName, string plate, string entryDate, string entryTime, string departureDate, 
            string departureTime, int parked, List<DateTime> listDateTime, int userId, string userName)
            : base(listDateTime, userId, userName)
        {
            VehicleId = vehicleId;
            VehicleTypeId = vehicleTypeId;
            VehicleTypeName = vehicleTypeName;
            VehicleBrandId = vehicleBrandId;
            VehicleBrandName = vehicleBrandName;
            VehicleModelId = vehicleModelId;
            VehicleModelName = vehicleModelName;
            VehicleColorId = vehicleColorId;
            VehicleColorName = vehicleColorName;
            Plate = plate;
            EntryDate = entryDate;
            EntryTime = entryTime;
            DepartureDate = departureDate;
            DepartureTime = departureTime;
            Parked = parked;
            DateInsert = listDateTime[0];
            DateUpdate = listDateTime[1];
            UserId = userId;
            UserName = userName;
        }
    }

    
}
