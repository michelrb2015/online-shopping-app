
using OnlineShoppingApp.Application.Commands.Services;

namespace OnlineShoppingApp.Application.Commands.Handlers
{
    public class AddToCartCommandHandler : IAddToCartCommandHandler
    {
        private readonly ICartService _cartService;

        public AddToCartCommandHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<bool> HandleAsync(AddToCartCommand command)
        {
            return await _cartService.AddToCartAsync(command.UserId, command.ProductId);
        }
    }
}
