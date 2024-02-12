using MediatR;

namespace OnlineShoppingApp.API.Commands
{
    public class PlaceOrderCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public List<int> Products { get; set; }

    }
}
