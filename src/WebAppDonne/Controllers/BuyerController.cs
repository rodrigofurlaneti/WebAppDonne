﻿using Microsoft.AspNetCore.Mvc;
using Domain.Donne;
using WebApi.Donne.Infrastructure;
using System.Threading.Tasks;

namespace WebApi.Donne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuyerController : ControllerBase
    {
        public BuyerController()
        {
        }

        [HttpGet(Name = "GetBuyers")]
        public IEnumerable<BuyerModel> GetBuyers()
        {
            try
            {
                BuyerRepository dal = new BuyerRepository();
                var ret = dal.GetAllBuyers();
                return (ret);
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler Buyer, rota GetBuyers " + ex.Message; 
                throw new Exception(mensagem);
            }

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
