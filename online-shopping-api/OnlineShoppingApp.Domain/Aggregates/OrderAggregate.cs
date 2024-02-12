
using OnlineShoppingApp.Domain.Entities;

namespace OnlineShoppingApp.Domain.Aggregates
{
    // Order Aggregate
    public class OrderAggregate
    {
        public Order Order { get; }

        private readonly List<Product> _products = new List<Product>();

        public IReadOnlyList<Product> Products => _products;

        public OrderAggregate(Order order)
        {
            Order = order;
        }


        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
    }
}
