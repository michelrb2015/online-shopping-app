using MediatR;
using OnlineShoppingApp.API.Dtos;

namespace OnlineShoppingApp.API.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
    }
}
