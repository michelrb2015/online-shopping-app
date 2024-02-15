using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using OnlineShoppingApp.Domain.Entities;
using OnlineShoppingApp.Infrastructure.Presistence.Contexts;
using System.Linq;

namespace OnlineShoppingApp.Infrastructure.Migrations
{
    public partial class SeedData
    {
        private readonly ApplicationDbContext _dbContext;

        public SeedData(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            SeedUsers();
            SeedProducts();
        }

        private void SeedUsers()
        {
            if (!_dbContext.Users.Any())
            {
                var users = new[]
                {
                    new User { Username = "admin", Email = "john@example.com", Password = "admin" },
                    new User { Username = "user", Email = "jane@example.com", Password = "user" }
                };
                _dbContext.Users.AddRange(users);
                _dbContext.SaveChanges();
            }
        }

        private void SeedProducts()
        {
            if (!_dbContext.Products.Any())
            {
                var products = new[]
                {
                    new Product { Name = "Laptop HP Pavilion", Description = "Laptop HP Pavilion 15.6'', Intel Core i5, 8GB RAM, 256GB SSD, Windows 10", Price = 799.99m},
                    new Product { Name = "Smartphone Samsung Galaxy S21", Description = "Smartphone Samsung Galaxy S21 5G, 128GB, Phantom Gray - Unlocked", Price = 999.99m },
                    new Product { Name = "Smartwatch Apple Watch Series 7", Description = "Smartwatch Apple Watch Series 7 GPS, 41mm Blue Aluminum Case", Price = 399.99m },
                    new Product { Name = "TV LG OLED C1", Description = "TV LG OLED C1 65'', 4K Smart OLED TV with AI ThinQ", Price = 999.99m },
                    new Product { Name = "Headphones Sony WH-1000XM4", Description = "Headphones Sony WH-1000XM4 Wireless Noise Cancelling Overhead Headphones - Black", Price = 349.99m },
                    new Product { Name = "Gaming Console PlayStation 5", Description = "Gaming Console PlayStation 5, 825GB SSD, White", Price = 499.99m },
                    new Product { Name = "Digital Camera Canon EOS Rebel T8i", Description = "Digital Camera Canon EOS Rebel T8i DSLR Camera with 18-55mm Lens", Price = 799.99m },
                    new Product { Name = "Tablet Apple iPad Pro", Description = "Tablet Apple iPad Pro 12.9-inch, Wi-Fi, 256GB - Space Gray", Price = 709.99m },
                    new Product { Name = "Wireless Router NETGEAR Nighthawk AX12", Description = "Wireless Router NETGEAR Nighthawk AX12 12-Stream Wi-Fi 6 Router (RAX200) - AX11000", Price = 299.99m },
                    new Product { Name = "Drone DJI Mavic Air 2", Description = "Drone DJI Mavic Air 2 Fly More Combo - Drone Quadcopter UAV with 48MP Camera 4K Video 8K Hyperlapse", Price = 999.99m }

                };
                _dbContext.Products.AddRange(products);
                _dbContext.SaveChanges();
            }
        }
    }
}
