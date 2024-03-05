using Domain.Donne;

namespace WebApi.Donne.Infrastructure.VehicleColor
{
    public interface IVehicleColorRepository
    {
        IEnumerable<VehicleColorModel> GetAll();
        Task<IEnumerable<VehicleColorModel>> GetAllAsync();
        VehicleColorModel GetById(int id);
        Task<VehicleColorModel> GetByIdAsync(int id);
        void Insert(VehicleColorModel vehicleColorModel);
        Task InsertAsync(VehicleColorModel vehicleColorModel);
        void Delete(int vehicleColorId);
        Task DeleteAsync(int vehicleColorId);
        void Update(VehicleColorModel vehicleColorModel);
        Task UpdateAsync(VehicleColorModel vehicleColorModel);
    }
}
