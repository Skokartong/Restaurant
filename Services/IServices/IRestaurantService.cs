using Restaurant.Models.DTOs;

namespace Restaurant.Services.IServices
{
    public interface IRestaurantService
    {
        Task AddRestaurantAsync(RestaurantDTO restaurantDTO);
        Task DeleteRestaurantAsync(int restaurantId);
        Task UpdateRestaurantAsync(int restaurantId, RestaurantDTO restaurantDTO);
        Task<IEnumerable<Models.Restaurant>> GetAllRestaurantsAsync();
        Task<Models.Restaurant> SearchRestaurantAsync(int restaurantId);

    }
}
