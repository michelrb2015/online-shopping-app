namespace OnlineShoppingApp.API.Commands.Handlers
{
    public interface IPlaceOrderCommandHandler
    {
        Task<bool> HandleAsync(PlaceOrderCommand command);
    }
}
