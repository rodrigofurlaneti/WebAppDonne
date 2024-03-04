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
        public async Task<IActionResult> Get()
        {
            try
            {
                VehicleTypeRepository dal = new VehicleTypeRepository(_logger);
                var ret = await dal.GetAllVehicleTypesAsync();
                this._logger.Trace("VehicleType_GetAllAsync");
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("VehicleType_GetAllAsync");
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
                _logger.Trace("VehicleType_GetByIdAsync");
                var ret = await dal.GetByIdAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("VehicleType_GetByIdAsync");
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
                _logger.Trace("VehicleType_InsertAsync");
                await dal.InsertAsync(VehicleTypeModel);
            }
            catch (Exception ex)
            {
                _logger.TraceException("VehicleType_InsertAsync");
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
                this._logger.Trace("VehicleType_UpdateAsync");
                await dal.UpdateAsync(VehicleTypeModel);
            }
            catch (Exception ex)
            {
                this._logger.TraceException("VehicleType_UpdateAsync");
                string mensagem = "Erro ao consumir a controler VehicleType, rota Update " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            try
            {
                this._logger.Trace("VehicleType_DeleteAsync");
                VehicleTypeRepository dal = new VehicleTypeRepository(_logger);
                await dal.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                this._logger.TraceException("VehicleType_DeleteAsync");
                string mensagem = "Erro ao consumir a controler VehicleType, rota DeleteAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }
    }
}
