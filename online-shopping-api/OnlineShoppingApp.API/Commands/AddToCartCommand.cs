using MediatR;

namespace OnlineShoppingApp.API.Commands
{
    public class AddToCartCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
