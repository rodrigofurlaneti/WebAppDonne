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

        [HttpGet(Name = "GetOrder")]
        public IEnumerable<OrderModel> Get()
        {
            OrderRepository dal = new OrderRepository(_logger);
            var ret = dal.GetAllOrders();
            return (ret);
        }

        [HttpGet("{id:int}")]
        public OrderModel Get(int id)
        {
            OrderRepository dal = new OrderRepository(_logger);
            var ret = dal.GetById(id);
            return (ret);
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
