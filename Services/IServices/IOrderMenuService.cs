using Restaurant.Models;
using Restaurant.Models.DTOs.MenuDTOs;
using Restaurant.Models.DTOs.OrderDTOs;

namespace Restaurant.Services.IServices
{
    public interface IOrderMenuService
    {
        Task AddOrderAsync(int menuId, OrderDTO orderDTO);
        Task UpdateOrderAsync(int orderId, OrderDTO orderDTO);
        Task DeleteOrderAsync(int orderId);
        Task<ViewOrderDTO> SearchOrderAsync(int orderId);
        Task<IEnumerable<ViewOrderDTO>> SeeAllOrdersFromTableAsync(int tableId);
        Task<IEnumerable<ViewMenuDTO>> SeeMenuAsync(int restaurantId);
        Task<ViewMenuDTO> SearchMenuItemAsync(int menuId);
        Task AddDishOrDrinkAsync(MenuDTO menuDTO);
        Task DeleteDishOrDrinkAsync(int menuId);
        Task UpdateDishOrDrinkAsync(int menuId, MenuDTO menuDTO);
    }
}
