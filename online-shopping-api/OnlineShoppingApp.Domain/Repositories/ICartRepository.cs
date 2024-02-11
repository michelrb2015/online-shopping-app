namespace OnlineShoppingApp.Domain.Repositories
{
    public interface ICartRepository
    {
        Task<bool> AddToCartAsync(int userId, int productId);
    }
}
