using OnlineShoppingApp.Domain.Entities;

namespace OnlineShoppingApp.Domain.Repositories
{
    public interface ICartRepository
    {
        Task<bool> AddToCartAsync(int userId, int productId);
        Task<bool> RemoveFromCartAsync(int userId, int productId);
        Task<IEnumerable<CartItem>> GetCartItemsAsync(int userId);

    }
}
