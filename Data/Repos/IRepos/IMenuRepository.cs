using Restaurant.Models;

namespace Restaurant.Data.Repos.IRepos
{
    public interface IMenuRepository
    {
        Task SeeMenuAsync(string restaurantName);
        Task AddDishOrDrinkAsync(Menu menuItem);
        Task DeleteDishOrDrinkAsync(int menuId);
        Task<Menu> UpdateDishOrDrinkAsync(int menuId, Menu menuItem);
    }
}
