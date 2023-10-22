using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure;

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
        public async Task<IActionResult> Get()
        {
            try
            {
                OrderRepository dal = new OrderRepository(_logger);
                var ret = await dal.GetAllOrdersAsync();
                _logger.Trace("GetOrdersAsync");
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("GetAllOrdersAsync");
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

        [HttpPost(Name = "InsertOrder")]
        public void Post(OrderModel OrderModel)
        {
            OrderRepository dal = new OrderRepository(_logger);
            dal.Insert(OrderModel);
        }

        [HttpPut(Name = "UpdateOrder")]
        public void Update(OrderModel OrderModel)
        {
            OrderRepository dal = new OrderRepository(_logger);
            dal.Update(OrderModel);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            OrderRepository dal = new OrderRepository(_logger);
            dal.Delete(id);
        }
    }
}
