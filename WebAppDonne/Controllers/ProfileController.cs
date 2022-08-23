using Microsoft.AspNetCore.Mvc;
using WebAppDonne.Dal;
using WebAppDonne.Models;

namespace WebAppDonne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(ILogger<ProfileController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProfile")]
        public IEnumerable<ProfileModel> Get()
        {
            ProfileRepository dal = new ProfileRepository();
            var ret = dal.GetAllProfiles();
            return (ret);
        }

        [HttpGet("{id:int}")]
        public ProfileModel Get(int id)
        {
            ProfileRepository dal = new ProfileRepository();
            var ret = dal.GetById(id);
            return (ret);
        }

        [HttpPost(Name = "InsertProfile")]
        public void Post(ProfileModel ProfileModel)
        {
            ProfileRepository dal = new ProfileRepository();
            dal.Insert(ProfileModel);
        }

        [HttpPut(Name = "UpdateProfile")]
        public void Update(ProfileModel ProfileModel)
        {
            ProfileRepository dal = new ProfileRepository();
            dal.Update(ProfileModel);
        }

        [HttpDelete(Name = "DeleteProfile")]
        public void Delete(ProfileModel ProfileModel)
        {
            ProfileRepository dal = new ProfileRepository();
            dal.Delete(ProfileModel.ProfileId);
        }

    }
}
