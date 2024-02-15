namespace OnlineShoppingApp.API.Commands.Handlers
{
    public interface IRemoveFromCartCommandHandler
    {
        Task<bool> HandleAsync(RemoveFromCartCommand command);
    }
}
