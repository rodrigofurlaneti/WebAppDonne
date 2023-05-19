namespace WebAppDonne.Models
{
    public class CommandOrderModel
    {
        public int CommandId { get; set; }
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public string SalePrice { get; set; }
    }
}
