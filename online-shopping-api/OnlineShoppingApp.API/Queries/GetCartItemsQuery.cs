using MediatR;
using OnlineShoppingApp.API.Dtos;

namespace OnlineShoppingApp.API.Queries
{
    public class GetCartItemsQuery : IRequest<IEnumerable<ProductDto>>
    {
        public int userId { get; set; }
    }
}
