using OnlineShoppingApp.Domain.Repositories;

namespace OnlineShoppingApp.Application.Commands.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            return await _userRepository.LoginAsync(username, password);
        }

        public async Task<bool> RegisterUserAsync(string username, string email, string password)
        {
            return await _userRepository.RegisterUserAsync(username, email, password);
        }

    }
}
