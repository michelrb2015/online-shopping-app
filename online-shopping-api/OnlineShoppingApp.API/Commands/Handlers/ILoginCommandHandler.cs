using OnlineShoppingApp.Domain.Entities;

namespace OnlineShoppingApp.API.Commands.Handlers
{
    public interface ILoginUserCommandHandler
    {
        Task<User?> HandleAsync(LoginUserCommand command);
    }
}
