using Microsoft.AspNetCore.Mvc;
using WebAppDonne.Dal;
using WebAppDonne.Models;

namespace WebAppDonne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCategory")]
        public IEnumerable<CategoryModel> Get()
        {
            CategoryRepository dal = new CategoryRepository();
            var ret = dal.GetAllCategorys();
            return (ret);
        }

        [HttpGet("{id:int}")]
        public CategoryModel Get(int id)
        {
            CategoryRepository dal = new CategoryRepository();
            var ret = dal.GetById(id);
            return (ret);
        }

        [HttpPost(Name = "InsertCategory")]
        public void Post(CategoryModel CategoryModel)
        {
            CategoryRepository dal = new CategoryRepository();
            dal.Insert(CategoryModel);
        }

        [HttpPut(Name = "UpdateCategory")]
        public void Update(CategoryModel CategoryModel)
        {
            CategoryRepository dal = new CategoryRepository();
            dal.Update(CategoryModel);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            CategoryRepository dal = new CategoryRepository();
            dal.Delete(id);
        }
    }
}
