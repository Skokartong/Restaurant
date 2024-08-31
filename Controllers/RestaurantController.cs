using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Repos.IRepos;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantController(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        [HttpPost]
        [Route("/add")]
        public async Task<IActionResult> AddRestaurant(Models.Restaurant restaurant)
        {
            await _restaurantRepository.AddRestaurantAsync(restaurant);
            return CreatedAtAction(nameof(GetRestaurant), new { id = restaurant.Id }, restaurant);
        }

        [HttpDelete]
        [Route("/delete/{restaurantId}")]
        public async Task<IActionResult> DeleteRestaurant(int restaurantId)
        {
            await _restaurantRepository.DeleteRestaurantAsync(restaurantId);
            return NoContent();
        }

        [HttpPut]
        [Route("/update/{restaurantId}")]
        public async Task<IActionResult> UpdateRestaurant(int restaurantId, Models.Restaurant restaurant)
        {
            if (restaurantId != restaurant.Id)
            {
                return BadRequest();
            }

            await _restaurantRepository.UpdateRestaurantAsync(restaurantId, restaurant);
            return NoContent();
        }

        [HttpGet]
        [Route("/{restaurantId}")]
        public async Task<ActionResult<Models.Restaurant>> GetRestaurant(int restaurantId)
        {
            var restaurant = await _restaurantRepository.SearchRestaurantAsync(restaurantId);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpGet]
        [Route("/view")]
        public async Task<IActionResult> ViewAllRestaurants()
        {
            var restaurants = await _restaurantRepository.GetAllRestaurantsAsync();
            return Ok(restaurants);
        }
    }
}
