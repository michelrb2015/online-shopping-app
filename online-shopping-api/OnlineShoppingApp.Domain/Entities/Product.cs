
using OnlineShoppingApp.Domain.ValueObjects;

namespace OnlineShoppingApp.Domain.Entities
{
    // Product Entity
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Price Price { get; set; }
        public int Quantity { get; set; }
    }
}
