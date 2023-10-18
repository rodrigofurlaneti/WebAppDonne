using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure;

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
            _logger = logger;
        }

        [HttpGet(Name = "GetPayment")]
        public IEnumerable<PaymentModel> Get()
        {
            PaymentRepository dal = new PaymentRepository(_logger);
            var ret = dal.GetAllPayments();
            return (ret);
        }

        [HttpGet("{id:int}")]
        public PaymentModel Get(int id)
        {
            PaymentRepository dal = new PaymentRepository(_logger);
            var ret = dal.GetById(id);
            return (ret);
        }

        [HttpPost(Name = "InsertPayment")]
        public void Post(PaymentModel PaymentModel)
        {
            PaymentRepository dal = new PaymentRepository(_logger);
            dal.Insert(PaymentModel);
        }

        [HttpPut(Name = "UpdatePayment")]
        public void Update(PaymentModel PaymentModel)
        {
            PaymentRepository dal = new PaymentRepository(_logger);
            dal.Update(PaymentModel);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            PaymentRepository dal = new PaymentRepository(_logger);
            dal.Delete(id);
        }
    }
}
