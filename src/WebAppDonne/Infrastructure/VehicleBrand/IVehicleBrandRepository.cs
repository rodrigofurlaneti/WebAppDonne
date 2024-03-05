using Domain.Donne;

namespace WebApi.Donne.Infrastructure.VehicleBrand
{
    public interface IVehicleBrandRepository
    {
        IEnumerable<VehicleBrandModel> GetAll();
        Task<IEnumerable<VehicleBrandModel>> GetAllAsync();
        VehicleBrandModel GetById(int id);
        Task<VehicleBrandModel> GetByIdAsync(int id);
        void Insert(VehicleBrandModel vehicleBrandModel);
        Task InsertAsync(VehicleBrandModel vehicleBrandModel);
        void Delete(int vehicleBrandId);
        Task DeleteAsync(int vehicleBrandId);
        void Update(VehicleBrandModel vehicleBrandModel);
        Task UpdateAsync(VehicleBrandModel vehicleBrandModel);
    }
}
