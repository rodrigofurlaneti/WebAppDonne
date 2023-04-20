namespace WebAppDonne.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
