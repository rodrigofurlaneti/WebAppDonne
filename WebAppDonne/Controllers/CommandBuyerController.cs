using Microsoft.AspNetCore.Mvc;
using WebAppDonne.Dal;
using WebAppDonne.Models;

namespace WebAppDonne.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommandBuyerController : Controller
    {
            private readonly ILogger<CommandBuyerController> _logger;

            public CommandBuyerController(ILogger<CommandBuyerController> logger)
            {
                _logger = logger;
            }

            [HttpGet("{id:int}")]
            public IEnumerable<CommandBuyerModel> GetCommandBuyer(int id)
            {
                CommandBuyerRepository dal = new CommandBuyerRepository();
                var ret = dal.GetCommandBuyer(id);
                return (ret);
            }
    }
}
