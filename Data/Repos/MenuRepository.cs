using Restaurant.Data.Repos.IRepos;
using Restaurant.Models;

namespace Restaurant.Data.Repos
{
    public class MenuRepository : IMenuRepository
    {
        private readonly RestaurantContext _context;

        public MenuRepository(RestaurantContext context)
        {
            _context = context;
        }

        public async Task AddDishOrDrinkAsync(Menu menuItem)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteDishOrDrinkAsync(int menuId)
        {
            throw new NotImplementedException();
        }

        public async Task SeeMenuAsync(string restaurantName)
        {
            throw new NotImplementedException();
        }

        public async Task<Menu> UpdateDishOrDrinkAsync(int menuId, Menu menuItem)
        {
            throw new NotImplementedException();
        }
    }
}
