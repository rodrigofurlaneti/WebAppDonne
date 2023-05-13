using Microsoft.AspNetCore.Mvc;
using WebAppDonne.Dal;
using WebAppDonne.Models;

namespace WebAppDonne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuyerCommandController : Controller
    {
        private readonly ILogger<BuyerController> _logger;

        public BuyerCommandController(ILogger<BuyerController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBuyerCommand")]
        public IEnumerable<BuyerModel> Get()
        {
            BuyerCommandRepository dal = new BuyerCommandRepository();
            var ret = dal.GetBuyerCommand();
            return (ret);
        }
    }
}
