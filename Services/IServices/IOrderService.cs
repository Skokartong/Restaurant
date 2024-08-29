using Restaurant.Models;
using Restaurant.Models.DTOs;

namespace Restaurant.Services.IServices
{
    public interface IOrderService
    {
        Task AddOrderAsync(OrderDTO orderDTO);
        Task UpdateOrderAsync(int orderId, OrderDTO updatedOrderDTO);
        Task DeleteOrderAsync(int orderId);
        Task<OrderDTO> SearchOrderAsync(int orderId);
        Task<List<OrderDTO>> SeeAllOrdersFromTableAsync(int tableId);
    }
}
