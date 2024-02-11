
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingApp.Domain.Entities
{
    // Order Entity
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
        public Order(int userId, List<int> products)
        {
            UserId = userId;
            OrderProducts = products.Select(productId => new OrderProduct { ProductId = productId }).ToList();
        }

        public Order() { }
    }
}
