using OnlineShoppingApp.Domain.Aggregates;

namespace OnlineShoppingApp.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<OrderAggregate> GetByIdAsync(int orderId);
        Task<bool> AddAsync(OrderAggregate orderAggregate);
        Task UpdateAsync(OrderAggregate orderAggregate);
        Task DeleteAsync(int orderId);
    }
}
