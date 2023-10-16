using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure;

namespace WebApi.Donne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {
        }

        [HttpGet(Name = "GetProduct")]
        public IEnumerable<ProductModel> Get()
        {
            ProductRepository dal = new ProductRepository();
            var ret = dal.GetAllProducts();
            return (ret);
        }

        [HttpGet("{id:int}")]
        public ProductModel Get(int id)
        {
            ProductRepository dal = new ProductRepository();
            var ret = dal.GetById(id);
            return (ret);
        }

        [HttpPost(Name = "InsertProduct")]
        public void Post(ProductModel productModel)
        {
            ProductRepository dal = new ProductRepository();
            dal.Insert(productModel);
        }

        [HttpPut(Name = "UpdateProduct")]
        public void Update(ProductModel productModel)
        {
            ProductRepository dal = new ProductRepository();
            dal.Update(productModel);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            ProductRepository dal = new ProductRepository();
            dal.Delete(id);
        }


    }
}
