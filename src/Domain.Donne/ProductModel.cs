using System;

namespace Domain.Donne
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
        public DateTime? DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
        public bool NeedToPrint { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool Status { get; set; }

        public ProductModel()
        {
        }

        public ProductModel(int productId, string productName, int categoryId, string categoryName, string costPrice, string salePrice, int quantityStock, int minimumStockQuantity, string totalValueCostOfInventory, string totalValueSaleStock, DateTime? dateInsert, DateTime? dateUpdate, bool needToPrint, int userId, string userName, bool status)
        {
            ProductId = productId;
            ProductName = productName;
            CategoryId = categoryId;
            CategoryName = categoryName;
            CostPrice = costPrice;
            SalePrice = salePrice;
            QuantityStock = quantityStock;
            MinimumStockQuantity = minimumStockQuantity;
            TotalValueCostOfInventory = totalValueCostOfInventory;
            TotalValueSaleStock = totalValueSaleStock;
            DateInsert = dateInsert;
            DateUpdate = dateUpdate;
            NeedToPrint = needToPrint;
            UserId = userId;
            UserName = userName;
            Status = status;
        }
    }
}
