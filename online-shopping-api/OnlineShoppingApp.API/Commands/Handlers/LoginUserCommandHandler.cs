using MediatR;
using OnlineShoppingApp.API.Commands.Services;
using OnlineShoppingApp.Domain.Entities;

namespace OnlineShoppingApp.API.Commands.Handlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, User?>
    {
        private readonly IUserService _userService;

        public LoginUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User?> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            return await _userService.LoginAsync(command.Username, command.Password);
        }
    }
}
