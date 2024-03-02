using Domain.Donne;

namespace Business.Donne
{
    public static class ProductBusiness
    {
        public static void ProductModelValid(ProductModel productModel)
        {
            if (productModel.MinimumStockQuantity >= productModel.QuantityStock)
            {
                productModel.QuantityToBuy = productModel.MinimumStockQuantity - productModel.QuantityStock;
                Decimal valueCostPrice = Convert.ToDecimal(productModel.CostPrice);
                Decimal valueOfLastPurchase = productModel.QuantityToBuy * valueCostPrice;
                productModel.TotalValueOfLastPurchase = valueOfLastPurchase.ToString();
            }
        }
    }
}
