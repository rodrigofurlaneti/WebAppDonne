using Domain.Donne;
using WebApi.Donne.Infrastructure.Buyer;

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

        public IEnumerable<BuyerModel> GetAll()
        {
            try
            {
                this._logger.Trace("BuyerService_GetAll_Entry");
                BuyerModel buyerModel = new BuyerModel();
                BuyerRepository buyerRepository = new BuyerRepository(_logger);
                var listbuyerModel = buyerRepository.GetAll();
                this._logger.Trace("BuyerService_GetAll_Exit");
                return listbuyerModel;
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("BuyerService_GetAll");
                string mensagemErro = "Erro ao consumir a classe BuyerService, método GetAll, síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<IEnumerable<BuyerModel>> GetAllAsync()
        {
            try
            {
                this._logger.Trace("BuyerService_GetAllAsync_Entry");
                BuyerModel buyerModel = new BuyerModel();
                BuyerRepository buyerRepository = new BuyerRepository(_logger);
                var listbuyerModel = await buyerRepository.GetAllAsync();
                this._logger.Trace("BuyerService_GetAllAsync_Exit");
                return listbuyerModel;
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("BuyerService_GetAllAsync");
                string mensagemErro = "Erro ao consumir a classe BuyerService, método GetAllAsync, assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

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

        public BuyerModel GetById(int buyerId)
        {
            try
            {
                this._logger.Trace("BuyerService_GetById_Entry");
                BuyerModel buyerModel = new BuyerModel();
                BuyerRepository buyerRepository = new BuyerRepository(_logger);
                buyerModel = buyerRepository.GetById(buyerId);
                this._logger.Trace("BuyerService_GetById_Exit");
                return buyerModel;
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("BuyerService_GetById");
                string mensagemErro = "Erro ao consumir a classe BuyerService, método GetById, síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<BuyerModel> GetByIdAsync(int buyerId)
        {
            try
            {
                this._logger.Trace("BuyerService_GetByIdAsync_Entry");
                BuyerModel buyerModel = new BuyerModel();
                BuyerRepository buyerRepository = new BuyerRepository(_logger);
                buyerModel = await buyerRepository.GetByIdAsync(buyerId);
                this._logger.Trace("BuyerService_GetByIdAsync_Exit");
                return buyerModel;
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("BuyerService_GetByIdAsync");
                string mensagemErro = "Erro ao consumir a classe BuyerService, método GetById, assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Update(BuyerModel buyerModel)
        {
            try
            {
                this._logger.Trace("BuyerService_Update_Entry");
                BuyerRepository buyerRepository = new BuyerRepository(_logger);
                buyerRepository.Update(buyerModel);
                this._logger.Trace("BuyerService_Update_Exit");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("BuyerService_Update");
                string mensagemErro = "Erro ao consumir a classe BuyerService, método Update, síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task UpdateAsync(BuyerModel buyerModel)
        {
            try
            {
                this._logger.Trace("BuyerService_UpdateAsync_Entry");
                BuyerRepository buyerRepository = new BuyerRepository(_logger);
                await buyerRepository.UpdateAsync(buyerModel);
                this._logger.Trace("BuyerService_UpdateAsync_Exit");
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("BuyerService_UpdateAsync");
                string mensagemErro = "Erro ao consumir a classe BuyerService, método UpdateAsync, assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }


        #endregion
    }
}
