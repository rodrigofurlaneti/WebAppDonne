using Microsoft.AspNetCore.Mvc;
using WebAppDonne.Dal;
using WebAppDonne.Models;

namespace WebAppDonne.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FormOfPaymentController : Controller
    {
        private readonly ILogger<FormOfPaymentController> _logger;

        public FormOfPaymentController(ILogger<FormOfPaymentController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetFormOfPayment")]
        public IEnumerable<FormOfPaymentModel> Get()
        {
            FormOfPaymentRepository dal = new FormOfPaymentRepository();
            var ret = dal.GetAllFormOfPayment();
            return (ret);
        }

        [HttpGet("{id:int}")]
        public FormOfPaymentModel Get(int id)
        {
            FormOfPaymentRepository dal = new FormOfPaymentRepository();
            var ret = dal.GetById(id);
            return (ret);
        }

        [HttpPost(Name = "InsertFormOfPayment")]
        public void Post(FormOfPaymentModel formOfPaymentModel)
        {
            FormOfPaymentRepository dal = new FormOfPaymentRepository();
            dal.Insert(formOfPaymentModel);
        }

        [HttpPut(Name = "UpdateFormOfPayment")]
        public void Update(FormOfPaymentModel FormOfPaymentModel)
        {
            FormOfPaymentRepository dal = new FormOfPaymentRepository();
            dal.Update(FormOfPaymentModel);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            FormOfPaymentRepository dal = new FormOfPaymentRepository();
            dal.Delete(id);
        }
    }
}
