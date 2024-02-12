using Moq;
using OnlineShoppingApp.API.Commands.Services;
using OnlineShoppingApp.Domain.Repositories;


namespace OnlineShoppingApp.UnitTests.Tests.OnlineShoppingApp.API.Services
{
    public class OrderServiceTests
    {
        [Fact]
        public async Task AddOrderAsync_Success()
        {
            // Arrange
            var mockOrderRepository = new Mock<IOrderRepository>();
            var orderService = new OrderService(mockOrderRepository.Object);

            var userId = 1;
            var products = new List<int> { 123, 456, 789 };

            mockOrderRepository.Setup(x => x.AddAsync(userId, products))
                               .ReturnsAsync(true);

            // Act
            var result = await orderService.AddOrderAsync(userId, products);

            // Assert
            Assert.True(result);
        }
    }
}
