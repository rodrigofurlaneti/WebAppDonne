using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure;

namespace WebApi.Donne.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        public PaymentController()
        {
        }

        [HttpGet(Name = "GetPayment")]
        public IEnumerable<PaymentModel> Get()
        {
            PaymentRepository dal = new PaymentRepository();
            var ret = dal.GetAllPayments();
            return (ret);
        }

        [HttpGet("{id:int}")]
        public PaymentModel Get(int id)
        {
            PaymentRepository dal = new PaymentRepository();
            var ret = dal.GetById(id);
            return (ret);
        }

        [HttpPost(Name = "InsertPayment")]
        public void Post(PaymentModel PaymentModel)
        {
            PaymentRepository dal = new PaymentRepository();
            dal.Insert(PaymentModel);
        }

        [HttpPut(Name = "UpdatePayment")]
        public void Update(PaymentModel PaymentModel)
        {
            PaymentRepository dal = new PaymentRepository();
            dal.Update(PaymentModel);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            PaymentRepository dal = new PaymentRepository();
            dal.Delete(id);
        }
    }
}
