using Domain.Donne;

namespace WebApi.Donne.Service.Command
{
    public interface ICommandService
    {
        public IEnumerable<CommandModel> GetAll();
        public Task<IEnumerable<CommandModel>> GetAllAsync();
        public void Update(CommandModel commandModel);
        public Task UpdateAsync(CommandModel commandModel);
    }
}
