using OnlineShoppingApp.Domain.Entities;

namespace OnlineShoppingApp.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int userId);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
        Task<bool> RegisterUserAsync(string username, string email, string password);
        Task<User?> LoginAsync(string username, string password);
    }
}
