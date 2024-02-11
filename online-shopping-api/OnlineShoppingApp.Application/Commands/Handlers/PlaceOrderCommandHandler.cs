using OnlineShoppingApp.Application.Commands.Services;
using OnlineShoppingApp.Domain;
using OnlineShoppingApp.Domain.Aggregates;

namespace OnlineShoppingApp.Application.Commands.Handlers
{
    public class PlaceOrderCommandHandler : IPlaceOrderCommandHandler
    {
        private readonly IOrderService _orderService;

        public PlaceOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<bool> HandleAsync(PlaceOrderCommand command)
        {
            var order = new Order(command.UserId, command.Products);
            var orderAggregate = new OrderAggregate(order);
            return await _orderService.AddOrderAsync(orderAggregate);
        }
    }
}
