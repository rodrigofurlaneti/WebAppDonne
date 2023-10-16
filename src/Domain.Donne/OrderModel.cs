using System;
using System.Collections.Generic;

namespace Domain.Donne
{
    public class OrderModel : BaseLog
    {
        public int OrderId { get; set; }
        public int CommandId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SalePrice { get; set; }
        public int Amount { get; set; }
        public string TotalSalePrice { get; set; }

        public OrderModel()
        {
        }

        public OrderModel(int orderId, int commandId, int productId, string productName, string salePrice, 
            int amount, string totalSalePrice, List<DateTime> listDateTime, int userId, string userName) 
            : base(listDateTime, userId, userName)
        {
            OrderId = orderId;
            CommandId = commandId;
            ProductId = productId;
            ProductName = productName;
            SalePrice = salePrice;
            Amount = amount;
            TotalSalePrice = totalSalePrice;
            DateInsert = listDateTime[0];
            DateUpdate = listDateTime[1];
            UserId = userId;
            UserName = userName;
        }
    }
}
