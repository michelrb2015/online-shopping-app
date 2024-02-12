using OnlineShoppingApp.Domain.Entities;

namespace OnlineShoppingApp.API.Commands.Services
{
    public interface ICartService
    {
        Task<bool> AddToCartAsync(int userId, int productId);
        Task<IEnumerable<int>> GetProductIdsInCartAsync(int userId);
        Task<IEnumerable<CartItem>> GetCartItemsAsync(int userId);

    }
}
