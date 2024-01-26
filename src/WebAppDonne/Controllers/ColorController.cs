using Domain.Donne;
using Microsoft.AspNetCore.Mvc;
using WebApi.Donne.Infrastructure;

namespace WebApi.Donne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColorController : ControllerBase
    {
        #region Properties

        private readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        public ColorController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            this._logger = logger;
        }

        [HttpGet(Name = "GetColorsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ColorModel>))]
        public async Task<IActionResult> GetColorsAsync()
        {
            try
            {
                ColorRepository dal = new ColorRepository(_logger);
                var ret = await dal.GetAllColorsAsync();
                _logger.Trace("GetColorAsync");
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("GetColorAsync");
                string mensagem = "Erro ao consumir a controler Color, rota GetColors " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpOptions("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ColorModel>))]
        public async Task<IActionResult> OptionsAsync(int id)
        {
            try
            {
                ColorRepository dal = new ColorRepository(_logger);
                _logger.Trace("OptionsAsync");
                var ret = await dal.GetByStatusAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("OptionsAsync");
                string mensagem = "Erro ao consumir a controler Color, rota OptionsAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ColorModel>))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                ColorRepository dal = new ColorRepository(_logger);
                _logger.Trace("GetByIdAsync");
                var ret = await dal.GetByIdAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("GetByIdAsync");
                string mensagem = "Erro ao consumir a controler Color, rota GetByIdAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpPost(Name = "InsertColor")]
        public async Task Post(ColorModel ColorModel)
        {
            try
            {
                ColorRepository dal = new ColorRepository(_logger);
                _logger.Trace("InsertAsync");
                await dal.InsertAsync(ColorModel);
            }
            catch (Exception ex)
            {
                _logger.TraceException("InsertAsync");
                string mensagem = "Erro ao consumir a controler Color, rota Post " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpPut(Name = "UpdateColor")]
        public async Task Update(ColorModel ColorModel)
        {
            try
            {
                ColorRepository dal = new ColorRepository(_logger);
                _logger.Trace("UpdateAsync");
                await dal.UpdateAsync(ColorModel);
            }
            catch (Exception ex)
            {
                _logger.TraceException("UpdateAsync");
                string mensagem = "Erro ao consumir a controler Color, rota Update " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            try
            {
                _logger.Trace("DeleteAsync");
                ColorRepository dal = new ColorRepository(_logger);
                await dal.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.TraceException("DeleteAsync");
                string mensagem = "Erro ao consumir a controler Color, rota DeleteAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }
    }
}