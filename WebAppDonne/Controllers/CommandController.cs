using Microsoft.AspNetCore.Mvc;
using WebAppDonne.Dal;
using WebAppDonne.Models;

namespace WebAppDonne.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommandController : Controller
    {
        private readonly ILogger<CommandController> _logger;

        public CommandController(ILogger<CommandController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCommand")]
        public IEnumerable<CommandModel> Get()
        {
            CommandRepository dal = new CommandRepository();
            var ret = dal.GetAllCommand();
            return (ret);
        }

        [HttpGet("{id:int}")]
        public CommandModel Get(int id)
        {
            CommandRepository dal = new CommandRepository();
            var ret = dal.GetById(id);
            return (ret);
        }

        [HttpPost(Name = "InsertCommand")]
        public int Post(CommandModel commandModel)
        {
            CommandRepository dal = new CommandRepository();
            return dal.InsertReturnId(commandModel);
        }

        [HttpPut(Name = "UpdateCommands")]
        public void Update(CommandModel commandModel)
        {
            CommandRepository dal = new CommandRepository();
            dal.Update(commandModel);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            CommandRepository dal = new CommandRepository();
            dal.Delete(id);
        }
    }
}
