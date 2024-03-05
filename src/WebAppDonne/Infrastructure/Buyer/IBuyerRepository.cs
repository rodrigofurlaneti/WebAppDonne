using Domain.Donne;
using System.Data.SqlClient;

namespace WebApi.Donne.Infrastructure.Buyer
{
    public interface IBuyerRepository
    {
        IEnumerable<BuyerModel> GetAll();
        Task<IEnumerable<BuyerModel>> GetAllAsync();
        IEnumerable<BuyerModel> GetByStatus(int status);
        Task<IEnumerable<BuyerModel>> GetByStatusAsync(int status);
        BuyerModel GetById(int id);
        Task<BuyerModel> GetByIdAsync(int id);
        void Insert(BuyerModel buyerModel);
        Task InsertAsync(BuyerModel buyerModel);
        void Delete(int buyerId);
        Task DeleteAsync(int buyerId);
        void Update(BuyerModel buyerModel);
        Task UpdateAsync(BuyerModel buyerModel);
    }
}
