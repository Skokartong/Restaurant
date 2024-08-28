using Restaurant.Data.Repos.IRepos;
using Restaurant.Models;

namespace Restaurant.Data.Repos
{
    public class OrderRepository:IOrderRepository
    {
        private readonly RestaurantContext _context;

        public OrderRepository(RestaurantContext context)
        {
            _context = context;
        }

        public async Task AddOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public async Task SearchOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> UpdateOrderAsync(int orderId, Order updatedOrder)
        {
            throw new NotImplementedException();
        }
    }
}
