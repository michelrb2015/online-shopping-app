using OnlineShoppingApp.Domain.Aggregates;
using OnlineShoppingApp.Domain.Entities;
using OnlineShoppingApp.Domain.Repositories;
using OnlineShoppingApp.Infrastructure.Presistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Infrastructure.Presistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddAsync(OrderAggregate orderAggregate)
        {
            try
            {
                var order = orderAggregate.Order;
                var orderEntity = new Order
                {
                    UserId = order.UserId,
                };

                _dbContext.Orders.Add(orderEntity);

                await _dbContext.SaveChangesAsync();

                foreach (var product in orderAggregate.Products)
                {
                    var orderProduct = new OrderProduct
                    {
                        OrderId = orderEntity.Id,
                        ProductId = product.Id,
                    };

                    _dbContext.OrderProducts.Add(orderProduct);
                }

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }


}
