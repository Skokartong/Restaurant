using Restaurant.Models;

namespace Restaurant.Data.Repos.IRepos
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(Order order);
        Task UpdateOrderAsync(int orderId, Order updatedOrder);
        Task DeleteOrderAsync(int orderId);
        Task<Order> SearchOrderAsync(int orderId);
        Task<IEnumerable<Order>> SeeAllOrdersFromTableAsync(int tableId);
    }
}
