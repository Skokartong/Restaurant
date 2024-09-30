using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Repos.IRepos;
using Restaurant.Models.DTOs.RestaurantDTOs;
using Restaurant.Services.IServices;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        // Admin Controller
        [HttpPost]
        [Route("/addrestaurant")]
        public async Task<IActionResult> AddRestaurant([FromBody] RestaurantDTO restaurantDTO)
        {
            await _restaurantService.AddRestaurantAsync(restaurantDTO);
            return Created("", restaurantDTO);
        }

        // Admin Controller
        [HttpDelete]
        [Route("/deleterestaurant/{restaurantId}")]
        public async Task<IActionResult> DeleteRestaurant(int restaurantId)
        {
            await _restaurantService.DeleteRestaurantAsync(restaurantId);
            return NoContent();
        }

        // Admin Controller
        [HttpPut]
        [Route("/updaterestaurant/{restaurantId}")]
        public async Task<IActionResult> UpdateRestaurant(int restaurantId, [FromBody] RestaurantDTO restaurantDTO)
        {
            await _restaurantService.UpdateRestaurantAsync(restaurantId, restaurantDTO);
            return NoContent();
        }

        // Menu Controller
        [HttpGet]
        [Route("/viewrestaurant/{restaurantId}")]
        public async Task<ActionResult<RestaurantDTO>> GetRestaurant(int restaurantId)
        {
            var restaurant = await _restaurantService.SearchRestaurantAsync(restaurantId);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        // Menu Controller
        [HttpGet]
        [Route("/viewallrestaurants")]
        public async Task<IActionResult> ViewAllRestaurants()
        {
            var restaurants = await _restaurantService.GetAllRestaurantsAsync();
            return Ok(restaurants);
        }
    }
}
