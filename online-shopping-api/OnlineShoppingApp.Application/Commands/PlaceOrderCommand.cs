namespace OnlineShoppingApp.Application.Commands
{
    public class PlaceOrderCommand
    {
        public int UserId { get; set; }
        public List<int> Products { get; set; }

        public PlaceOrderCommand(int userId, List<int> products)
        {
            UserId = userId;
            Products = products;
        }
    }
}
