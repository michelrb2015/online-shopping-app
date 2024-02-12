using MediatR;
using OnlineShoppingApp.API.Commands.Services;

namespace OnlineShoppingApp.API.Commands.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly IUserService _userService;

        public RegisterUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            return await _userService.RegisterUserAsync(command.Username, command.Email, command.Password);
        }
    }
}

