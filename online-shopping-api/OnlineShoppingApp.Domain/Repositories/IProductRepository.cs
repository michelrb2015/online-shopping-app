using OnlineShoppingApp.Domain.Entities;

namespace OnlineShoppingApp.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int productId);
        Task<List<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
