using OnlineShoppingApp.Domain;
using OnlineShoppingApp.Domain.Aggregates;

namespace OnlineShoppingApp.Application.Commands.Services
{
    public interface IOrderService
    {
        Task<bool> AddOrderAsync(OrderAggregate orderAggregate);
    }
}
