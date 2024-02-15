using OnlineShoppingApp.Domain.Entities;
using OnlineShoppingApp.Domain.Repositories;

namespace OnlineShoppingApp.API.Commands.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<bool> AddToCartAsync(int userId, int productId)
        {
            return await _cartRepository.AddToCartAsync(userId, productId);
        }
        public async Task<bool> RemoveFromCartAsync(int userId, int productId)
        {
            return await _cartRepository.RemoveFromCartAsync(userId, productId);
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsAsync(int userId)
        {
            var cartItems = await _cartRepository.GetCartItemsAsync(userId);
            return cartItems;
        }

        public async Task<IEnumerable<int>> GetProductIdsInCartAsync(int userId)
        {
            var cartItems = await _cartRepository.GetCartItemsAsync(userId);

            var productIds = cartItems.Select(ci => ci.ProductId);

            return productIds;
        }
    }
}
