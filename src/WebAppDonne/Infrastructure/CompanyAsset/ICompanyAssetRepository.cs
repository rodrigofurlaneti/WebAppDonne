using Domain.Donne;

namespace WebApi.Donne.Infrastructure.CompanyAsset
{
    public interface ICompanyAssetRepository
    {
        IEnumerable<CompanyAssetModel> GetAll();
        Task<IEnumerable<CompanyAssetModel>> GetAllAsync();
        CompanyAssetModel GetById(int id);
        Task<CompanyAssetModel> GetByIdAsync(int id);
        void Insert(CompanyAssetModel formOfPaymentModel);
        Task InsertAsync(CompanyAssetModel formOfPaymentModel);
        void Delete(int formOfPaymentId);
        Task DeleteAsync(int formOfPaymentId);
        void Update(CompanyAssetModel formOfPaymentModel);
        Task UpdateAsync(CompanyAssetModel formOfPaymentModel);
    }
}
