using OnlineShoppingApp.Application.Commands.Dtos;
using OnlineShoppingApp.Domain.Entities;

namespace OnlineShoppingApp.Application.Mappers
{
    public static class UserMapper
    {
        public static User MapToEntity(RegisterUserCommandDto dto)
        {
            return new User
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = dto.Password
            };
        }
    }
}
