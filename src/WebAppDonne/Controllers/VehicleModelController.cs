using Domain.Donne;
using Microsoft.AspNetCore.Mvc;
using WebApi.Donne.Infrastructure;

namespace WebApi.Donne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleModelController : ControllerBase
    {
        #region Properties

        private readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        public VehicleModelController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            this._logger = logger;
        }

        [HttpGet(Name = "GetVehicleModelsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VehicleModel>))]
        public async Task<IActionResult> GetVehicleModel()
        {
            try
            {
                this._logger.Trace("VehicleModel_GetAllAsync");
                VehicleModelRepository dal = new VehicleModelRepository(_logger);
                var ret = await dal.GetAllVehicleModelsAsync();
                return Ok(ret);
            }
            catch (ArgumentNullException ex)
            {
                this._logger.TraceException("VehicleModel_GetAllAsync");
                string mensagem = "Erro ao consumir a controler VehicleModel, rota GetModels " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VehicleModel>))]
        public async Task<IActionResult> GetVehicleModel(int id)
        {
            try
            {
                VehicleModelRepository dal = new VehicleModelRepository(_logger);
                _logger.Trace("VehicleModel_GetByIdAsync");
                var ret = await dal.GetByIdAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("VehicleModel_GetByIdAsync");
                string mensagem = "Erro ao consumir a controler VehicleModel, rota GetByIdAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpPost(Name = "InsertModel")]
        public async Task Post(VehicleModel vehicleModel)
        {
            try
            {
                VehicleModelRepository dal = new VehicleModelRepository(_logger);
                _logger.Trace("VehicleModel_InsertAsync");
                await dal.InsertAsync(vehicleModel);
            }
            catch (Exception ex)
            {
                _logger.TraceException("VehicleModel_InsertAsync");
                string mensagem = "Erro ao consumir a controler VehicleModel, rota Post " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpPut(Name = "UpdateModel")]
        public async Task Update(VehicleModel vehicleModel)
        {
            try
            {
                VehicleModelRepository dal = new VehicleModelRepository(_logger);
                _logger.Trace("VehicleModel_UpdateAsync");
                await dal.UpdateAsync(vehicleModel);
            }
            catch (Exception ex)
            {
                _logger.TraceException("VehicleModel_UpdateAsync");
                string mensagem = "Erro ao consumir a controler VehicleModel, rota Update " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            try
            {
                _logger.Trace("VehicleModel_DeleteAsync");
                VehicleModelRepository dal = new VehicleModelRepository(_logger);
                await dal.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.TraceException("VehicleModel_DeleteAsync");
                string mensagem = "Erro ao consumir a controler VehicleModel, rota DeleteAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }
    }
}
