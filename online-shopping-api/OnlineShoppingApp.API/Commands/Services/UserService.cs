using OnlineShoppingApp.Domain.Entities;
using OnlineShoppingApp.Domain.Repositories;

namespace OnlineShoppingApp.API.Commands.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> LoginAsync(string username, string password)
        {
            return await _userRepository.LoginAsync(username, password);
        }

        public async Task<bool> RegisterUserAsync(string username, string email, string password)
        {
            return await _userRepository.RegisterUserAsync(username, email, password);
        }

    }
}
