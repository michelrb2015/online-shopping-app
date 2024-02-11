using OnlineShoppingApp.Domain.Repositories;
using OnlineShoppingApp.Domain.Aggregates;

namespace OnlineShoppingApp.Application.Commands.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> AddOrderAsync(OrderAggregate orderAggregate)
        {
            return await _orderRepository.AddAsync(orderAggregate);
        }
    }
}
