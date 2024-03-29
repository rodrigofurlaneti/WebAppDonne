﻿using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure.Payment;

namespace WebApi.Donne.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        #region Properties

        public readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        public PaymentController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            this._logger = logger;
        }

        [HttpGet(Name = "GetPaymentAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PaymentModel>))]
        public async Task<IActionResult> GetPayment()
        {
            try
            {
                PaymentRepository dal = new PaymentRepository(_logger);
                this._logger.Trace("GetPaymentAsync");
                var ret = await dal.GetAllAsync();
                return Ok(ret);
            }
            catch (Exception ex)
            {
                this._logger.TraceException("GetPaymentAsync");
                string mensagem = "Erro ao consumir a controler Payments, rota GetAllPaymentsAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaymentModel))]
        public async Task<IActionResult> GetFormOfPayment(int id)
        {
            try
            {
                PaymentRepository dal = new PaymentRepository(_logger);
                this._logger.Trace("GetByIdAsync");
                var ret = await dal.GetByIdAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                this._logger.TraceException("GetByIdAsync");
                string mensagem = "Erro ao consumir a controler Payments, rota GetAllPaymentsAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpPost(Name = "InsertPayment")]
        public async Task Post(PaymentModel PaymentModel)
        {
            try
            {
                PaymentRepository dal = new PaymentRepository(_logger);
                this._logger.Trace("InsertAsync");
                await dal.InsertAsync(PaymentModel);

            }
            catch (Exception ex)
            {
                this._logger.TraceException("InsertAsync");
                string mensagem = "Erro ao inserir um novo pagamento, consumir a controler Payments, rota GetAllPaymentsAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpPut(Name = "UpdatePayment")]
        public async Task Update(PaymentModel PaymentModel)
        {
            try
            {
                PaymentRepository dal = new PaymentRepository(_logger);
                await dal.UpdateAsync(PaymentModel);
                _logger.Trace("UpdateAsync");
            }
            catch (Exception ex)
            {
                _logger.TraceException("InsertAsync");
                string mensagem = "Erro ao inserir um novo pagamento, consumir a controler Payments, rota GetAllPaymentsAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            try
            {
                PaymentRepository dal = new PaymentRepository(_logger);
                await dal.DeleteAsync(id);
                _logger.Trace("DeleteAsync");
            }
            catch (Exception ex)
            {
                _logger.TraceException("DeleteAsync");
                string mensagem = "Erro ao excluir um pagamento, consumir a controler Payments, rota GetAllPaymentsAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }
    }
}
