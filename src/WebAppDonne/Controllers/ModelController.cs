using Domain.Donne;
using Microsoft.AspNetCore.Mvc;
using WebApi.Donne.Infrastructure;

namespace WebApi.Donne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModelController : ControllerBase
    {
        #region Properties

        private readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        public ModelController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            this._logger = logger;
        }

        [HttpGet(Name = "GetModelsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Model>))]
        public async Task<IActionResult> GetModelsAsync()
        {
            try
            {
                ModelRepository dal = new ModelRepository(_logger);
                var ret = await dal.GetAllModelsAsync();
                _logger.Trace("GetModelAsync");
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("GetModelAsync");
                string mensagem = "Erro ao consumir a controler Model, rota GetModels " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpOptions("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Model>))]
        public async Task<IActionResult> OptionsAsync(int id)
        {
            try
            {
                ModelRepository dal = new ModelRepository(_logger);
                _logger.Trace("OptionsAsync");
                var ret = await dal.GetByStatusAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("OptionsAsync");
                string mensagem = "Erro ao consumir a controler Model, rota OptionsAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Model>))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                ModelRepository dal = new ModelRepository(_logger);
                _logger.Trace("GetByIdAsync");
                var ret = await dal.GetByIdAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("GetByIdAsync");
                string mensagem = "Erro ao consumir a controler Model, rota GetByIdAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpPost(Name = "InsertModel")]
        public async Task Post(Model ModelModel)
        {
            try
            {
                ModelRepository dal = new ModelRepository(_logger);
                _logger.Trace("InsertAsync");
                await dal.InsertAsync(ModelModel);
            }
            catch (Exception ex)
            {
                _logger.TraceException("InsertAsync");
                string mensagem = "Erro ao consumir a controler Model, rota Post " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpPut(Name = "UpdateModel")]
        public async Task Update(Model ModelModel)
        {
            try
            {
                ModelRepository dal = new ModelRepository(_logger);
                _logger.Trace("UpdateAsync");
                await dal.UpdateAsync(ModelModel);
            }
            catch (Exception ex)
            {
                _logger.TraceException("UpdateAsync");
                string mensagem = "Erro ao consumir a controler Model, rota Update " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            try
            {
                _logger.Trace("DeleteAsync");
                ModelRepository dal = new ModelRepository(_logger);
                await dal.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.TraceException("DeleteAsync");
                string mensagem = "Erro ao consumir a controler Model, rota DeleteAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }
    }
}
