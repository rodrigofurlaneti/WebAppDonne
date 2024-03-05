using Domain.Donne;

namespace WebApi.Donne.Infrastructure.ShoppingList
{
    public interface IShoppingListRepository
    {
        IEnumerable<ShoppingListModel> GetAll();
        Task<IEnumerable<ShoppingListModel>> GetAllAsync();
    }
}
