using Microsoft.AspNetCore.Mvc;
using WebAppDonne.Dal;
using WebAppDonne.Models;

namespace WebAppDonne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuyerStatusController : ControllerBase
    {
        private readonly ILogger<BuyerController> _logger;

        public BuyerStatusController(ILogger<BuyerController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id:int}")]
        public IEnumerable<BuyerModel> Get(int id)
        {
            BuyerStatusRepository dal = new BuyerStatusRepository();
            var ret = dal.GetStatus(id);
            return (ret);
        }
    }
}
