namespace OnlineShoppingApp.API.Commands.Handlers
{
    public interface ILoginUserCommandHandler
    {
        Task<bool> HandleAsync(LoginUserCommand command);
    }
}
