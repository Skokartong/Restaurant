using Restaurant.Models;

namespace Restaurant.Data.Repos.IRepos
{
    public interface IMenuRepository
    {
        Task AddDishOrDrinkAsync(Menu menu);
        Task DeleteDishOrDrinkAsync(int menuId);
        Task UpdateDishOrDrinkAsync(int menuId, Menu updatedMenu);
        Task<IEnumerable<Menu?>> SeeMenuAsync(int FK_RestaurantId);
        Task<Menu?> SearchMenuItemAsync(int menuId);
        Task<bool> GetAvailableMenuItemAsync(int menuId);
    }
}
