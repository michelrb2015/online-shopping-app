using OnlineShoppingApp.Domain.Entities;

namespace OnlineShoppingApp.Application.Commands.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
    }
}
