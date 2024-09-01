using Restaurant.Models;
using Restaurant.Models.DTOs;

namespace Restaurant.Services.IServices
{
    public interface IOrderMenuService
    {
        Task AddOrderAsync(OrderDTO orderDTO);
        Task UpdateOrderAsync(int orderId, OrderDTO updatedOrderDTO);
        Task DeleteOrderAsync(int orderId);
        Task<OrderDTO> SearchOrderAsync(int orderId);
        Task<List<OrderDTO>> SeeAllOrdersFromTableAsync(int tableId);
        Task<List<MenuDTO>> SeeMenuAsync(int restaurantId);
        Task<MenuDTO> GetAvailableMenuItemAsync(int menuId);
        Task AddDishOrDrinkAsync(MenuDTO menuItem);
        Task DeleteDishOrDrinkAsync(int menuId);
        Task UpdateDishOrDrinkAsync(int menuId, MenuDTO menuItem);
    }
}
