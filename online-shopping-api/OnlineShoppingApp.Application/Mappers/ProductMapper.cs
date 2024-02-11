using OnlineShoppingApp.Application.Commands.Dtos;
using OnlineShoppingApp.Domain.Entities;

namespace OnlineShoppingApp.Application.Mappers
{
    public static class ProductMapper
    {
        public static Product MapToEntity(ProductDto dto)
        {
            return new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Quantity = dto.Quantity
            };
        }
    }
}
