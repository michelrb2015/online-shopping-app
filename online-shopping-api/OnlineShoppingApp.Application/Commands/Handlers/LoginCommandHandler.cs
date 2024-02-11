using OnlineShoppingApp.Application.Commands.Services;

namespace OnlineShoppingApp.Application.Commands.Handlers
{
    public class LoginCommandHandler : ILoginCommandHandler
    {
        private readonly IUserService _userService;

        public LoginCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> HandleAsync(LoginCommand command)
        {
            return await _userService.LoginAsync(command.Username, command.Password);
        }
    }
}
