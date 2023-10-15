﻿using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure;

namespace WebApi.Donne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuyerController : ControllerBase
    {
        private readonly ILogger<BuyerController> _logger;
        public BuyerController(ILogger<BuyerController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBuyers")]
        public IEnumerable<BuyerModel> Get()
        {
            BuyerRepository dal = new BuyerRepository();
            var ret = dal.GetAllBuyers();
            return (ret);
        }

        [HttpOptions("{id:int}")]
        public IEnumerable<BuyerModel> Options(int id)
        {
            BuyerRepository dal = new BuyerRepository();
            var ret = dal.GetByStatus(id);
            return (ret);
        }

        [HttpGet("{id:int}")]
        public BuyerModel Get(int id)
        {
            BuyerRepository dal = new BuyerRepository();
            var ret = dal.GetById(id);
            return (ret);
        }

        [HttpPost(Name = "InsertBuyer")]
        public void Post(BuyerModel buyerModel)
        {
            BuyerRepository dal = new BuyerRepository();
            dal.Insert(buyerModel);
        }

        [HttpPut(Name = "UpdateBuyer")]
        public void Update(BuyerModel buyerModel)
        {
            BuyerRepository dal = new BuyerRepository();
            dal.Update(buyerModel);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            BuyerRepository dal = new BuyerRepository();
            dal.Delete(id);
        }
    }
}