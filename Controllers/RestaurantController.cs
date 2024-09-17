using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Repos.IRepos;
using Restaurant.Models.DTOs;
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

        [HttpPost]
        [Route("/addrestaurant")]
        public async Task<IActionResult> AddRestaurant([FromBody] RestaurantDTO restaurantDTO)
        {
            await _restaurantService.AddRestaurantAsync(restaurantDTO);
            return CreatedAtAction(nameof(AddRestaurant), restaurantDTO);
        }

        [HttpDelete]
        [Route("/deleterestaurant/{restaurantId}")]
        public async Task<IActionResult> DeleteRestaurant(int restaurantId)
        {
            await _restaurantService.DeleteRestaurantAsync(restaurantId);
            return NoContent();
        }

        [HttpPut]
        [Route("/updaterestaurant/{restaurantId}")]
        public async Task<IActionResult> UpdateRestaurant(int restaurantId, [FromBody] RestaurantDTO restaurantDTO)
        {
            await _restaurantService.UpdateRestaurantAsync(restaurantId, restaurantDTO);
            return NoContent();
        }

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

        [HttpGet]
        [Route("/viewallrestaurants")]
        public async Task<IActionResult> ViewAllRestaurants()
        {
            var restaurants = await _restaurantService.GetAllRestaurantsAsync();
            return Ok(restaurants);
        }
    }
}
