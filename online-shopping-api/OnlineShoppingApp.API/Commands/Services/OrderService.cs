using OnlineShoppingApp.Domain.Repositories;
using OnlineShoppingApp.Domain.Aggregates;

namespace OnlineShoppingApp.API.Commands.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;


        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> AddOrderAsync(int UserId, List<int> Products)
        {
            return await _orderRepository.AddAsync(UserId, Products);
        }
    }
}
