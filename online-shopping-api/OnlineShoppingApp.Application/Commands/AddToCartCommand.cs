namespace OnlineShoppingApp.Application.Commands
{
    public class AddToCartCommand
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
