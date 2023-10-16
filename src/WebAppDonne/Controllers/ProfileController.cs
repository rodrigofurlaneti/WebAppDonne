using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure;

namespace WebApi.Donne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        public ProfileController()
        {
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

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            ProfileRepository dal = new ProfileRepository();
            dal.Delete(id);
        }

    }
}
