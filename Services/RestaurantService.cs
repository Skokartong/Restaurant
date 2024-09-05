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

        public async Task UpdateRestaurantAsync(int restaurantId, RestaurantDTO restaurantDTO)
        {
            var updatedRestaurant = new Models.Restaurant
            {
                Id = restaurantId,
                RestaurantName = restaurantDTO.RestaurantName,
                TypeOfRestaurant = restaurantDTO.TypeOfRestaurant
            };

            await _restaurantRepository.UpdateRestaurantAsync(restaurantId, updatedRestaurant);
        }

        public async Task<IEnumerable<RestaurantDTO>> GetAllRestaurantsAsync()
        {
            var restaurantsList = await _restaurantRepository.GetAllRestaurantsAsync();

            var restaurantDTO = restaurantsList.Select(r => new RestaurantDTO
            {
                RestaurantName = r.RestaurantName,
                TypeOfRestaurant = r.TypeOfRestaurant
            });

            return restaurantDTO;
        }

        public async Task<RestaurantDTO> SearchRestaurantAsync(int restaurantId)
        {
            var restaurant = await _restaurantRepository.SearchRestaurantAsync(restaurantId);

            return new RestaurantDTO
            {
                RestaurantName = restaurant.RestaurantName,
                TypeOfRestaurant = restaurant.TypeOfRestaurant
            };
        }
    }
}
