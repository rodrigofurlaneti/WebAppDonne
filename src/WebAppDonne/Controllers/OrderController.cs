using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure.Order;

namespace WebApi.Donne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        #region Properties

        public readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        public OrderController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetOrderAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrderModel>))]
        public async Task<IActionResult> GetOrder()
        {
            try
            {
                this._logger.Trace("GetOrdersAsync");
                OrderRepository dal = new OrderRepository(_logger);
                var ret = await dal.GetAllAsync();
                return Ok(ret);
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("GetAllOrdersAsync");
                string mensagem = "Erro ao consumir a controler Order, rota GetAllOrdersAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FormOfPaymentModel))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                OrderRepository dal = new OrderRepository(_logger);
                var ret = await dal.GetByIdAsync(id);
                _logger.Trace("GetByIdAsync");
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("GetAllOrdersAsync");
                string mensagem = "Erro ao consumir a controler Order, rota GetAllOrdersAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpPost(Name = "InsertAsync")]
        public async Task Post(OrderModel OrderModel)
        {
            try
            {
                OrderRepository dal = new OrderRepository(_logger);
                _logger.Trace("InsertAsync");
                await dal.InsertAsync(OrderModel);
            }
            catch (Exception ex)
            {
                _logger.TraceException("InsertAsync");
                string mensagem = "Erro ao consumir a controler Order, rota InsertAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpPut(Name = "UpdateAsync")]
        public async Task Update(OrderModel OrderModel)
        {
            try
            {
                OrderRepository dal = new OrderRepository(_logger);
                _logger.Trace("UpdateAsync");
                await dal.UpdateAsync(OrderModel);
            }
            catch (Exception ex)
            {
                _logger.TraceException("UpdateAsync");
                string mensagem = "Erro ao consumir a controler Order, rota UpdateAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            try
            {
                OrderRepository dal = new OrderRepository(_logger);
                _logger.Trace("DeleteAsync");
                await dal.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.TraceException("DeleteAsync");
                string mensagem = "Erro ao consumir a controler Order, rota DeleteAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }
    }
}
