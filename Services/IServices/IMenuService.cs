using Restaurant.Models;
using Restaurant.Models.DTOs;

namespace Restaurant.Services.IServices
{
    public interface IMenuService
    {
        Task<List<MenuDTO>> SeeMenuAsync(int restaurantId);
        Task AddDishOrDrinkAsync(MenuDTO menuItem);
        Task DeleteDishOrDrinkAsync(int menuId);
        Task UpdateDishOrDrinkAsync(int menuId, MenuDTO menuItem);
    }
}
