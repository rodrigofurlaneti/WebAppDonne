using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure;

namespace WebApi.Donne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuyerController : ControllerBase
    {
        #region Properties

        private readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        public BuyerController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            this._logger = logger;
        }

        [HttpGet(Name = "GetBuyersAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BuyerModel>))]
        public async Task<IActionResult> GetBuyersAsync()
        {
            try
            {
                BuyerRepository dal = new BuyerRepository(_logger);
                var ret = await dal.GetAllBuyersAsync();
                _logger.Trace("GetBuyerAsync");
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceExeption("GetBuyer");
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
                var ret = await dal.GetByStatusAsync(id);
                _logger.Trace("OptionsAsync");
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceExeption("OptionsAsync");
                string mensagem = "Erro ao consumir a controler Buyer, rota OptionsAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpGet("{id:int}")]
        public BuyerModel Get(int id)
        {
            BuyerRepository dal = new BuyerRepository(_logger);
            var ret = dal.GetById(id);
            return (ret);
        }

        [HttpPost(Name = "InsertBuyer")]
        public void Post(BuyerModel buyerModel)
        {
            BuyerRepository dal = new BuyerRepository(_logger);
            dal.InsertAsync(buyerModel);
        }

        [HttpPut(Name = "UpdateBuyer")]
        public void Update(BuyerModel buyerModel)
        {
            BuyerRepository dal = new BuyerRepository(_logger);
            dal.Update(buyerModel);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            BuyerRepository dal = new BuyerRepository(_logger);
            dal.DeleteAsync(id);
        }
    }
}
