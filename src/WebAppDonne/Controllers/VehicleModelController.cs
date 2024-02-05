﻿using Domain.Donne;
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

        [HttpGet(Name = "GetModelsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VehicleModel>))]
        public async Task<IActionResult> GetModelsAsync()
        {
            try
            {
                ModelRepository dal = new ModelRepository(_logger);
                var ret = await dal.GetAllVehicleModelsAsync();
                _logger.Trace("GetModelAsync");
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("GetModelAsync");
                string mensagem = "Erro ao consumir a controler VehicleModel, rota GetModels " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VehicleModel>))]
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
                string mensagem = "Erro ao consumir a controler VehicleModel, rota GetByIdAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpPost(Name = "InsertModel")]
        public async Task Post(VehicleModel vehicleModel)
        {
            try
            {
                ModelRepository dal = new ModelRepository(_logger);
                _logger.Trace("InsertAsync");
                await dal.InsertAsync(vehicleModel);
            }
            catch (Exception ex)
            {
                _logger.TraceException("InsertAsync");
                string mensagem = "Erro ao consumir a controler VehicleModel, rota Post " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpPut(Name = "UpdateModel")]
        public async Task Update(VehicleModel vehicleModel)
        {
            try
            {
                ModelRepository dal = new ModelRepository(_logger);
                _logger.Trace("UpdateAsync");
                await dal.UpdateAsync(vehicleModel);
            }
            catch (Exception ex)
            {
                _logger.TraceException("UpdateAsync");
                string mensagem = "Erro ao consumir a controler VehicleModel, rota Update " + ex.Message;
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
                string mensagem = "Erro ao consumir a controler VehicleModel, rota DeleteAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }
    }
}