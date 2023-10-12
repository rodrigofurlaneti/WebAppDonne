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

        public OrderModel()
        {
        }

        public OrderModel(int orderId, int commandId, int productId, string productName, string salePrice, int amount, string totalSalePrice, DateTime? dateInsert, DateTime? dateUpdate, int userId, string userName)
        {
            OrderId = orderId;
            CommandId = commandId;
            ProductId = productId;
            ProductName = productName;
            SalePrice = salePrice;
            Amount = amount;
            TotalSalePrice = totalSalePrice;
            DateInsert = dateInsert;
            DateUpdate = dateUpdate;
            UserId = userId;
            UserName = userName;
        }
    }
}
