using Restaurant.Models;

namespace Restaurant.Data.Repos.IRepos
{
    public interface IRestaurantRepository
    {
        Task AddRestaurantAsync(Models.Restaurant restaurant);
        Task DeleteRestaurantAsync(int restaurantId);
        Task UpdateRestaurantAsync(int restaurantId, Models.Restaurant updatedRestaurant);
        Task <Models.Restaurant> SearchRestaurantAsync(int restaurantId);
        Task<IEnumerable<Models.Restaurant>> GetAllRestaurantsAsync();
    }
}
