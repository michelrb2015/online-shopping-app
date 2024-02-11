using OnlineShoppingApp.Domain.Entities;

namespace OnlineShoppingApp.Application.Commands.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(string username, string email, string password);
        Task<bool> LoginAsync(string username, string password);
    }
}
