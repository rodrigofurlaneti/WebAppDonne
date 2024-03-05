namespace WebApi.Donne.Infrastructure.Vehicle
{
    public interface IVehicleRepository
    {
        IEnumerable<Domain.Donne.Vehicle> GetAll();
        Task<IEnumerable<Domain.Donne.Vehicle>> GetAllAsync();
        Domain.Donne.Vehicle GetById(int id);
        Task<Domain.Donne.Vehicle> GetByIdAsync(int id);
        void Insert(Domain.Donne.Vehicle vehicleModel);
        Task InsertAsync(Domain.Donne.Vehicle vehicleModel);
        void Delete(int vehicleId);
        Task DeleteAsync(int vehicleId);
        void Update(Domain.Donne.Vehicle vehicleModel);
        Task UpdateAsync(Domain.Donne.Vehicle vehicleModel);
    }
}
