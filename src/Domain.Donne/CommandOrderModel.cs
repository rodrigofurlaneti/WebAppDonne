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

        public CommandOrderModel(int commandId, int buyerId, string buyerName, int productId, string productName, int amount, string salePrice, string totalSalePrice)
        {
            CommandId = commandId;
            BuyerId = buyerId;
            BuyerName = buyerName;
            ProductId = productId;
            ProductName = productName;
            Amount = amount;
            SalePrice = salePrice;
            TotalSalePrice = totalSalePrice;
        }
    }
}
