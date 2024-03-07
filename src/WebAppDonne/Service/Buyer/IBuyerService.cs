using Domain.Donne;

namespace WebApi.Donne.Service.Buyer
{
    public interface IBuyerService
    {
        public void UpdateCustomersNameInCommand(BuyerModel buyerModel);
        public Task UpdateCustomersNameInCommandAsync(BuyerModel buyerModel);
        public BuyerModel GetById(int buyerId);
        public Task<BuyerModel> GetByIdAsync(int buyerId);
        public void Update(BuyerModel buyerModel);
        public Task UpdateAsync(BuyerModel buyerModel);

    }
}
