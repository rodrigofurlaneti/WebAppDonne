using Domain.Donne;
using Microsoft.AspNetCore.Mvc;
using WebApi.Donne.Infrastructure;

namespace WebApi.Donne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleTypeController : ControllerBase
    {
        #region Properties

        private readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        public VehicleTypeController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            this._logger = logger;
        }

        [HttpGet(Name = "GetVehicleTypesAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VehicleTypeModel>))]
        public async Task<IActionResult> GetVehicleTypesAsync()
        {
            try
            {
                VehicleTypeRepository dal = new VehicleTypeRepository(_logger);
                var ret = await dal.GetAllVehicleTypesAsync();
                _logger.Trace("GetVehicleTypeAsync");
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("GetVehicleTypeAsync");
                string mensagem = "Erro ao consumir a controler VehicleType, rota GetVehicleTypes " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VehicleTypeModel>))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                VehicleTypeRepository dal = new VehicleTypeRepository(_logger);
                _logger.Trace("GetByIdAsync");
                var ret = await dal.GetByIdAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("GetByIdAsync");
                string mensagem = "Erro ao consumir a controler VehicleType, rota GetByIdAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpPost(Name = "InsertVehicleType")]
        public async Task Post(VehicleTypeModel VehicleTypeModel)
        {
            try
            {
                VehicleTypeRepository dal = new VehicleTypeRepository(_logger);
                _logger.Trace("InsertAsync");
                await dal.InsertAsync(VehicleTypeModel);
            }
            catch (Exception ex)
            {
                _logger.TraceException("InsertAsync");
                string mensagem = "Erro ao consumir a controler VehicleType, rota Post " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpPut(Name = "UpdateVehicleType")]
        public async Task Update(VehicleTypeModel VehicleTypeModel)
        {
            try
            {
                VehicleTypeRepository dal = new VehicleTypeRepository(_logger);
                _logger.Trace("UpdateAsync");
                await dal.UpdateAsync(VehicleTypeModel);
            }
            catch (Exception ex)
            {
                _logger.TraceException("UpdateAsync");
                string mensagem = "Erro ao consumir a controler VehicleType, rota Update " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            try
            {
                _logger.Trace("DeleteAsync");
                VehicleTypeRepository dal = new VehicleTypeRepository(_logger);
                await dal.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.TraceException("DeleteAsync");
                string mensagem = "Erro ao consumir a controler VehicleType, rota DeleteAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }
    }
}
