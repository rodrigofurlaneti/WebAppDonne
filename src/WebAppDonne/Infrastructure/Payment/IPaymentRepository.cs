using Domain.Donne;

namespace WebApi.Donne.Infrastructure.Payment
{
    public interface IPaymentRepository
    {
        IEnumerable<PaymentModel> GetAll();
        Task<IEnumerable<PaymentModel>> GetAllAsync();
        PaymentModel GetById(int id);
        Task<PaymentModel> GetByIdAsync(int id);
        void Insert(PaymentModel paymentModel);
        Task InsertAsync(PaymentModel paymentModel);
        void Delete(int paymentId);
        Task DeleteAsync(int paymentId);
        void Update(PaymentModel paymentModel);
        Task UpdateAsync(PaymentModel paymentModel);
    }
}
