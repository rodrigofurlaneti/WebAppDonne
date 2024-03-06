using Domain.Donne;
using WebApi.Donne.Infrastructure.Command;
using WebApi.Donne.Service.Command;

namespace WebApi.Donne.Service
{
    public class CommandService : ICommandService
    {
        #region Property

        public readonly Infrastructure.SeedWork.ILogger _logger;

        #endregion

        #region Constructor

        public CommandService(Infrastructure.SeedWork.ILogger logger)
        {
            this._logger = logger;
        }

        #endregion

        #region Methods

        public IEnumerable<CommandModel> GetAll()
        {
            this._logger.Trace("CommandService_GetAll_Entry");
            CommandRepository commandRepository = new CommandRepository(_logger);
            var ret = commandRepository.GetAll();
            this._logger.Trace("CommandService_GetAll_Exit");
            return ret;
        }

        public async Task<IEnumerable<CommandModel>> GetAllAsync()
        {
            this._logger.Trace("CommandService_GetAllAsync_Entry");
            CommandRepository commandRepository = new CommandRepository(_logger);
            var ret = await commandRepository.GetAllAsync();
            this._logger.Trace("CommandService_GetAllAsync_Exit");
            return ret;
        }

        public void Update(CommandModel commandModel)
        {
            this._logger.Trace("CommandService_Update_Entry");
            CommandRepository commandRepository = new CommandRepository(_logger);
            commandRepository.Update(commandModel);
            this._logger.Trace("CommandService_Update_Exit");
        }

        public async Task UpdateAsync(CommandModel commandModel)
        {
            this._logger.Trace("CommandService_UpdateAsync_Entry");
            CommandRepository commandRepository = new CommandRepository(_logger);
            await commandRepository.UpdateAsync(commandModel);
            this._logger.Trace("CommandService_UpdateAsync_Exit");
        }

        #endregion
    }
}
