﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Repos.IRepos;
using Restaurant.Services.IServices;
using Restaurant.Models;
using Restaurant.Models.DTOs.MenuDTOs;
using Restaurant.Models.DTOs.OrderDTOs;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderMenuController : ControllerBase
    {
        private readonly IOrderMenuService _orderMenuService;

        public OrderMenuController(IOrderMenuService orderMenuService)
        {
            _orderMenuService = orderMenuService;
        }

        [HttpPost]
        [Route("/addmenuitem")]
        public async Task<IActionResult> AddMenu([FromBody] MenuDTO menuDTO)
        {
            await _orderMenuService.AddDishOrDrinkAsync(menuDTO);
            return Created("", menuDTO);
        }

        [HttpDelete]
        [Route("/deletedish/{menuId}")]
        public async Task<IActionResult> DeleteMenu(int menuId)
        {
            await _orderMenuService.DeleteDishOrDrinkAsync(menuId);
            return NoContent();
        }

        [HttpPut]
        [Route("/updatemenuitem/{menuId}")]
        public async Task<IActionResult> UpdateMenu(int menuId, [FromBody] MenuDTO menuDTO)
        {
            await _orderMenuService.UpdateDishOrDrinkAsync(menuId, menuDTO);
            return Ok(menuDTO);
        }

        [HttpGet]
        [Route("/viewdish/{menuId}")]
        public async Task<ActionResult<ViewMenuDTO>> GetMenuItem(int menuId)
        {
            var menuItem = await _orderMenuService.SearchMenuItemAsync(menuId);
            if (menuItem == null)
            {
                return NotFound();
            }
            return Ok(menuItem);
        }

        [HttpGet]
        [Route("/viewmenu/{restaurantId}")]
        public async Task<ActionResult<List<ViewMenuDTO>>> GetMenu(int restaurantId)
        {
            var menu = await _orderMenuService.SeeMenuAsync(restaurantId);
            return Ok(menu);
        }

        [HttpPost]
        [Route("/addorder")]
        public async Task<IActionResult> AddOrder(int menuId, [FromBody] OrderDTO orderDTO)
        {
            await _orderMenuService.AddOrderAsync(menuId, orderDTO);
            return Created("", orderDTO);
        }

        [HttpDelete]
        [Route("/deleteorder/{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            await _orderMenuService.DeleteOrderAsync(orderId);
            return NoContent();
        }

        [HttpPut]
        [Route("/updateorder/{orderId}")]
        public async Task<IActionResult> UpdateOrder(int orderId,[FromBody] OrderDTO orderDTO)
        {
            var existingOrder = await _orderMenuService.SearchOrderAsync(orderId);

            if (existingOrder == null)
            {
                return NotFound();
            }
            await _orderMenuService.UpdateOrderAsync(orderId, orderDTO);
            return NoContent();
        }

        [HttpGet]
        [Route("/getorder/{orderId}")]
        public async Task<ActionResult<ViewOrderDTO>> GetOrder(int orderId)
        {
            var order = await _orderMenuService.SearchOrderAsync(orderId);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet]
        [Route("/vieworders/{tableId}")]
        public async Task<ActionResult<List<ViewOrderDTO>>> GetOrdersByTable(int tableId)
        {
            var orders = await _orderMenuService.SeeAllOrdersFromTableAsync(tableId);
            return Ok(orders);
        }
    }
}
