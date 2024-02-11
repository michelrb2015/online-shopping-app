using OnlineShoppingApp.Application.Commands.Dtos;
using OnlineShoppingApp.Domain.Repositories;

namespace OnlineShoppingApp.Application.Queries.Handlers
{
    public class GetProductsQueryHandler : IGetProductsQueryHandler
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> HandleAsync(GetProductsQuery query)
        {
            var products = await _productRepository.GetAllAsync();

            var productDtos = new List<ProductDto>();
            foreach (var product in products)
            {
                productDtos.Add(new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = product.Quantity
                });
            }

            return productDtos;
        }
    }
}
