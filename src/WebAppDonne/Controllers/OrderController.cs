using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure;

namespace WebApi.Donne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetOrder")]
        public IEnumerable<OrderModel> Get()
        {
            OrderRepository dal = new OrderRepository();
            var ret = dal.GetAllOrders();
            return (ret);
        }

        [HttpGet("{id:int}")]
        public OrderModel Get(int id)
        {
            OrderRepository dal = new OrderRepository();
            var ret = dal.GetById(id);
            return (ret);
        }

        [HttpPost(Name = "InsertOrder")]
        public void Post(OrderModel OrderModel)
        {
            OrderRepository dal = new OrderRepository();
            dal.Insert(OrderModel);
        }

        [HttpPut(Name = "UpdateOrder")]
        public void Update(OrderModel OrderModel)
        {
            OrderRepository dal = new OrderRepository();
            dal.Update(OrderModel);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            OrderRepository dal = new OrderRepository();
            dal.Delete(id);
        }
    }
}
