using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Repos.IRepos;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderMenuController : ControllerBase
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderMenuController(IMenuRepository menuRepository, IOrderRepository orderRepository)
        {
            _menuRepository = menuRepository;
            _orderRepository = orderRepository;
        }

        [HttpPost]
        [Route("menu/add")]
        public async Task<IActionResult> AddMenu(Menu menuItem)
        {
            await _menuRepository.AddDishOrDrinkAsync(menuItem);
            return CreatedAtAction(nameof(GetMenuItem), new { id = menuItem.Id }, menuItem);
        }

        [HttpDelete]
        [Route("menu/delete/{menuId}")]
        public async Task<IActionResult> DeleteMenu(int menuId)
        {
            await _menuRepository.DeleteDishOrDrinkAsync(menuId);
            return NoContent();
        }

        [HttpPut]
        [Route("menu/update/{menuId}")]
        public async Task<IActionResult> UpdateMenu(int menuId, Menu menuItem)
        {
            if (menuId != menuItem.Id)
            {
                return BadRequest();
            }

            await _menuRepository.UpdateDishOrDrinkAsync(menuId, menuItem);
            return NoContent();
        }

        [HttpGet]
        [Route("menu/{menuId}")]
        public async Task<ActionResult<Menu>> GetMenuItem(int menuId)
        {
            var menuItem = await _menuRepository.GetAvailableMenuItemAsync(menuId);
            if (menuItem == null)
            {
                return NotFound();
            }
            return Ok(menuItem);
        }

        [HttpGet]
        [Route("menu/restaurant/{menuId}")]
        public async Task<ActionResult<List<Menu>>> GetMenu(int menuId)
        {
            var menu = await _menuRepository.SeeMenuAsync(menuId);
            return Ok(menu);
        }

        [HttpPost]
        [Route("order/add")]
        public async Task<IActionResult> AddOrder(Order order)
        {
            await _orderRepository.AddOrderAsync(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        [HttpDelete]
        [Route("order/delete/{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            await _orderRepository.DeleteOrderAsync(orderId);
            return NoContent();
        }

        [HttpPut]
        [Route("order/update/{orderId}")]
        public async Task<IActionResult> UpdateOrder(int orderId, Order order)
        {
            if (orderId != order.Id)
            {
                return BadRequest();
            }

            await _orderRepository.UpdateOrderAsync(orderId, order);
            return NoContent();
        }

        [HttpGet]
        [Route("order/get/{orderId}")]
        public async Task<ActionResult<Order>> GetOrder(int orderId)
        {
            var order = await _orderRepository.SearchOrderAsync(orderId);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet]
        [Route("order/table/{tableId}")]
        public async Task<ActionResult<List<Order>>> GetOrdersByTable(int tableId)
        {
            var orders = await _orderRepository.SeeAllOrdersFromTableAsync(tableId);
            return Ok(orders);
        }
    }
}
