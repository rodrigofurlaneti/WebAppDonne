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
            this._logger = logger;
        }

        [HttpGet(Name = "GetCategoryAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoryModel>))]
        public async Task<IActionResult> Get()
        {
            try
            {
                CategoryRepository dal = new CategoryRepository(_logger);
                var ret = await dal.GetAllCategorysAsync();
                _logger.Trace("GetCategorysAsync");
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("GetCategorysAsync");
                string mensagem = "Erro ao consumir a controler Category, rota GetAllCategorysAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryModel))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                CategoryRepository dal = new CategoryRepository(_logger);
                var ret = await dal.GetByIdAsync(id);
                _logger.Trace("GetByIdAsync");
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.TraceException("GetByIdAsync");
                string mensagem = "Erro ao consumir a controler Category, rota GetAllCategorysAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

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
