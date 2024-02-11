using OnlineShoppingApp.Application.Commands.Services;
using OnlineShoppingApp.Domain.Aggregates;
using OnlineShoppingApp.Domain.Entities;

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
            var orderAggregate = OrderAggregate.CreateFromOrder(order);
            return await _orderService.AddOrderAsync(orderAggregate);
        }
    }
}
