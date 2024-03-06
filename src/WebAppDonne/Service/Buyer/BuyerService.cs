using Domain.Donne;

namespace WebApi.Donne.Service.Buyer
{
    public class BuyerService : IBuyerService
    {
        #region Property
        
        public CommandService commandService { get; set; }
        public readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;
        #endregion

        #region Constructor

        public BuyerService(Infrastructure.SeedWork.ILogger logger)
        {
            this._logger = logger;
        }

        #endregion

        #region Methods

        public void UpdateCustomersNameInCommand(BuyerModel buyerModel)
        {
            try
            {
                this._logger.Trace("BuyerService_UpdateCustomersNameInCommand_Entry");
                commandService = new CommandService(this._logger);
                var getAll = commandService.GetAll();
                if (getAll.Count() > 0)
                {
                    foreach (var item in getAll)
                    {
                        if (item.BuyerId.Equals(buyerModel.BuyerId))
                        {
                            var commandModel = new CommandModel();
                            commandModel.CommandId = item.CommandId;
                            commandModel.BuyerId = item.BuyerId;
                            commandModel.BuyerName = buyerModel.BuyerName;
                            commandModel.UserId = item.UserId;
                            commandModel.UserName = item.UserName;
                            commandModel.DateInsert = item.DateInsert;
                            commandModel.DateUpdate = item.DateUpdate;
                            commandModel.Status = item.Status;
                            commandService.Update(commandModel);
                        }
                    }
                }
                this._logger.Trace("BuyerService_UpdateCustomersNameInCommand_Exit");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("BuyerService_UpdateCustomersNameInCommand");
                string mensagemErro = "Erro ao consumir a classe BuyerService, método UpdateCustomersNameInCommand, síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task UpdateCustomersNameInCommandAsync(BuyerModel buyerModel)
        {
            try
            {
                this._logger.Trace("BuyerService_UpdateCustomersNameInCommandAsync_Entry");
                commandService = new CommandService(this._logger);
                var getAll = await commandService.GetAllAsync();
                if (getAll.Count() > 0)
                {
                    foreach (var item in getAll)
                    {
                        if (item.BuyerId.Equals(buyerModel.BuyerId))
                        {
                            var commandModel = new CommandModel();
                            commandModel.CommandId = item.CommandId;
                            commandModel.BuyerId = item.BuyerId;
                            commandModel.BuyerName = buyerModel.BuyerName;
                            commandModel.UserId = item.UserId;
                            commandModel.UserName = item.UserName;
                            commandModel.DateInsert = item.DateInsert;
                            commandModel.DateUpdate = item.DateUpdate;
                            commandModel.Status = item.Status;
                            commandService.Update(commandModel);
                        }
                    }
                }
                this._logger.Trace("BuyerService_UpdateCustomersNameInCommandAsync_Exit");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("BuyerService_UpdateCustomersNameInCommandAsync");
                string mensagemErro = "Erro ao consumir a classe BuyerService, método UpdateCustomersNameInCommandAsync, assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        #endregion
    }
}
