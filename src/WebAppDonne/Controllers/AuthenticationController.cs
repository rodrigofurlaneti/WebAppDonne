using Business.Donne;
using Domain.Donne;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Donne.Infrastructure.Authentication;
using WebApi.Donne.Infrastructure.User;

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
        public async Task<IActionResult> GetAuthentication()
        {
            try
            {
                AuthenticationRepository dal = new AuthenticationRepository(_logger);
                this._logger.Trace("User_GetUserAsync");
                var ret = await dal.GetAllAsync();
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
                this._logger.Trace("Authentication_InsertAuthentication");
                AuthenticationModel authenticationModel = new AuthenticationModel();
                AuthenticationRepository authenticationRepository = new AuthenticationRepository(_logger);
                UserRepository userRepository = new UserRepository(_logger);
                var userModelBd = await userRepository.GetByNameAsync(authenticationUserModel.UserName);
                authenticationModel.ClientInternetProtocol = authenticationUserModel.ClientInternetProtocol;
                authenticationModel.NavigatorUserAgent = authenticationUserModel.NavigatorUserAgent;
                authenticationModel.ServerInternetProtocol = authenticationUserModel.ServerInternetProtocol;
                if (userModelBd.UserName == null)
                {
                    authenticationModel = AuthenticationBusiness.SimpleAuthenticationInvalidUserName(authenticationModel);
                    this._logger.Trace("Authentication_InvalidUserName_InsertAsync");
                    await authenticationRepository.InsertAsync(authenticationModel);
                    return Unauthorized("InvalidUserName");
                }
                else
                {
                    if (UserBusiness.SimpleAuthentication(authenticationUserModel, userModelBd))
                    {
                        AuthenticationBusiness.SimpleAuthenticationSuccess(authenticationModel);
                        this._logger.Trace("Authentication_Success_InsertAsync");
                        await authenticationRepository.InsertAsync(authenticationModel);
                        return Ok(userModelBd);
                    }
                    else
                    {
                        authenticationModel = AuthenticationBusiness.SimpleAuthenticationInvalidPassword(authenticationModel);
                        this._logger.Trace("Authentication_InvalidPassword_InsertAsync");
                        await authenticationRepository.InsertAsync(authenticationModel);
                        return Unauthorized("InvalidPassword");
                    }
                }
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler Authentication, rota InsertAuthentication " + ex.Message;
                this._logger.TraceException("Authentication_InsertAuthentication");
                throw new ArgumentNullException(mensagem);
            }
        }
    }
}