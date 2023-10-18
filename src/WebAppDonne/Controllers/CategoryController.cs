using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure;

namespace WebApi.Donne.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        #region Properties

        public readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        public CategoryController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCategory")]
        public IEnumerable<CategoryModel> Get()
        {
            CategoryRepository dal = new CategoryRepository(_logger);
            var ret = dal.GetAllCategorys();
            return (ret);
        }

        [HttpGet("{id:int}")]
        public CategoryModel Get(int id)
        {
            CategoryRepository dal = new CategoryRepository(_logger);
            var ret = dal.GetById(id);
            return (ret);
        }

        [HttpPost(Name = "InsertCategory")]
        public void Post(CategoryModel CategoryModel)
        {
            CategoryRepository dal = new CategoryRepository(_logger);
            dal.Insert(CategoryModel);
        }

        [HttpPut(Name = "UpdateCategory")]
        public void Update(CategoryModel CategoryModel)
        {
            CategoryRepository dal = new CategoryRepository(_logger);
            dal.Update(CategoryModel);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            CategoryRepository dal = new CategoryRepository(_logger);
            dal.Delete(id);
        }
    }
}
