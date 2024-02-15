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

        [HttpPost(Name = "InsertAuthentication")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserModel))]
        public async Task<IActionResult> Post(AuthenticationUserModel authenticationUserModel)
        {
            try
            {
                AuthenticationModel authenticationModel = new AuthenticationModel();
                AuthenticationBusiness authenticationBusiness = new AuthenticationBusiness();
                AuthenticationRepository authenticationRepository = new AuthenticationRepository(_logger);
                UserRepository userRepository = new UserRepository(_logger);
                UserBusiness userBusiness = new UserBusiness();
                var userModelBd = await userRepository.GetByNameAsync(authenticationUserModel.UserName);
                authenticationModel.ClientInternetProtocol = authenticationUserModel.ClientInternetProtocol;
                authenticationModel.NavigatorUserAgent = authenticationUserModel.NavigatorUserAgent;
                if (userModelBd.UserName == null)
                {
                    authenticationModel = authenticationBusiness.SimpleAuthenticationInvalidUserName(authenticationModel);
                    this._logger.Trace("Authentication_InvalidUserName_InsertAsync");
                }   
                else
                {
                    if (userBusiness.SimpleAuthentication(authenticationUserModel, userModelBd))
                    {
                        authenticationModel = authenticationBusiness.SimpleAuthenticationSuccess(authenticationModel);
                        this._logger.Trace("Authentication_Success_InsertAsync");
                    }
                    else
                    {
                        authenticationModel = authenticationBusiness.SimpleAuthenticationInvalidPassword(authenticationModel);
                        this._logger.Trace("Authentication_InvalidPassword_InsertAsync");
                    }
                }
                await authenticationRepository.InsertAsync(authenticationModel);
                return Ok(userModelBd);
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler Authentication, rota InsertAuthentication " + ex.Message;
                this._logger.TraceException("Authentication_InsertAsync");
                throw new ArgumentNullException(mensagem);
            }
        }
    }
}