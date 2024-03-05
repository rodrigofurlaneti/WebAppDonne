using Domain.Donne;

namespace WebApi.Donne.Infrastructure.Order
{
    public interface IOrderRepository
    {
        IEnumerable<OrderModel> GetAll();
        Task<IEnumerable<OrderModel>> GetAllAsync();
        OrderModel GetById(int id);
        Task<OrderModel> GetByIdAsync(int id);
        void Insert(OrderModel orderModel);
        Task InsertAsync(OrderModel orderModel);
        void Delete(int orderId);
        Task DeleteAsync(int orderId);
        void Update(OrderModel orderModel);
        Task UpdateAsync(OrderModel orderModel);
    }
}
