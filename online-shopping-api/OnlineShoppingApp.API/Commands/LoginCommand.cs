using MediatR;

namespace OnlineShoppingApp.API.Commands
{
    public class LoginUserCommand : IRequest<bool>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
