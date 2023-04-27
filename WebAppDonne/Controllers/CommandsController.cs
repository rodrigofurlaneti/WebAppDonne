using Microsoft.AspNetCore.Mvc;
using WebAppDonne.Dal;
using WebAppDonne.Models;

namespace WebAppDonne.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommandsController : Controller
    {
        private readonly ILogger<CommandsController> _logger;

        public CommandsController(ILogger<CommandsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCommands")]
        public IEnumerable<CommandsModel> Get()
        {
            CommandsRepository dal = new CommandsRepository();
            var ret = dal.GetAllCommands();
            return (ret);
        }

        [HttpGet("{id:int}")]
        public CommandsModel Get(int id)
        {
            CommandsRepository dal = new CommandsRepository();
            var ret = dal.GetById(id);
            return (ret);
        }

        [HttpPost(Name = "InsertCommands")]
        public void Post(CommandsModel CommandsModel)
        {
            CommandsRepository dal = new CommandsRepository();
            dal.Insert(CommandsModel);
        }

        [HttpPut(Name = "UpdateCommands")]
        public void Update(CommandsModel CommandsModel)
        {
            CommandsRepository dal = new CommandsRepository();
            dal.Update(CommandsModel);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            CommandsRepository dal = new CommandsRepository();
            dal.Delete(id);
        }
    }
}
