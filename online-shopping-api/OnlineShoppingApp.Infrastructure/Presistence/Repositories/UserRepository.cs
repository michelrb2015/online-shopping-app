using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Infrastructure.Presistence.Repositories
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using OnlineShoppingApp.Domain.Entities;
    using OnlineShoppingApp.Domain.Repositories;
    using OnlineShoppingApp.Infrastructure.Presistence.Contexts;

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> RegisterUserAsync(string username, string email, string password)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == username || u.Email == email);
            if (existingUser != null)
                return false; 

            var newUser = new User
            {
                Username = username,
                Email = email,
                Password = password
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<User?> LoginAsync(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            return user; 
        }
    }

}
