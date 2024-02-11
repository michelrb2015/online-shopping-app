
using OnlineShoppingApp.Application.Commands.Dtos;

namespace OnlineShoppingApp.Application.Queries.Handlers
{
    public interface IGetProductsQueryHandler
    {
        Task<IEnumerable<ProductDto>> HandleAsync(GetProductsQuery query);

    }
}
