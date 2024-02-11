
namespace OnlineShoppingApp.Domain
{
    // Order Entity
    public class Order
    {
        public int UserId { get; private set; }
        public List<int> Products { get; private set; }

        public Order(int userId, List<int> products)
        {
            UserId = userId;
            Products = products;
        }
    }
}
