using OnlineShoppingApp.Application.Commands.Services;

namespace OnlineShoppingApp.Application.Commands.Handlers
{
    public class RegisterUserCommandHandler : IRegisterUserCommandHandler
    {
        private readonly IUserService _userService;

        public RegisterUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> HandleAsync(RegisterUserCommand command)
        {
            return await _userService.RegisterUserAsync(command.Username, command.Email, command.Password);
        }
    }
}

