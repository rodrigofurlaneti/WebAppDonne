using Domain.Donne;

namespace WebApi.Donne.Infrastructure.StockInventory
{
    public interface IStockInventoryRepository
    {
        Task<IEnumerable<StockInventoryModel>> GetAllAsync();
    }
}
