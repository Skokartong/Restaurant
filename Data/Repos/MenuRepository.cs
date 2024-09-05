﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<Menu?> SearchMenuItemAsync(int menuId)
        {
            return await _context.Menus.FindAsync(menuId);
        }

        public async Task AddDishOrDrinkAsync(Menu menuItem)
        {
            await _context.Menus.AddAsync(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDishOrDrinkAsync(int menuId)
        {
            var deleteItem = await _context.Menus.FindAsync(menuId);

            if(deleteItem!=null)
            {
                _context.Menus.Remove(deleteItem);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Menu>> SeeMenuAsync(int restaurantId)
        {
            return await _context.Menus.Where(m => m.FK_RestaurantId == restaurantId).ToListAsync();
        }

        public async Task UpdateDishOrDrinkAsync(int menuId, Menu updateMenu)
        {
            var menuItem = await _context.Menus.FindAsync(menuId);
            
            if(menuItem!=null)
            {
                menuItem.FK_RestaurantId = updateMenu.FK_RestaurantId;
                menuItem.Drink = updateMenu.Drink;
                menuItem.NameOfDish = updateMenu.NameOfDish;
                menuItem.Price = updateMenu.Price;
                menuItem.IsAvailable = updateMenu.IsAvailable;

                _context.Menus.Update(menuItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> GetAvailableMenuItemAsync(int menuId)
        {
            var menuItem = await _context.Menus
                .Where(m => m.Id == menuId)
                .Select(m => m.IsAvailable)
                .FirstOrDefaultAsync();

            return menuItem;
        }
    }
}
