namespace WebAppDonne.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int CommandsId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public DateTime? DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
