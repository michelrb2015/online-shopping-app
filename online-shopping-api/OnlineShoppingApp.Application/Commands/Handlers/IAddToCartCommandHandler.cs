namespace OnlineShoppingApp.Application.Commands.Handlers
{
    public interface IAddToCartCommandHandler
    {
        Task<bool> HandleAsync(AddToCartCommand command);
    }
}
