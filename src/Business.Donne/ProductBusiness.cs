using Domain.Donne;

namespace Business.Donne
{
    public static class ProductBusiness
    {
        public static ProductModel ProductModelValid(ProductModel productModel)
        {
            if (productModel.MinimumStockQuantity >= productModel.QuantityStock)
            {
                productModel.QuantityToBuy = productModel.QuantityStock - productModel.MinimumStockQuantity;
                Decimal valueCostPrice = Convert.ToDecimal(productModel.CostPrice);
                Decimal valueOfLastPurchase = productModel.QuantityToBuy * valueCostPrice;
                productModel.TotalValueOfLastPurchase = valueOfLastPurchase.ToString();
            }

            return productModel;
        }
    }
}
