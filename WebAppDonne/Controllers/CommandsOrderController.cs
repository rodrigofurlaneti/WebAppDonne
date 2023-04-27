using Microsoft.AspNetCore.Mvc;
using WebAppDonne.Dal;
using WebAppDonne.Models;

namespace WebAppDonne.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommandsOrderController : Controller
    {
        private readonly ILogger<CommandsOrderController> _logger;

        public CommandsOrderController(ILogger<CommandsOrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCommandsOrder")]
        public IEnumerable<CommandsOrderModel> Get()
        {
            CommandsOrderRepository dal = new CommandsOrderRepository();
            var ret = dal.GetAllCommandsOrders();
            return (ret);
        }

        [HttpGet("{id:int}")]
        public CommandsOrderModel Get(int id)
        {
            CommandsOrderRepository dal = new CommandsOrderRepository();
            var ret = dal.GetById(id);
            return (ret);
        }

        [HttpPost(Name = "InsertCommandsOrder")]
        public void Post(CommandsOrderModel CommandsOrderModel)
        {
            CommandsOrderRepository dal = new CommandsOrderRepository();
            dal.Insert(CommandsOrderModel);
        }

        [HttpPut(Name = "UpdateCommandsOrder")]
        public void Update(CommandsOrderModel CommandsOrderModel)
        {
            CommandsOrderRepository dal = new CommandsOrderRepository();
            dal.Update(CommandsOrderModel);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            CommandsOrderRepository dal = new CommandsOrderRepository();
            dal.Delete(id);
        }
    }
}
