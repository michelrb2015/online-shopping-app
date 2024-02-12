using OnlineShoppingApp.Domain.Entities;
using OnlineShoppingApp.Domain.Repositories;

namespace OnlineShoppingApp.API.Commands.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }
    }
}
