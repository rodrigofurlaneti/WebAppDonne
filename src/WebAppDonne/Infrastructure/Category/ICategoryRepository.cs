using Domain.Donne;

namespace WebApi.Donne.Infrastructure.Category
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryModel> GetAll();
        Task<IEnumerable<CategoryModel>> GetAllAsync();
        CategoryModel GetById(int id);
        Task<CategoryModel> GetByIdAsync(int id);
        void Insert(CategoryModel categoryModel);
        Task InsertAsync(CategoryModel categoryModel);
        void Delete(int categoryId);
        Task DeleteAsync(int categoryId);
        void Update(CategoryModel categoryModel);
        Task UpdateAsync(CategoryModel categoryModel);
    }
}
