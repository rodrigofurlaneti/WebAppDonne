using Domain.Donne;

namespace WebApi.Donne.Infrastructure.Product
{
    public interface IProductRepository
    {
        IEnumerable<ProductModel> GetAll();
        Task<IEnumerable<ProductModel>> GetAllAsync();
        ProductModel GetById(int id);
        Task<ProductModel> GetByIdAsync(int id);
        void Insert(ProductModel productModel);
        Task InsertAsync(ProductModel productModel);
        void Delete(int productId);
        Task DeleteAsync(int productId);
        void Update(ProductModel productModel);
        Task UpdateAsync(ProductModel productModel);
    }
}
