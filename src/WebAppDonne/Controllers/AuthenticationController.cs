using Business.Donne;
using Domain.Donne;
using Microsoft.AspNetCore.Mvc;
using WebApi.Donne.Infrastructure;

namespace WebApi.Donne.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        #region Properties

        public readonly Infrastructure.SeedWork.ILogger _logger;

        #endregion

        public AuthenticationController(Infrastructure.SeedWork.ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAuthenticationAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AuthenticationModel>))]
        public async Task<IActionResult> Get()
        {
            try
            {
                AuthenticationRepository dal = new AuthenticationRepository(_logger);
                this._logger.Trace("User_GetUserAsync");
                var ret = await dal.GetAllAuthenticationsAsync();
                return Ok(ret);
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler User, rota GetUserAsync " + ex.Message;
                this._logger.TraceException("User_GetUserAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthenticationModel))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                AuthenticationRepository dal = new AuthenticationRepository(_logger);
                this._logger.Trace("User_GetByIdAsync");
                var ret = await dal.GetByIdAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler User, rota GetByIdAsync " + ex.Message;
                this._logger.TraceException("User_GetByIdAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpPost(Name = "InsertAuthentication")]
        public async Task Post(UserModel userModel)
        {
            try
            {
                AuthenticationModel authenticationModel = new AuthenticationModel();
                AuthenticationBusiness authenticationBusiness = new AuthenticationBusiness();
                AuthenticationRepository authenticationRepository = new AuthenticationRepository(_logger);
                UserRepository userRepository = new UserRepository(_logger);
                UserBusiness userBusiness = new UserBusiness();
                var userModelBd = await userRepository.GetByNameAsync(userModel.UserName);
                if (userModelBd.UserName == null)
                    authenticationModel = authenticationBusiness.SimpleAuthenticationInvalidUserName(authenticationModel);
                else
                    if (userBusiness.SimpleAuthentication(userModel, userModelBd))
                    authenticationModel = authenticationBusiness.SimpleAuthenticationSuccess(authenticationModel);
                else
                    authenticationModel = authenticationBusiness.SimpleAuthenticationInvalidPassword(authenticationModel);
                this._logger.Trace("Authentication_InsertAsync");
                await authenticationRepository.InsertAsync(authenticationModel);
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler Authentication, rota InsertAuthentication " + ex.Message;
                this._logger.TraceException("Authentication_InsertAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpPut(Name = "UpdateAuthentication")]
        public async Task Update(AuthenticationModel AuthenticationModel)
        {
            try
            {
                AuthenticationRepository dal = new AuthenticationRepository(_logger);
                this._logger.Trace("Authentication_UpdateAsync");
                await dal.UpdateAsync(AuthenticationModel);
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler Authentication, rota UpdateAsync " + ex.Message;
                this._logger.TraceException("Authentication_UpdateAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            try
            {
                AuthenticationRepository dal = new AuthenticationRepository(_logger);
                this._logger.Trace("Authentication_DeleteAsync");
                await dal.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler Authentication, rota DeleteAsync " + ex.Message;
                this._logger.TraceException("Authentication_DeleteAsync");
                throw new ArgumentNullException(mensagem);
            }
        }
    }
}