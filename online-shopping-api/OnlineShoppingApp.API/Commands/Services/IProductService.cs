using OnlineShoppingApp.Domain.Entities;

namespace OnlineShoppingApp.API.Commands.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
    }
}
