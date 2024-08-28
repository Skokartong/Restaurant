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
            throw new NotImplementedException();
        }

        public async Task DeleteRestaurantAsync(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public async Task<Models.Restaurant> UpdateRestaurantAsync(int restaurantId, Models.Restaurant updatedRestaurant)
        {
            throw new NotImplementedException();
        }
    }
}
