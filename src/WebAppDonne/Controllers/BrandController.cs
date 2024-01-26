using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure;

namespace WebApi.Donne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : ControllerBase
    {
        #region Properties

        private readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        public BrandController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            this._logger = logger;
        }

        [HttpGet(Name = "GetBrandsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BrandModel>))]
        public async Task<IActionResult> GetBrandsAsync()
        {
            try
            {
                BrandRepository dal = new BrandRepository(_logger);
                var ret = await dal.GetAllBrandsAsync();
                _logger.Trace("GetBrandAsync");
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("GetBrandAsync");
                string mensagem = "Erro ao consumir a controler Brand, rota GetBrands " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpOptions("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BrandModel>))]
        public async Task<IActionResult> OptionsAsync(int id)
        {
            try
            {
                BrandRepository dal = new BrandRepository(_logger);
                _logger.Trace("OptionsAsync");
                var ret = await dal.GetByStatusAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("OptionsAsync");
                string mensagem = "Erro ao consumir a controler Brand, rota OptionsAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BrandModel>))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                BrandRepository dal = new BrandRepository(_logger);
                _logger.Trace("GetByIdAsync");
                var ret = await dal.GetByIdAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("GetByIdAsync");
                string mensagem = "Erro ao consumir a controler Brand, rota GetByIdAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpPost(Name = "InsertBrand")]
        public async Task Post(BrandModel BrandModel)
        {
            try
            {
                BrandRepository dal = new BrandRepository(_logger);
                _logger.Trace("InsertAsync");
                await dal.InsertAsync(BrandModel);
            }
            catch (Exception ex)
            {
                _logger.TraceException("InsertAsync");
                string mensagem = "Erro ao consumir a controler Brand, rota Post " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpPut(Name = "UpdateBrand")]
        public async Task Update(BrandModel BrandModel)
        {
            try
            {
                BrandRepository dal = new BrandRepository(_logger);
                _logger.Trace("UpdateAsync");
                await dal.UpdateAsync(BrandModel);
            }
            catch (Exception ex)
            {
                _logger.TraceException("UpdateAsync");
                string mensagem = "Erro ao consumir a controler Brand, rota Update " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            try
            {
                _logger.Trace("DeleteAsync");
                BrandRepository dal = new BrandRepository(_logger);
                await dal.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.TraceException("DeleteAsync");
                string mensagem = "Erro ao consumir a controler Brand, rota DeleteAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }
    }
}
