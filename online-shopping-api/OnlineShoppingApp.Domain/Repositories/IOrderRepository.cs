using OnlineShoppingApp.Domain.Aggregates;

namespace OnlineShoppingApp.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<bool> AddAsync(int UserId, List<int> Products);
    }
}
