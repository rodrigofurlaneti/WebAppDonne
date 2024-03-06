using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using System.Data.SqlClient;
using WebApi.Donne.Infrastructure.Buyer;
using WebApi.Donne.Service.Buyer;

namespace WebApi.Donne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuyerController : ControllerBase
    {
        #region Properties

        private readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        #region Constructor

        public BuyerController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            this._logger = logger;
        }

        #endregion

        #region Methods

        [HttpGet(Name = "GetBuyerAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BuyerModel>))]
        public async Task<IActionResult> GetBuyer()
        {
            try
            {
                BuyerRepository dal = new BuyerRepository(_logger);
                var ret = await dal.GetAllAsync();
                _logger.Trace("GetBuyerAsync");
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("GetBuyerAsync");
                string mensagem = "Erro ao consumir a controler Buyer, rota GetBuyers " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpOptions("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BuyerModel>))]
        public async Task<IActionResult> OptionsAsync(int id)
        {
            try
            {
                BuyerRepository dal = new BuyerRepository(_logger);
                _logger.Trace("OptionsAsync");
                var ret = await dal.GetByStatusAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("OptionsAsync");
                string mensagem = "Erro ao consumir a controler Buyer, rota OptionsAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BuyerModel>))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                BuyerRepository dal = new BuyerRepository(_logger);
                _logger.Trace("GetByIdAsync");
                var ret = await dal.GetByIdAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("GetByIdAsync");
                string mensagem = "Erro ao consumir a controler Buyer, rota GetByIdAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpPost(Name = "InsertBuyer")]
        public async Task Post(BuyerModel buyerModel)
        {
            try
            {
                BuyerRepository dal = new BuyerRepository(_logger);
                _logger.Trace("InsertAsync");
                await dal.InsertAsync(buyerModel);
            }
            catch (Exception ex)
            {
                _logger.TraceException("InsertAsync");
                string mensagem = "Erro ao consumir a controler Buyer, rota Post " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpPut(Name = "UpdateBuyer")]
        public async Task Update(BuyerModel buyerModel)
        {
            try
            {
                BuyerRepository dal = new BuyerRepository(_logger);
                BuyerService buyerService = new BuyerService(_logger);
                _logger.Trace("UpdateAsync");
                await dal.UpdateAsync(buyerModel);
                buyerService.UpdateCustomersNameInCommand(buyerModel);

            }
            catch (Exception ex)
            {
                _logger.TraceException("UpdateAsync");
                string mensagem = "Erro ao consumir a controler Buyer, rota Update " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            try
            {
                _logger.Trace("DeleteAsync");
                BuyerRepository dal = new BuyerRepository(_logger);
                await dal.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.TraceException("DeleteAsync");
                string mensagem = "Erro ao consumir a controler Buyer, rota DeleteAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        #endregion
    }
}
