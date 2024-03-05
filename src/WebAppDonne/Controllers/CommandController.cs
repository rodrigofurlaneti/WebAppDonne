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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CommandModel>))]
        public async Task<IActionResult> GetCommand()
        {
            try
            {
                CommandRepository dal = new CommandRepository(_logger);
                this._logger.Trace("Command_GetAllAsync");
                var ret = await dal.GetAllCommandAsync();
                return Ok(ret);
            }
            catch (Exception ex)
            {
                this._logger.TraceException("Command_GetAllAsync");
                string mensagem = "Erro ao consumir a controler Command, rota GetAllCommandsAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandModel))]
        public async Task<IActionResult> GetCommand(int id)
        {
            try
            {
                CommandRepository dal = new CommandRepository(_logger);
                this._logger.Trace("Command_GetByIdAsync");
                var ret = await dal.GetByIdAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                this._logger.TraceException("Command_GetByIdAsync");
                string mensagem = "Erro ao consumir a controler Command, rota GetByIdAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpOptions("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CommandModel>))]
        public async Task<IActionResult> Options(int id)
        {
            try
            {
                CommandRepository dal = new CommandRepository(_logger);
                this._logger.Trace("Command_GetByStatusAsync");
                var ret = await dal.GetByStatusAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                this._logger.TraceException("Command_GetByStatusAsync");
                string mensagem = "Erro ao consumir a controler Command, rota GetByStatusAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpPost(Name = "InsertCommand")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> Post(CommandModel commandModel)
        {
            try
            {
                CommandRepository dal = new CommandRepository(_logger);
                this._logger.Trace("InsertReturnIntAsync");
                var ret = await dal.InsertReturnIdAsync(commandModel);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                this._logger.TraceException("InsertReturnIntAsync");
                string mensagem = "Erro ao consumir a controler Command, rota GetByIdAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpPut(Name = "UpdateCommands")]
        public async Task Update(CommandModel commandModel)
        {
            try
            {
                this._logger.Trace("Command_UpdateAsync");
                CommandRepository dal = new CommandRepository(_logger);
                await dal.UpdateAsync(commandModel);
            }
            catch (Exception ex)
            {
                this._logger.TraceException("Command_UpdateAsync");
                string mensagem = "Erro ao consumir a controler Command, rota UpdateAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            try
            {
                CommandRepository dal = new CommandRepository(_logger);
                this._logger.Trace("Command_DeleteAsync");
                await dal.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                this._logger.TraceException("Command_DeleteAsync");
                string mensagem = "Erro ao consumir a controler Command, rota DeleteAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }
    }
}
