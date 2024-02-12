using MediatR;
using OnlineShoppingApp.Domain.Entities;

namespace OnlineShoppingApp.API.Commands
{
    public class LoginUserCommand : IRequest<User?>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
