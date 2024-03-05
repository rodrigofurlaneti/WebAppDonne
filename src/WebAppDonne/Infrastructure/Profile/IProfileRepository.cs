using Domain.Donne;

namespace WebApi.Donne.Infrastructure.Profile
{
    public interface IProfileRepository
    {
        IEnumerable<ProfileModel> GetAll();
        Task<IEnumerable<ProfileModel>> GetAllAsync();
        ProfileModel GetById(int id);
        Task<ProfileModel> GetByIdAsync(int id);
        void Insert(ProfileModel profileModel);
        Task InsertAsync(ProfileModel profileModel);
        void Delete(int profileId);
        Task DeleteAsync(int profileId);
        void Update(ProfileModel profileModel);
        Task UpdateAsync(ProfileModel profileModel);
    }
}
