namespace Domain.Donne
{
    public class Vehicle : BaseLog
    {
        public int VehicleId { get; set; }
        public int VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public string Plate { get; set; }
        public string EntryDate { get; set; }
        public string EntryTime { get; set; }
        public string DepartureDate { get; set; }
        public string DepartureTime { get; set; }
        public bool Parked { get; set; }
    }
}
