using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure.CompanyAsset;

namespace WebApi.Donne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyAssetController : ControllerBase
    {
        #region Properties

        private readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        #region Constructor

        public CompanyAssetController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            this._logger = logger;
        }

        #endregion

        #region Methods

        [HttpGet(Name = "GetCompanyAssetAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CompanyAssetModel>))]
        public async Task<IActionResult> GetCompanyAsset()
        {
            try
            {
                _logger.Trace("GetCompanyAssetAsync");
                CompanyAssetRepository dal = new CompanyAssetRepository(_logger);
                var ret = await dal.GetAllAsync();
                return Ok(ret);
            }
            catch (ArgumentException ex)
            {
                _logger.TraceException("GetCompanyAssetAsync");
                string mensagem = "Erro ao consumir a controler CompanyAsset, rota GetCompanyAssets " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CompanyAssetModel>))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                CompanyAssetRepository dal = new CompanyAssetRepository(_logger);
                _logger.Trace("GetByIdAsync");
                var ret = await dal.GetByIdAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("GetByIdAsync");
                string mensagem = "Erro ao consumir a controler CompanyAsset, rota GetByIdAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpPost(Name = "InsertCompanyAsset")]
        public async Task Post(CompanyAssetModel companyAssetModel)
        {
            try
            {
                CompanyAssetRepository dal = new CompanyAssetRepository(_logger);
                _logger.Trace("InsertAsync");
                await dal.InsertAsync(companyAssetModel);
            }
            catch (Exception ex)
            {
                _logger.TraceException("InsertAsync");
                string mensagem = "Erro ao consumir a controler CompanyAsset, rota Post " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpPut(Name = "UpdateCompanyAsset")]
        public async Task Update(CompanyAssetModel companyAssetModel)
        {
            try
            {
                CompanyAssetRepository dal = new CompanyAssetRepository(_logger);
                _logger.Trace("UpdateAsync");
                await dal.UpdateAsync(companyAssetModel);
            }
            catch (Exception ex)
            {
                _logger.TraceException("UpdateAsync");
                string mensagem = "Erro ao consumir a controler CompanyAsset, rota Update " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            try
            {
                _logger.Trace("DeleteAsync");
                CompanyAssetRepository dal = new CompanyAssetRepository(_logger);
                await dal.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.TraceException("DeleteAsync");
                string mensagem = "Erro ao consumir a controler CompanyAsset, rota DeleteAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        #endregion
    }
}
