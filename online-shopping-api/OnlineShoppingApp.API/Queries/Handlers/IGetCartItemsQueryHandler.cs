using MediatR;
using OnlineShoppingApp.API.Commands;
using OnlineShoppingApp.API.Dtos;

namespace OnlineShoppingApp.API.Queries.Handlers
{
    public interface IGetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
    {
        Task<IEnumerable<ProductDto>> Handle(GetProductsQuery query);

    }
}
