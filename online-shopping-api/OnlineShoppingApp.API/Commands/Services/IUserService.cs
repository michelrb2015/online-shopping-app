using OnlineShoppingApp.Domain.Entities;

namespace OnlineShoppingApp.API.Commands.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(string username, string email, string password);
        Task<User?> LoginAsync(string username, string password);
    }
}
