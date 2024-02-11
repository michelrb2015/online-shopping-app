using MediatR;
using OnlineShoppingApp.Application.Commands.Dtos;

namespace OnlineShoppingApp.Application.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
    }
}
