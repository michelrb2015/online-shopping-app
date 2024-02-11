using OnlineShoppingApp.Domain.Aggregates;

namespace OnlineShoppingApp.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<bool> AddAsync(OrderAggregate orderAggregate);
    }
}
