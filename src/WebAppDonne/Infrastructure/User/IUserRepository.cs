using Domain.Donne;

namespace WebApi.Donne.Infrastructure.User
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetAll();
        Task<IEnumerable<UserModel>> GetAllAsync();
        UserModel GetById(int id);
        Task<UserModel> GetByIdAsync(int id);
        void Insert(UserModel userModel);
        Task InsertAsync(UserModel userModel);
        void Delete(int userId);
        Task DeleteAsync(int userId);
        void Update(UserModel userModel);
        Task UpdateAsync(UserModel userModel);
    }
}
