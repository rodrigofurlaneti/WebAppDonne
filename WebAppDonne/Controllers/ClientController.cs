using Microsoft.AspNetCore.Mvc;
using WebAppDonne.Dal;
using WebAppDonne.Models;

namespace WebAppDonne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetClient")]
        public IEnumerable<ClientModel> Get()
        {
            ClientRepository dal = new ClientRepository();
            var ret = dal.GetAllClients();
            return (ret);
        }

        [HttpGet("{id:int}")]
        public ClientModel Get(int id)
        {
            ClientRepository dal = new ClientRepository();
            var ret = dal.GetById(id);
            return (ret);
        }

        [HttpPost(Name = "InsertClient")]
        public void Post(ClientModel ClientModel)
        {
            ClientRepository dal = new ClientRepository();
            dal.Insert(ClientModel);
        }

        [HttpPut(Name = "UpdateClient")]
        public void Update(ClientModel ClientModel)
        {
            ClientRepository dal = new ClientRepository();
            dal.Update(ClientModel);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            ClientRepository dal = new ClientRepository();
            dal.Delete(id);
        }
    }
}
