using Restaurant.Models.DTOs;

namespace Restaurant.Services.IServices
{
    public interface IRestaurantService
    {
        Task AddRestaurantAsync(RestaurantDTO restaurantDTO);
        Task DeleteRestaurantAsync(int restaurantId);
        Task UpdateRestaurantAsync(int restaurantId, RestaurantDTO restaurantDTO);
        Task<IEnumerable<RestaurantDTO>> GetAllRestaurantsAsync();
        Task<RestaurantDTO> SearchRestaurantAsync(int restaurantId);

    }
}
