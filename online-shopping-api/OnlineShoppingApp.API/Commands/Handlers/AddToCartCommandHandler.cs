
using MediatR;
using OnlineShoppingApp.API.Commands.Services;

namespace OnlineShoppingApp.API.Commands.Handlers
{
    public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, bool>
    {
        private readonly ICartService _cartService;

        public AddToCartCommandHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<bool> Handle(AddToCartCommand command, CancellationToken cancellationToken)
        {
            return await _cartService.AddToCartAsync(command.UserId, command.ProductId);
        }
    }
}
