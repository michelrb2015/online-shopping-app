using OnlineShoppingApp.Domain;
using OnlineShoppingApp.Domain.Aggregates;

namespace OnlineShoppingApp.API.Commands.Services
{
    public interface IOrderService
    {
        Task<bool> AddOrderAsync(int UserId, List<int> Products);
    }
}
