using Domain.Donne;
using Microsoft.AspNetCore.Mvc;
using WebApi.Donne.Infrastructure.StockInventory;

namespace WebApi.Donne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockInventoryController : ControllerBase
    {
        #region Properties

        public readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        public StockInventoryController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetStockInventoryAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<StockInventoryModel>))]
        public async Task<IActionResult> GetStockInventory()
        {
            try
            {
                StockInventoryRepository dal = new StockInventoryRepository(_logger);
                this._logger.Trace("GetStockInventoryAsync");
                var ret = await dal.GetAllAsync();
                return Ok(ret);
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler StockInventory, rota GetStockInventoryAsync " + ex.Message;
                this._logger.TraceException("GetStockInventoryAsync");
                throw new ArgumentNullException(mensagem);
            }
        }
    }
}
