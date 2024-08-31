using Restaurant.Data.Repos.IRepos;
using Restaurant.Models.DTOs;
using Restaurant.Services.IServices;

namespace Restaurant.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }
        public async Task AddRestaurantAsync(RestaurantDTO restaurantDTO)
        {
            var addRestaurant = new Models.Restaurant
            {
                RestaurantName = restaurantDTO.RestaurantName,
                TypeOfRestaurant = restaurantDTO.TypeOfRestaurant
            };

            await _restaurantRepository.AddRestaurantAsync(addRestaurant);
        }

        public async Task DeleteRestaurantAsync(int restaurantId)
        {
            await _restaurantRepository.DeleteRestaurantAsync(restaurantId);
        }

        public async Task UpdateRestaurantAsync(int restaurantId, RestaurantDTO updatedRestaurantDTO)
        {
            var updatedRestaurant = new Models.Restaurant
            {
                Id = restaurantId,
                RestaurantName = updatedRestaurantDTO.RestaurantName,
                TypeOfRestaurant = updatedRestaurantDTO.TypeOfRestaurant
            };

            await _restaurantRepository.UpdateRestaurantAsync(restaurantId, updatedRestaurant);
        }

        public async Task<IEnumerable<Models.Restaurant>> GetAllRestaurantsAsync()
        {
            return await _restaurantRepository.GetAllRestaurantsAsync();
        }

        public async Task<Models.Restaurant> SearchRestaurantAsync(int restaurantId)
        {
            return await _restaurantRepository.SearchRestaurantAsync(restaurantId);
        }
    }
}
