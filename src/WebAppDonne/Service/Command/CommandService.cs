using Domain.Donne;
using WebApi.Donne.Infrastructure.Command;
using WebApi.Donne.Service.Buyer;
using WebApi.Donne.Service.Command;

namespace WebApi.Donne.Service
{
    public class CommandService : ICommandService
    {
        #region Property
        public BuyerService buyerService { get; set; }
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
            try
            {
                this._logger.Trace("CommandService_GetAll_Entry");
                CommandRepository commandRepository = new CommandRepository(_logger);
                var ret = commandRepository.GetAll();
                this._logger.Trace("CommandService_GetAll_Exit");
                return ret;
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("CommandService_GetAll");
                string mensagemErro = "Erro ao consumir a classe BuyerService, método GetAll, síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<IEnumerable<CommandModel>> GetAllAsync()
        {
            try
            {
                this._logger.Trace("CommandService_GetAllAsync_Entry");
                CommandRepository commandRepository = new CommandRepository(_logger);
                var ret = await commandRepository.GetAllAsync();
                this._logger.Trace("CommandService_GetAllAsync_Exit");
                return ret;
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("CommandService_GetAll");
                string mensagemErro = "Erro ao consumir a classe BuyerService, método GetAllAsync, assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Update(CommandModel commandModel)
        {
            try
            {
                this._logger.Trace("CommandService_Update_Entry");
                CommandRepository commandRepository = new CommandRepository(_logger);
                commandRepository.Update(commandModel);
                this._logger.Trace("CommandService_Update_Exit");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("CommandService_Update");
                string mensagemErro = "Erro ao consumir a classe BuyerService, método Update, síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task UpdateAsync(CommandModel commandModel)
        {
            try
            {
                this._logger.Trace("CommandService_UpdateAsync_Entry");
                CommandRepository commandRepository = new CommandRepository(_logger);
                await commandRepository.UpdateAsync(commandModel);
                this._logger.Trace("CommandService_UpdateAsync_Exit");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("CommandService_UpdateAsync");
                string mensagemErro = "Erro ao consumir a classe BuyerService, método UpdateAsync, assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void UpdateStatusCustomer(CommandModel commandModel)
        {
            try
            {
                this._logger.Trace("CommandService_UpdateStatusCustomer_Entry");
                buyerService = new BuyerService(this._logger);
                var buyerModel = buyerService.GetById(commandModel.BuyerId);
                buyerModel.Status = 3;
                buyerService.Update(buyerModel);
                this._logger.Trace("BuyerService_UpdateStatusCustomerAsync_Exit");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("BuyerService_UpdateStatusCustomerAsync");
                string mensagemErro = "Erro ao consumir a classe BuyerService, método UpdateStatusCustomerAsync, síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task UpdateStatusCustomerAsync(CommandModel commandModel)
        {
            try
            {
                this._logger.Trace("CommandService_UpdateStatusCustomerAsync_Entry");
                buyerService = new BuyerService(this._logger);
                var buyerModel = await buyerService.GetByIdAsync(commandModel.BuyerId);
                buyerModel.Status = 3;
                await buyerService.UpdateAsync(buyerModel);
                this._logger.Trace("BuyerService_UpdateStatusCustomerAsync_Exit");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("BuyerService_UpdateStatusCustomerAsync");
                string mensagemErro = "Erro ao consumir a classe BuyerService, método UpdateStatusCustomerAsync, assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        #endregion
    }
}
