using MediatR;
using OnlineShoppingApp.API.Dtos;
using OnlineShoppingApp.Domain.Repositories;

namespace OnlineShoppingApp.API.Queries.Handlers
{
    public class GetCartItemsQueryHandler : IRequestHandler<GetCartItemsQuery, IEnumerable<ProductDto>>
    {
        private readonly ICartRepository _cartRepository;

        public GetCartItemsQueryHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetCartItemsQuery query, CancellationToken cancellationToken)
        {
            var products = await _cartRepository.GetCartItemsAsync(query.userId);

            var productDtos = new List<ProductDto>();
            foreach (var product in products)
            {
                productDtos.Add(new ProductDto
                {
                    Id = product.ProductId,
                    Name = product.Product.Name,
                    Description = product.Product.Description,
                    Price = product.Product.Price,
                    Quantity = product.Quantity
                });
            }

            return productDtos;
        }
    }
}
