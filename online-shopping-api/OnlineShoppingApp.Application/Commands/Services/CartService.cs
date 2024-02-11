using OnlineShoppingApp.Domain.Repositories;

namespace OnlineShoppingApp.Application.Commands.Services
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

    }
}
