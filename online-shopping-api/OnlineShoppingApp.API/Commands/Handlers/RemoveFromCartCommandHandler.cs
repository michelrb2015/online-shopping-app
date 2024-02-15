
using MediatR;
using OnlineShoppingApp.API.Commands.Services;

namespace OnlineShoppingApp.API.Commands.Handlers
{
    public class RemoveFromCartCommandHandler : IRequestHandler<RemoveFromCartCommand, bool>
    {
        private readonly ICartService _cartService;

        public RemoveFromCartCommandHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<bool> Handle(RemoveFromCartCommand command, CancellationToken cancellationToken)
        {
            return await _cartService.RemoveFromCartAsync(command.UserId, command.ProductId);
        }
    }
}
