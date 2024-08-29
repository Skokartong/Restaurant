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
