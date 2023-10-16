using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure;

namespace WebApi.Donne.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FormOfPaymentController : Controller
    {
        public FormOfPaymentController()
        {
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
