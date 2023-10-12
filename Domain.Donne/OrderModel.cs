using System;

namespace Domain.Donne
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int CommandId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SalePrice { get; set; }
        public int Amount { get; set; }
        public string TotalSalePrice { get; set; }
        public DateTime? DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
