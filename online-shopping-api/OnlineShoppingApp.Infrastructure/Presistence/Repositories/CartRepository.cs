using Microsoft.EntityFrameworkCore;
using OnlineShoppingApp.Domain.Entities;
using OnlineShoppingApp.Domain.Repositories;
using OnlineShoppingApp.Infrastructure.Presistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Infrastructure.Presistence.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddToCartAsync(int userId, int productId)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new CartItems { UserId = userId, Items = new List<CartItem>() };
                _context.Carts.Add(cart);
            }

            var existingItem = cart.Items.FirstOrDefault(item => item.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                var newItem = new CartItem { UserId = userId, ProductId = productId, Quantity = 1 };
                cart.Items.Add(newItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }

}
