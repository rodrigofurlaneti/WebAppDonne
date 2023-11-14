using Domain.Donne;
using Microsoft.AspNetCore.Mvc;
using WebApi.Donne.Infrastructure;

namespace WebApi.Donne.Controllers
{
    public class CommandOrderController : Controller
    {
        #region Properties

        public readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        public CommandOrderController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet("CommandOrder/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CommandOrderModel>))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                CommandOrderRepository dal = new CommandOrderRepository(_logger);
                this._logger.Trace("GetCommandOrdersByIdAsync");
                var ret = await dal.GetCommandOrdersByIdAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                this._logger.TraceException("GetCommandOrdersByIdAsync");
                string mensagem = "Erro ao consumir a controler Command, rota GetCommandOrdersByIdAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }
    }
}
