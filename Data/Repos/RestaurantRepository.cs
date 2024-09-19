using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Repos.IRepos;

namespace Restaurant.Data.Repos
{
    public class RestaurantRepository:IRestaurantRepository
    {
        private readonly RestaurantContext _context;

        public RestaurantRepository(RestaurantContext context)
        {
            _context = context;
        }

        public async Task AddRestaurantAsync(Models.Restaurant restaurant)
        {
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRestaurantAsync(int restaurantId)
        {
            var restaurant = await _context.Restaurants.FindAsync(restaurantId);

            if(restaurant!=null)
            {
                _context.Restaurants.Remove(restaurant);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Models.Restaurant>> GetAllRestaurantsAsync()
        {
            var restaurants = await _context.Restaurants
                .AsNoTracking()
                .ToListAsync();

            if (restaurants==null)
            {
                throw new InvalidCastException("No restaurants available");
            }

            return restaurants;
        }

        public async Task<Models.Restaurant> SearchRestaurantAsync(int restaurantId)
        {
            var restaurant = await _context.Restaurants.FindAsync(restaurantId);

            if (restaurant == null)
            {
                throw new InvalidCastException("No restaurant with that id available");
            }

            return restaurant;
        }

        public async Task UpdateRestaurantAsync(int restaurantId, Models.Restaurant updatedRestaurant)
        {
            var restaurant = await _context.Restaurants.FindAsync(restaurantId);

            if(restaurant!=null)
            {
                restaurant.RestaurantName = updatedRestaurant.RestaurantName;
                restaurant.Menus = updatedRestaurant.Menus;
                restaurant.Customers = updatedRestaurant.Customers;
            }
        }
    }
}
