using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure.VehicleBrand;

namespace WebApi.Donne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleBrandController : ControllerBase
    {
        #region Properties

        private readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        public VehicleBrandController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            this._logger = logger;
        }

        [HttpGet(Name = "GetVehicleBrandsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VehicleBrandModel>))]
        public async Task<IActionResult> GetVehicleBrand()
        {
            try
            {
                VehicleBrandRepository dal = new VehicleBrandRepository(_logger);
                this._logger.Trace("VehicleBrand_GetAllAsync");
                var ret = await dal.GetAllAsync();
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("VehicleBrand_GetAllAsync");
                string mensagem = "Erro ao consumir a controler VehicleBrand, rota GetVehicleBrands " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VehicleBrandModel>))]
        public async Task<IActionResult> GetVehicleBrand(int id)
        {
            try
            {
                VehicleBrandRepository dal = new VehicleBrandRepository(_logger);
                _logger.Trace("VehicleBrand_GetByIdAsync");
                var ret = await dal.GetByIdAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("VehicleBrand_GetByIdAsync");
                string mensagem = "Erro ao consumir a controler VehicleBrand, rota GetByIdAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpPost(Name = "InsertBrand")]
        public async Task Post(VehicleBrandModel BrandModel)
        {
            try
            {
                VehicleBrandRepository dal = new VehicleBrandRepository(_logger);
                _logger.Trace("VehicleBrand_InsertAsync");
                await dal.InsertAsync(BrandModel);
            }
            catch (Exception ex)
            {
                _logger.TraceException("VehicleBrand_InsertAsync");
                string mensagem = "Erro ao consumir a controler VehicleBrand, rota Post " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpPut(Name = "UpdateBrand")]
        public async Task Update(VehicleBrandModel BrandModel)
        {
            try
            {
                VehicleBrandRepository dal = new VehicleBrandRepository(_logger);
                _logger.Trace("VehicleBrand_UpdateAsync");
                await dal.UpdateAsync(BrandModel);
            }
            catch (Exception ex)
            {
                _logger.TraceException("VehicleBrand_UpdateAsync");
                string mensagem = "Erro ao consumir a controler VehicleBrand, rota Update " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            try
            {
                _logger.Trace("VehicleBrand_DeleteAsync");
                VehicleBrandRepository dal = new VehicleBrandRepository(_logger);
                await dal.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.TraceException("VehicleBrand_DeleteAsync");
                string mensagem = "Erro ao consumir a controler VehicleBrand, rota DeleteAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }
    }
}
