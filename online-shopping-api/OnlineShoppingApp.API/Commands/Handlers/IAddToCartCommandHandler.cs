namespace OnlineShoppingApp.API.Commands.Handlers
{
    public interface IAddToCartCommandHandler
    {
        Task<bool> HandleAsync(AddToCartCommand command);
    }
}
