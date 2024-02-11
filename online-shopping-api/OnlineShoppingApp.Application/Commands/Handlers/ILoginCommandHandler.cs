namespace OnlineShoppingApp.Application.Commands.Handlers
{
    public interface ILoginCommandHandler
    {
        Task<bool> HandleAsync(LoginCommand command);
    }
}
