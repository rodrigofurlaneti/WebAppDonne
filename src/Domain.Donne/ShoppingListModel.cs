namespace Domain.Donne
{
    public class ShoppingListModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CostPrice { get; set; }
        public int QuantityToBuy { get; set; }
        public string TotalValueOfLastPurchase { get; set; }
    }
}