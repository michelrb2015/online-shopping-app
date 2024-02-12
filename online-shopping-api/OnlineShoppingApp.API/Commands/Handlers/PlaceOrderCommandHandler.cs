using MediatR;
using OnlineShoppingApp.API.Commands.Services;
using OnlineShoppingApp.Domain.Aggregates;
using OnlineShoppingApp.Domain.Entities;

namespace OnlineShoppingApp.API.Commands.Handlers
{
    public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, bool>
    {
        private readonly IOrderService _orderService;

        public PlaceOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<bool> Handle(PlaceOrderCommand command, CancellationToken cancellationToken)
        {
            //var order = new Order(command.UserId, command.Products);
            //var orderAggregate = OrderAggregate.CreateFromOrder(order);
            return await _orderService.AddOrderAsync(command.UserId, command.Products);
        }
    }
}
