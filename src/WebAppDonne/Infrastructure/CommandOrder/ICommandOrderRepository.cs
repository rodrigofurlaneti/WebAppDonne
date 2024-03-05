using Domain.Donne;

namespace WebApi.Donne.Infrastructure.CommandOrder
{
    public interface ICommandOrderRepository
    {
        IEnumerable<CommandOrderModel> GetById(int id);
        Task<IEnumerable<CommandOrderModel>> GetByIdAsync(int id);
    }
}
