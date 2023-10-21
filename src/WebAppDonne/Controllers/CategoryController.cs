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
        public async Task Post(CategoryModel CategoryModel)
        {
            try
            {
                CategoryRepository dal = new CategoryRepository(_logger);
                await dal.InsertAsync(CategoryModel);
                _logger.Trace("InsertAsync");
            }
            catch (Exception ex)
            {
                _logger.TraceException("InsertAsync");
                string mensagem = "Erro ao consumir a controler Category, rota Post " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpPut(Name = "UpdateCategory")]
        public async Task Update(CategoryModel CategoryModel)
        {
            try
            {
                CategoryRepository dal = new CategoryRepository(_logger);
                await dal.UpdateAsync(CategoryModel);
                _logger.Trace("UpdateAsync");
            }
            catch (Exception ex)
            {
                _logger.TraceException("UpdateAsync");
                string mensagem = "Erro ao consumir a controler Category, rota Update " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            try
            {
                CategoryRepository dal = new CategoryRepository(_logger);
                await dal.DeleteAsync(id);
                _logger.Trace("DeleteAsync");
            }
            catch (Exception ex)
            {
                _logger.TraceException("DeleteAsync");
                string mensagem = "Erro ao consumir a controler Category, rota Delete " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }
    }
}
