using Domain.Donne;

namespace Business.Donne
{
    public static class ShoppingListBusiness
    {
        public static  List<ShoppingListModel> ShoppingListBusinessValid(List<ShoppingListModel> listShoppingListModel) 
        {
            List<ShoppingListModel> listShoppingListModelRet = new List<ShoppingListModel>();

            if (listShoppingListModel.Count > 0)
            {
                foreach (var shoppingListModel in listShoppingListModel)
                {
                    if (shoppingListModel.QuantityToBuy > 0)
                    {
                        listShoppingListModelRet.Add(shoppingListModel);
                    }
                }
            }

            return listShoppingListModelRet;
        }
    }
}