using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure;

namespace WebApi.Donne.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Properties

        public readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        public UserController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUser")]
        public IEnumerable<UserModel> Get()
        {
            UserRepository dal = new UserRepository(_logger);
            var ret = dal.GetAllUsers();
            return (ret);
        }

        [HttpGet("{id:int}")]
        public UserModel Get(int id)
        {
            UserRepository dal = new UserRepository(_logger);
            var ret = dal.GetById(id);
            return (ret);
        }

        [HttpGet("{name}")]
        public UserModel Get(string name)
        {
            UserRepository dal = new UserRepository(_logger);
            var ret = dal.GetByName(name);
            return (ret);
        }

        [HttpPost(Name = "InsertUser")]
        public void Post(UserModel UserModel)
        {
            UserRepository dal = new UserRepository(_logger);
            dal.Insert(UserModel);
        }

        [HttpPut(Name = "UpdateUser")]
        public void Update(UserModel UserModel)
        {
            UserRepository dal = new UserRepository(_logger);
            dal.Update(UserModel);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            UserRepository dal = new UserRepository(_logger);
            dal.Delete(id);
        }
    }
}
