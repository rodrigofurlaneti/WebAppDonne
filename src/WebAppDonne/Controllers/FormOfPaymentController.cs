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
                var ret = await dal.GetAllFormOfPaymentAsync();
                _logger.Trace("GetFormOfPaymentAsync");
                return Ok(ret);
            }
            catch (ArgumentNullException ex)
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
                var ret = await dal.GetByIdAsync(id);
                _logger.Trace("GetByIdAsync");
                return Ok(ret);
            }
            catch (ArgumentNullException ex)
            {
                _logger.TraceException("GetByIdAsync");
                string mensagem = "Erro ao consumir a controler FormOfPayment, rota GetByIdAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpPost(Name = "InsertFormOfPayment")]
        public void Post(FormOfPaymentModel formOfPaymentModel)
        {
            FormOfPaymentRepository dal = new FormOfPaymentRepository(_logger);
            dal.Insert(formOfPaymentModel);
        }

        [HttpPut(Name = "UpdateFormOfPayment")]
        public void Update(FormOfPaymentModel FormOfPaymentModel)
        {
            FormOfPaymentRepository dal = new FormOfPaymentRepository(_logger);
            dal.Update(FormOfPaymentModel);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            FormOfPaymentRepository dal = new FormOfPaymentRepository(_logger);
            dal.Delete(id);
        }
    }
}
