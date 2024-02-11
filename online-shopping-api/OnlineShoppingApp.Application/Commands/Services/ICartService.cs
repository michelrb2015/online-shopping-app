namespace OnlineShoppingApp.Application.Commands.Services
{
    public interface ICartService
    {
        Task<bool> AddToCartAsync(int userId, int productId);
    }
}
