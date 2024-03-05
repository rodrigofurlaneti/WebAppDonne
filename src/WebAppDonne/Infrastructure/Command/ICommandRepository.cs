using Domain.Donne;

namespace WebApi.Donne.Infrastructure.Command
{
    public interface ICommandRepository
    {
        IEnumerable<CommandModel> GetAll();
        Task<IEnumerable<CommandModel>> GetAllAsync();
        IEnumerable<CommandModel> GetByStatus(int status);
        Task<IEnumerable<CommandModel>> GetByStatusAsync(int status);
        CommandModel GetById(int id);
        Task<CommandModel> GetByIdAsync(int id);
        void Insert(CommandModel commandModel);
        Task InsertAsync(CommandModel commandModel);
        void Delete(int commandId);
        Task DeleteAsync(int commandId);
        void Update(CommandModel commandModel);
        Task UpdateAsync(CommandModel commandModel);
    }
}
