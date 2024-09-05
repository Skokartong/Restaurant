using Restaurant.Models;

namespace Restaurant.Data.Repos.IRepos
{
    public interface IMenuRepository
    {
        Task<IEnumerable<Menu>> SeeMenuAsync(int restaurantId);
        Task AddDishOrDrinkAsync(Menu menuItem);
        Task DeleteDishOrDrinkAsync(int menuId);
        Task UpdateDishOrDrinkAsync(int menuId, Menu menuItem);
        Task<Menu?> GetAvailableMenuItemAsync(int menuId);
    }
}
