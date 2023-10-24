using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure;

namespace WebApi.Donne.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FormOfPaymentController : Controller
    {
        #region Properties

        public readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        public FormOfPaymentController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetFormOfPaymentAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<FormOfPaymentModel>))]
        public async Task<IActionResult> Get()
        {
            try
            {
                FormOfPaymentRepository dal = new FormOfPaymentRepository(_logger);
                _logger.Trace("GetFormOfPaymentAsync");
                var ret = await dal.GetAllFormOfPaymentAsync();
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("GetFormOfPaymentAsync");
                string mensagem = "Erro ao consumir a controler FormOfPayment, rota GetFormOfPaymentAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FormOfPaymentModel))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                FormOfPaymentRepository dal = new FormOfPaymentRepository(_logger);
                _logger.Trace("GetByIdAsync");
                var ret = await dal.GetByIdAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("GetByIdAsync");
                string mensagem = "Erro ao consumir a controler FormOfPayment, rota GetByIdAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpPost(Name = "InsertFormOfPaymentAsync")]
        public async Task Post(FormOfPaymentModel formOfPaymentModel)
        {
            try
            {
                FormOfPaymentRepository dal = new FormOfPaymentRepository(_logger);
                await dal.InsertAsync(formOfPaymentModel);
                _logger.Trace("InsertFormOfPaymentAsync");
            }
            catch (Exception ex)
            {
                _logger.TraceException("InsertFormOfPaymentAsync");
                string mensagem = "Erro ao consumir a controler FormOfPayment, rota InsertFormOfPaymentAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpPut(Name = "UpdateFormOfPayment")]
        public async Task Update(FormOfPaymentModel FormOfPaymentModel)
        {
            try
            {
                FormOfPaymentRepository dal = new FormOfPaymentRepository(_logger);
                await dal.UpdateAsync(FormOfPaymentModel);
                _logger.Trace("UpdateFormOfPaymentAsync");
            }
            catch (Exception ex)
            {
                _logger.TraceException("UpdateFormOfPaymentAsync");
                string mensagem = "Erro ao consumir a controler FormOfPayment, rota UpdateFormOfPaymentAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            try
            {
                FormOfPaymentRepository dal = new FormOfPaymentRepository(_logger);
                await dal.DeleteAsync(id);
                _logger.Trace("DeleteFormOfPaymentAsync");
            }
            catch (Exception ex)
            {
                _logger.TraceException("DeleteFormOfPaymentAsync");
                string mensagem = "Erro ao consumir a controler FormOfPayment, rota DeleteFormOfPaymentAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }
    }
}
