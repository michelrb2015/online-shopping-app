using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingApp.Domain.Entities
{
    // Product Entity
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
