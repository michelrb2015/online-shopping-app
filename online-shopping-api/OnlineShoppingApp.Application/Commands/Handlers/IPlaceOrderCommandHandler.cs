namespace OnlineShoppingApp.Application.Commands.Handlers
{
    public interface IPlaceOrderCommandHandler
    {
        Task<bool> HandleAsync(PlaceOrderCommand command);
    }
}
