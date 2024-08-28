using Restaurant.Models;

namespace Restaurant.Data.Repos.IRepos
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(int orderId, Order updatedOrder);
        Task DeleteOrderAsync(int orderId);
        Task SearchOrder(int orderId);
    }
}
