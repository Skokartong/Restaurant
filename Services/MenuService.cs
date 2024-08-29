using Restaurant.Data.Repos.IRepos;
using Restaurant.Models;
using Restaurant.Models.DTOs;
using Restaurant.Services.IServices;

namespace Restaurant.Services
{
    public class MenuService:IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task AddDishOrDrinkAsync(MenuDTO menuItemDTO)
        {
            var menu = new Menu
            {
                NameOfDish = menuItemDTO.NameOfDish,
                Drink = menuItemDTO.Drink,
                Price = menuItemDTO.Price,
                IsAvailable = menuItemDTO.IsAvailable,
                FK_RestaurantId = menuItemDTO.FK_RestaurantId
            };

            await _menuRepository.AddDishOrDrinkAsync(menu);
        }

        public async Task DeleteDishOrDrinkAsync(int menuId)
        {
            await _menuRepository.DeleteDishOrDrinkAsync(menuId);
        }

        public async Task<List<MenuDTO>> SeeMenuAsync(int restaurantId)
        {
            var menuList = await _menuRepository.SeeMenuAsync(restaurantId);

            if (menuList == null || !menuList.Any())
            {
                return new List<MenuDTO>(); 
            }

            return menuList.Select(m => new MenuDTO
            {
                NameOfDish = m.NameOfDish,
                Drink = m.Drink,
                Price = m.Price,
                IsAvailable = m.IsAvailable,
                FK_RestaurantId = m.FK_RestaurantId
            }).ToList();
        }

        public async Task UpdateDishOrDrinkAsync(int menuId, MenuDTO menuItemDTO)
        {
            var updateMenu = new Menu
            {
                NameOfDish = menuItemDTO.NameOfDish,
                Drink = menuItemDTO.Drink,
                Price = menuItemDTO.Price,
                IsAvailable = menuItemDTO.IsAvailable,
                FK_RestaurantId = menuItemDTO.FK_RestaurantId
            };

            await _menuRepository.UpdateDishOrDrinkAsync(menuId, updateMenu);
        }
    }
}
