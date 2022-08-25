using Microsoft.AspNetCore.Mvc;
using WebAppDonne.Dal;
using WebAppDonne.Models;

namespace WebAppDonne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly ILogger<StoreController> _logger;

        public StoreController(ILogger<StoreController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetStore")]
        public IEnumerable<StoreModel> Get()
        {
            StoreRepository dal = new StoreRepository();
            var ret = dal.GetAllStores();
            return (ret);
        }

        [HttpGet("{id:int}")]
        public StoreModel Get(int id)
        {
            StoreRepository dal = new StoreRepository();
            var ret = dal.GetById(id);
            return (ret);
        }

        [HttpPost(Name = "InsertStore")]
        public void Post(StoreModel StoreModel)
        {
            StoreRepository dal = new StoreRepository();
            dal.Insert(StoreModel);
        }

        [HttpPut(Name = "UpdateStore")]
        public void Update(StoreModel StoreModel)
        {
            StoreRepository dal = new StoreRepository();
            dal.Update(StoreModel);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            StoreRepository dal = new StoreRepository();
            dal.Delete(id);
        }
    }
}
