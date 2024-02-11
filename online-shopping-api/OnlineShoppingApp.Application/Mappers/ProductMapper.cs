using OnlineShoppingApp.Application.Commands.Dtos;
using OnlineShoppingApp.Domain.Entities;
using OnlineShoppingApp.Domain.ValueObjects;

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
                Price = new Price(dto.Price, "USD"),
                Quantity = dto.Quantity
            };
        }
    }
}
