using Domain.Donne;

namespace WebApi.Donne.Infrastructure.Authentication
{
    public interface IAuthenticationRepository
    {
        IEnumerable<AuthenticationModel> GetAll();
        Task<IEnumerable<AuthenticationModel>> GetAllAsync();
        AuthenticationModel GetById(int id);
        Task<AuthenticationModel> GetByIdAsync(int id);
        void Insert(AuthenticationModel AuthenticationModel);
        Task InsertAsync(AuthenticationModel AuthenticationModel);
    }
}
