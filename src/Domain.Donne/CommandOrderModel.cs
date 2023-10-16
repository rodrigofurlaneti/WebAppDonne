using System.Collections.Generic;

namespace Domain.Donne
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
        public string TotalSalePrice { get; set; }

        public CommandOrderModel()
        {
        }

        public CommandOrderModel(int commandId, int buyerId, List<string> listStrings, int productId, int amount)
        {
            CommandId = commandId;
            BuyerId = buyerId;
            BuyerName = listStrings[0];
            ProductId = productId;
            ProductName = listStrings[1];
            Amount = amount;
            SalePrice = listStrings[2];
            TotalSalePrice = listStrings[3];
        }
    }
}
