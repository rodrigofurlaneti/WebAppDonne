using System;
using System.Collections.Generic;

namespace Domain.Donne
{
    public class ProductModel : BaseLog
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
        public bool NeedToPrint { get; set; }
        public bool Status { get; set; }

        public ProductModel()
        {
        }

        public ProductModel(int productId, string productName, int categoryId, string categoryName, 
            string costPrice, string salePrice, int quantityStock, int minimumStockQuantity, 
            string totalValueCostOfInventory, string totalValueSaleStock, bool status, List<DateTime> listDateTime,
            bool needToPrint, int userId, string userName)
            : base(listDateTime, userId, userName)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.CategoryId = categoryId;
            this.CategoryName = categoryName;
            this.CostPrice = costPrice;
            this.SalePrice = salePrice;
            this.QuantityStock = quantityStock;
            this.MinimumStockQuantity = minimumStockQuantity;
            this.TotalValueCostOfInventory = totalValueCostOfInventory;
            this.TotalValueSaleStock = totalValueSaleStock;
            this.DateInsert = listDateTime[0];
            this.DateUpdate = listDateTime[1];
            this.NeedToPrint = needToPrint;
            this.UserId = userId;
            this.UserName = userName;
            this.Status = status;
        }
    }
}
