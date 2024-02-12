using Moq;
using OnlineShoppingApp.Domain.Repositories;
using OnlineShoppingApp.Domain.Entities;
using OnlineShoppingApp.API.Commands.Services;

public class UserServiceTests
    {
        [Fact]
        public async Task RegisterUser_Success()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            var userService = new UserService(mockUserRepository.Object);

            var username = "testuser";
            var email = "test@example.com";
            var password = "password";

            mockUserRepository.Setup(x => x.RegisterUserAsync(username, email, password))
                              .ReturnsAsync(true);

            // Act
            var result = await userService.RegisterUserAsync(username, email, password);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Login_Success()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            var userService = new UserService(mockUserRepository.Object);

            var username = "testuser";
            var password = "password";

            var user = new User
            {
                Username = username,
                Password = password
            };

            mockUserRepository.Setup(x => x.LoginAsync(username, password))
                              .ReturnsAsync(user);

            // Act
            var result = await userService.LoginAsync(username, password);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(username, result.Username);
        }
    }

