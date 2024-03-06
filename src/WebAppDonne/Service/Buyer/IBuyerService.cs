using Domain.Donne;

namespace WebApi.Donne.Service.Buyer
{
    public interface IBuyerService
    {
        public void UpdateCustomersNameInCommand(BuyerModel buyerModel);
        public Task UpdateCustomersNameInCommandAsync(BuyerModel buyerModel);
    }
}
