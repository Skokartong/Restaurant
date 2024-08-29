using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Repos.IRepos;
using Restaurant.Models;

namespace Restaurant.Data.Repos
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestaurantContext _context;

        public OrderRepository(RestaurantContext context)
        {
            _context = context;
        }

        public async Task AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Order> SearchOrderAsync(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.Menu)
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            return order;
        }

        public async Task<List<Order>> SeeAllOrdersFromTableAsync(int tableId)
        {
            var orders = await _context.Orders
                           .Where(o => o.FK_TableId == tableId)
                           .Include(o => o.Customer)
                           .Include(o => o.Menu)
                           .ToListAsync();

            return orders;
        }

        public async Task UpdateOrderAsync(int orderId, Order updatedOrder)
        {
            var order = await _context.Orders
                                      .Include(o => o.Menu)
                                      .Include(o => o.Customer)
                                      .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order != null)
            {
                order.Amount = updatedOrder.Amount;
                order.FK_TableId = updatedOrder.FK_TableId;

                if (order.FK_MenuId != updatedOrder.FK_MenuId)
                {
                    order.FK_MenuId = updatedOrder.FK_MenuId;
                    order.Menu = updatedOrder.Menu;
                }

                if (order.FK_CustomerId != updatedOrder.FK_CustomerId)
                {
                    order.FK_CustomerId = updatedOrder.FK_CustomerId;
                    order.Customer = updatedOrder.Customer;
                }

                _context.Orders.Update(order);
                await _context.SaveChangesAsync();
            }
        }

    }
}
