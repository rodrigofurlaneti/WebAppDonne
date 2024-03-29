﻿using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure.Product;

namespace WebApi.Donne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        #region Properties

        public readonly WebApi.Donne.Infrastructure.SeedWork.ILogger _logger;

        #endregion

        public ProductController(WebApi.Donne.Infrastructure.SeedWork.ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductModel>))]
        public async Task<IActionResult> GetProduct()
        {
            try
            {
                ProductRepository dal = new ProductRepository(_logger);
                this._logger.Trace("GetProductAsync");
                var ret = await dal.GetAllAsync();
                return Ok(ret);
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler Product, rota GetProductAsync " + ex.Message;
                this._logger.TraceException("GetProductAsync");
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductModel))]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                ProductRepository dal = new ProductRepository(_logger);
                var ret = await dal.GetByIdAsync(id);
                this._logger.Trace("GetByIdAsync");
                return Ok(ret);
            }
            catch (Exception ex)
            {
                this._logger.TraceException("GetByIdAsync");
                string mensagem = "Erro ao consumir a controler Product, rota GetByIdAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpPost(Name = "InsertProduct")]
        public async Task Post(ProductModel productModel)
        {
            try
            {
                ProductRepository dal = new ProductRepository(_logger);
                await dal.InsertAsync(productModel);
                this._logger.Trace("InsertProductAsync");
            }
            catch (Exception ex)
            {
                this._logger.TraceException("InsertProductAsync");
                string mensagem = "Erro ao consumir a controler Product, rota InsertProductAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpPut(Name = "UpdateProduct")]
        public async Task Update(ProductModel productModel)
        {
            try
            {
                ProductRepository dal = new ProductRepository(_logger);
                await dal.UpdateAsync(productModel);
                this._logger.Trace("UpdateProductAsync");
            }
            catch (Exception ex)
            {
                this._logger.TraceException("UpdateProductAsync");
                string mensagem = "Erro ao consumir a controler Product, rota UpdateProductAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            try
            {
                ProductRepository dal = new ProductRepository(_logger);
                this._logger.Trace("DeleteProductAsync");
                await dal.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                this._logger.TraceException("DeleteProductAsync");
                string mensagem = "Erro ao consumir a controler Product, rota DeleteProductAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }
    }
}
