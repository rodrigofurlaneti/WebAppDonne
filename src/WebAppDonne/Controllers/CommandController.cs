using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure;

namespace WebApi.Donne.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommandController : Controller
    {
        #region Properties

        public readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        public CommandController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCommand")]
        public IEnumerable<CommandModel> GetCommand()
        {
            CommandRepository dal = new CommandRepository(_logger);
            var ret = dal.GetAllCommand();
            return (ret);
        }
        [HttpOptions("{id:int}")]
        public IEnumerable<CommandModel> Options(int id)
        {
            CommandRepository dal = new CommandRepository(_logger);
            var ret = dal.GetByStatus(id);
            return (ret);
        }

        [HttpPatch("{id:int}")]
        public IEnumerable<CommandOrderModel> Patch(int id)
        {
            CommandRepository dal = new CommandRepository(_logger);
            var ret = dal.GetCommandOrder(id);
            return (ret);
        }


        [HttpGet("{id:int}")]
        public CommandModel Get(int id)
        {
            CommandRepository dal = new CommandRepository(_logger);
            var ret = dal.GetById(id);
            return (ret);
        }

        [HttpPost(Name = "InsertCommand")]
        public int Post(CommandModel commandModel)
        {
            CommandRepository dal = new CommandRepository(_logger);
            return dal.InsertReturnId(commandModel);
        }

        [HttpPut(Name = "UpdateCommands")]
        public void Update(CommandModel commandModel)
        {
            CommandRepository dal = new CommandRepository(_logger);
            dal.Update(commandModel);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            CommandRepository dal = new CommandRepository(_logger);
            dal.Delete(id);
        }
    }
}
