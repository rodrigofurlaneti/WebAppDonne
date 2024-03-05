using Domain.Donne;

namespace WebApi.Donne.Infrastructure.FormOfPayment
{
    public interface IFormOfPaymentRepository
    {
        IEnumerable<FormOfPaymentModel> GetAll();
        Task<IEnumerable<FormOfPaymentModel>> GetAllAsync();
        FormOfPaymentModel GetById(int id);
        Task<FormOfPaymentModel> GetByIdAsync(int id);
        void Insert(FormOfPaymentModel formOfPaymentModel);
        Task InsertAsync(FormOfPaymentModel formOfPaymentModel);
        void Delete(int formOfPaymentId);
        Task DeleteAsync(int formOfPaymentId);
        void Update(FormOfPaymentModel formOfPaymentModel);
        Task UpdateAsync(FormOfPaymentModel formOfPaymentModel);
    }
}
