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

        public async Task<bool> AddAsync(int userId, List<int> products)
        {
            try
            {
                var orderEntity = new Order
                {
                    UserId = userId,
                };

                _dbContext.Orders.Add(orderEntity);

                await _dbContext.SaveChangesAsync();

                foreach (var prodId in products)
                {
                    var orderProduct = new OrderProduct
                    {
                        OrderId = orderEntity.Id,
                        ProductId = prodId,
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
