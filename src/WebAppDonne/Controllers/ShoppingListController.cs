using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure;

namespace WebApi.Donne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingListController : ControllerBase
    {
        #region Properties

        private readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        public ShoppingListController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            this._logger = logger;
        }

        [HttpGet(Name = "GetShoppingListAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BuyerModel>))]
        public async Task<IActionResult> GetShoppingListAsync()
        {
            try
            {
                ShoppingListRepository dal = new ShoppingListRepository(_logger);
                var ret = await dal.GetAllShoppingListAsync();
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
    }
}