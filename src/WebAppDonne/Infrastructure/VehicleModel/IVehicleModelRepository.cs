namespace WebApi.Donne.Infrastructure.VehicleModel
{
    public interface IVehicleModelRepository
    {
        IEnumerable<Domain.Donne.VehicleModel> GetAll();
        Task<IEnumerable<Domain.Donne.VehicleModel>> GetAllAsync();
        Domain.Donne.VehicleModel GetById(int id);
        Task<Domain.Donne.VehicleModel> GetByIdAsync(int id);
        void Insert(Domain.Donne.VehicleModel vehicleModel);
        Task InsertAsync(Domain.Donne.VehicleModel vehicleModel);
        void Delete(int vehicleId);
        Task DeleteAsync(int vehicleId);
        void Update(Domain.Donne.VehicleModel vehicleModel);
        Task UpdateAsync(Domain.Donne.VehicleModel vehicleModel);
    }
}
