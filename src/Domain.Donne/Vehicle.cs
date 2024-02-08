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
    }
}
