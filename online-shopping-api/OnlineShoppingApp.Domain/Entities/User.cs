namespace OnlineShoppingApp.Domain.Entities
{
    // User Entity
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public User()
        {
            CartItems = new List<CartItem>();
        }

    }
}
