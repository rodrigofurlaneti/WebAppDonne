using Domain.Donne;
using Microsoft.AspNetCore.Mvc;
using WebApi.Donne.Infrastructure;

namespace WebApi.Donne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        #region Properties

        private readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        public VehicleController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            this._logger = logger;
        }

        [HttpGet(Name = "GetVehiclesAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Vehicle>))]
        public async Task<IActionResult> Get()
        {
            try
            {
                VehicleRepository dal = new VehicleRepository(_logger);
                var ret = await dal.GetAllVehiclesAsync();
                _logger.Trace("Vehicle_GetAllAsync");
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("Vehicle_GetAllAsync");
                string mensagem = "Erro ao consumir a controler Vehicle, rota GetVehicles " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpOptions("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Vehicle>))]
        public async Task<IActionResult> OptionsAsync(int id)
        {
            try
            {
                VehicleRepository dal = new VehicleRepository(_logger);
                _logger.Trace("OptionsAsync");
                var ret = await dal.GetByParkedAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("OptionsAsync");
                string mensagem = "Erro ao consumir a controler Vehicle, rota OptionsAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Vehicle>))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                VehicleRepository dal = new VehicleRepository(_logger);
                _logger.Trace("Vehicle_GetByIdAsync");
                var ret = await dal.GetByIdAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("Vehicle_GetByIdAsync");
                string mensagem = "Erro ao consumir a controler Vehicle, rota GetByIdAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpPost(Name = "InsertVehicle")]
        public async Task Post(Vehicle VehicleModel)
        {
            try
            {
                VehicleRepository dal = new VehicleRepository(_logger);
                _logger.Trace("Vehicle_InsertAsync");
                await dal.InsertAsync(VehicleModel);
            }
            catch (Exception ex)
            {
                _logger.TraceException("Vehicle_InsertAsync");
                string mensagem = "Erro ao consumir a controler Vehicle, rota Post " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpPut(Name = "UpdateVehicle")]
        public async Task Update(Vehicle VehicleModel)
        {
            try
            {
                VehicleRepository dal = new VehicleRepository(_logger);
                _logger.Trace("Vehicle_UpdateAsync");
                await dal.UpdateAsync(VehicleModel);
            }
            catch (Exception ex)
            {
                _logger.TraceException("Vehicle_UpdateAsync");
                string mensagem = "Erro ao consumir a controler Vehicle, rota Update " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            try
            {
                this._logger.Trace("Vehicle_DeleteAsync");
                VehicleRepository dal = new VehicleRepository(_logger);
                await dal.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                this._logger.TraceException("Vehicle_DeleteAsync");
                string mensagem = "Erro ao consumir a controler Vehicle, rota DeleteAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }
    }
}
