namespace OnlineShoppingApp.Domain.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
        public Cart Cart { get; set; }
    }

    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ICollection<CartItem> Items { get; set; }

    }
}
