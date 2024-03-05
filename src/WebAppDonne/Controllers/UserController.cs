using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure.User;

namespace WebApi.Donne.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Properties

        public readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        public UserController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUserAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserModel>))]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                UserRepository dal = new UserRepository(_logger);
                this._logger.Trace("GetUserAsync");
                var ret = await dal.GetAllAsync();
                return Ok(ret);
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler User, rota GetUserAsync " + ex.Message;
                this._logger.TraceException("GetUserAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserModel))]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                UserRepository dal = new UserRepository(_logger);
                this._logger.Trace("GetByIdAsync");
                var ret = await dal.GetByIdAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler User, rota GetByIdAsync " + ex.Message;
                this._logger.TraceException("GetByIdAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserModel))]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                UserRepository dal = new UserRepository(_logger);
                this._logger.Trace("GetByNameAsync");
                var ret = await dal.GetByNameAsync(name);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler User, rota GetByNameAsync " + ex.Message;
                this._logger.TraceException("GetByNameAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpPost(Name = "InsertUser")]
        public async Task Post(UserModel UserModel)
        {
            try
            {
                UserRepository dal = new UserRepository(_logger);
                this._logger.Trace("InsertAsync");
                await dal.InsertAsync(UserModel);
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler User, rota InsertUser " + ex.Message;
                this._logger.TraceException("InsertAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpPut(Name = "UpdateUser")]
        public async Task Update(UserModel UserModel)
        {
            try
            {
                UserRepository dal = new UserRepository(_logger);
                this._logger.Trace("UpdateAsync");
                await dal.UpdateAsync(UserModel);
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler User, rota UpdateAsync " + ex.Message;
                this._logger.TraceException("UpdateAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            try
            {
                UserRepository dal = new UserRepository(_logger);
                this._logger.Trace("DeleteAsync");
                await dal.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler User, rota DeleteAsync " + ex.Message;
                this._logger.TraceException("DeleteAsync");
                throw new ArgumentNullException(mensagem);
            }

        }
    }
}
