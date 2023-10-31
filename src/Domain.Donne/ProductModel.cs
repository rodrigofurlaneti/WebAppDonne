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
        public int QuantityToBuy { get; set; }
        public string TotalValueOfLastPurchase { get; set; }

        public ProductModel()
        {
        }

        public ProductModel(List<int> listInts, List<string> listStrings, bool status, 
            List<DateTime> listDateTime, bool needToPrint)
            : base(listDateTime, listInts[5], listStrings[7])
        {
            this.ProductId = listInts[0];
            this.ProductName = listStrings[0];
            this.CategoryId = listInts[1];
            this.CategoryName = listStrings[1];
            this.CostPrice = listStrings[2];
            this.SalePrice = listStrings[3];
            this.QuantityStock = listInts[2];
            this.MinimumStockQuantity = listInts[3];
            this.TotalValueCostOfInventory = listStrings[4];
            this.TotalValueSaleStock = listStrings[5];
            this.DateInsert = listDateTime[0];
            this.DateUpdate = listDateTime[1];
            this.NeedToPrint = needToPrint;
            this.UserId = listInts[4];
            this.UserName = listStrings[6];
            this.Status = status;
            this.QuantityToBuy = listInts[5];
            this.TotalValueOfLastPurchase = listStrings[7];
        }
    }
}
