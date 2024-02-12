using MediatR;
using OnlineShoppingApp.API.Commands;
using OnlineShoppingApp.API.Dtos;

namespace OnlineShoppingApp.API.Queries.Handlers
{
    public interface IGetCartItemsQueryHandler : IRequestHandler<GetCartItemsQuery, IEnumerable<ProductDto>>
    {
        Task<IEnumerable<ProductDto>> Handle(GetCartItemsQuery query);

    }
}
