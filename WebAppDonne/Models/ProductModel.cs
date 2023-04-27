namespace WebAppDonne.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CostPrice { get; set; }
        public string SalePrice { get; set; }
        public int QuantityStock { get; set; }
        public int MinimumStockQuantity { get; set; }
        public string TotalValueCostOfInventory { get; set; }
        public string TotalValueSaleStock { get; set; }
        public string ImagePath { get; set; }
        public DateTime? DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
        public bool NeedToPrint { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool Status { get; set; }
    }
}
