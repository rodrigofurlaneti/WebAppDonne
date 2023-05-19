using Microsoft.AspNetCore.Mvc;
using WebAppDonne.Dal;
using WebAppDonne.Models;

namespace WebAppDonne.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommandOrderController : Controller
    {
        private readonly ILogger<CommandController> _logger;

        public CommandOrderController(ILogger<CommandController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id:int}")]
        public IEnumerable<CommandOrderModel> GetCommandOrder(int id)
        {
            CommandOrderRepository dal = new CommandOrderRepository();
            var ret = dal.GetCommandOrder(id);
            return (ret);
        }
    }
}
