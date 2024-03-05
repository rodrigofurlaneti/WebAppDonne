using Domain.Donne;

namespace WebApi.Donne.Infrastructure.VehicleTypeRepository
{
    public interface IVehicleTypeRepository
    {
        IEnumerable<VehicleTypeModel> GetAll();
        Task<IEnumerable<VehicleTypeModel>> GetAllAsync();
        VehicleTypeModel GetById(int id);
        Task<VehicleTypeModel> GetByIdAsync(int id);
        void Insert(VehicleTypeModel vehicleTypeModel);
        Task InsertAsync(VehicleTypeModel vehicleTypeModel);
        void Delete(int vehicleId);
        Task DeleteAsync(int vehicleId);
        void Update(VehicleTypeModel vehicleTypeModel);
        Task UpdateAsync(VehicleTypeModel vehicleTypeModel);
    }
}
