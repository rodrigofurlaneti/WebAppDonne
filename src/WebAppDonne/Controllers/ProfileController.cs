using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure;

namespace WebApi.Donne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        #region Properties

        public readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        public ProfileController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProfile")]
        public IEnumerable<ProfileModel> Get()
        {
            ProfileRepository dal = new ProfileRepository(_logger);
            var ret = dal.GetAllProfiles();
            return (ret);
        }

        [HttpGet("{id:int}")]
        public ProfileModel Get(int id)
        {
            ProfileRepository dal = new ProfileRepository(_logger);
            var ret = dal.GetById(id);
            return (ret);
        }

        [HttpPost(Name = "InsertProfile")]
        public void Post(ProfileModel ProfileModel)
        {
            ProfileRepository dal = new ProfileRepository(_logger);
            dal.Insert(ProfileModel);
        }

        [HttpPut(Name = "UpdateProfile")]
        public void Update(ProfileModel ProfileModel)
        {
            ProfileRepository dal = new ProfileRepository(_logger);
            dal.Update(ProfileModel);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            ProfileRepository dal = new ProfileRepository(_logger);
            dal.Delete(id);
        }

    }
}
