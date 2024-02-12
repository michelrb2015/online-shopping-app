using Moq;
using OnlineShoppingApp.API.Commands.Services;
using OnlineShoppingApp.Domain.Entities;
using OnlineShoppingApp.Domain.Repositories;

namespace OnlineShoppingApp.UnitTests.Tests.OnlineShoppingApp.API.Services
{
    public class CartServiceTests
    {
        [Fact]
        public async Task AddToCartAsync_Success()
        {
            // Arrange
            var mockCartRepository = new Mock<ICartRepository>();
            var cartService = new CartService(mockCartRepository.Object);

            var userId = 1;
            var productId = 123;

            mockCartRepository.Setup(x => x.AddToCartAsync(userId, productId))
                              .ReturnsAsync(true);

            // Act
            var result = await cartService.AddToCartAsync(userId, productId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetCartItemsAsync_Success()
        {
            // Arrange
            var mockCartRepository = new Mock<ICartRepository>();
            var cartService = new CartService(mockCartRepository.Object);

            var userId = 1;
            var expectedCartItems = new List<CartItem>
        {
            new CartItem { UserId = userId, ProductId = 123, Quantity = 2 },
            new CartItem { UserId = userId, ProductId = 456, Quantity = 1 }
        };

            mockCartRepository.Setup(x => x.GetCartItemsAsync(userId))
                              .ReturnsAsync(expectedCartItems);

            // Act
            var result = await cartService.GetCartItemsAsync(userId);

            // Assert
            Assert.Equal(expectedCartItems, result);
        }

        [Fact]
        public async Task GetProductIdsInCartAsync_Success()
        {
            // Arrange
            var mockCartRepository = new Mock<ICartRepository>();
            var cartService = new CartService(mockCartRepository.Object);

            var userId = 1;
            var expectedProductIds = new List<int> { 123, 456 };

            var cartItems = expectedProductIds.Select(productId => new CartItem { UserId = userId, ProductId = productId, Quantity = 1 });

            mockCartRepository.Setup(x => x.GetCartItemsAsync(userId))
                              .ReturnsAsync(cartItems);

            // Act
            var result = await cartService.GetProductIdsInCartAsync(userId);

            // Assert
            Assert.Equal(expectedProductIds, result);
        }
    }

}
