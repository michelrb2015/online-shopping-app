using Moq;
using OnlineShoppingApp.API.Commands.Services;
using OnlineShoppingApp.Domain.Entities;
using OnlineShoppingApp.Domain.Repositories;

namespace OnlineShoppingApp.UnitTests.Tests.OnlineShoppingApp.API.Services
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task GetProductsAsync_Success()
        {
            // Arrange
            var mockProductRepository = new Mock<IProductRepository>();
            var productService = new ProductService(mockProductRepository.Object);

            var expectedProducts = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.99m },
            new Product { Id = 2, Name = "Product 2", Price = 20.49m }
        };

            mockProductRepository.Setup(x => x.GetAllAsync())
                                 .ReturnsAsync(expectedProducts);

            // Act
            var result = await productService.GetProductsAsync();

            // Assert
            Assert.Equal(expectedProducts, result);
        }
    }

}
