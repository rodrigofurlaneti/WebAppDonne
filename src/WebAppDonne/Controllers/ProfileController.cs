using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure;

namespace WebApi.Donne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        #region Properties

        public readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        public ProfileController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProfileAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProfileModel>))]
        public async Task<IActionResult> Get()
        {
            try
            {
                ProfileRepository dal = new ProfileRepository(_logger);
                this._logger.Trace("GetProfileAsync");
                var ret = await dal.GetAllProfilesAsync();
                return Ok(ret);
            }
            catch (ArgumentNullException ex)
            {
                string mensagem = "Erro ao consumir a controler Profile, rota GetProfileAsync " + ex.Message;
                this._logger.TraceException("GetProfileAsync");
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfileModel))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                ProfileRepository dal = new ProfileRepository(_logger);
                this._logger.Trace("GetByIdAsync");
                var ret = await dal.GetByIdAsync(id);
                return Ok(ret);
            }
            catch (ArgumentNullException ex)
            {
                string mensagem = "Erro ao consumir a controler Profile, rota GetByIdAsync " + ex.Message;
                this._logger.TraceException("GetByIdAsync");
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpPost(Name = "InsertProfileAsync")]
        public async Task Post(ProfileModel ProfileModel)
        {
            try
            {
                ProfileRepository dal = new ProfileRepository(_logger);
                this._logger.Trace("InsertAsync");
                await dal.InsertAsync(ProfileModel);
            }
            catch (ArgumentNullException ex)
            {
                string mensagem = "Erro ao consumir a controler Profile, rota InsertProfileAsync " + ex.Message;
                this._logger.TraceException("InsertAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpPut(Name = "UpdateProfileAsync")]
        public async Task Update(ProfileModel ProfileModel)
        {
            try
            {
                ProfileRepository dal = new ProfileRepository(_logger);
                this._logger.Trace("UpdateAsync");
                await dal.UpdateAsync(ProfileModel);
            }
            catch (ArgumentNullException ex)
            {
                string mensagem = "Erro ao consumir a controler Profile, rota UpdateProfileAsync " + ex.Message;
                this._logger.TraceException("UpdateAsync");
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            try
            {
                ProfileRepository dal = new ProfileRepository(_logger);
                this._logger.Trace("DeleteAsync");
                await dal.DeleteAsync(id);
            }
            catch (ArgumentNullException ex)
            {
                string mensagem = "Erro ao consumir a controler Profile, rota DeleteProfileAsync " + ex.Message;
                this._logger.TraceException("DeleteAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

    }
}
