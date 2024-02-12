using MediatR;
using OnlineShoppingApp.API.Commands.Services;

namespace OnlineShoppingApp.API.Commands.Handlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, bool>
    {
        private readonly IUserService _userService;

        public LoginUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            return await _userService.LoginAsync(command.Username, command.Password);
        }
    }
}
