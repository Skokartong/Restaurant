using Restaurant.Data.Repos.IRepos;
using Restaurant.Models;
using Restaurant.Models.DTOs;
using Restaurant.Services.IServices;

namespace Restaurant.Services
{
    public class OrderMenuService : IOrderMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderMenuService(IMenuRepository menuRepository, IOrderRepository orderRepository)
        {
            _menuRepository = menuRepository;
            _orderRepository = orderRepository;
        }

        public async Task AddDishOrDrinkAsync(MenuDTO menuItemDTO)
        {
            var menu = new Menu
            {
                NameOfDish = menuItemDTO.NameOfDish,
                Drink = menuItemDTO.Drink,
                Price = menuItemDTO.Price,
                IsAvailable = menuItemDTO.IsAvailable,
                FK_RestaurantId = menuItemDTO.FK_RestaurantId
            };

            await _menuRepository.AddDishOrDrinkAsync(menu);
        }

        public async Task UpdateDishOrDrinkAsync(int menuId, MenuDTO menuDTO)
        {
            var updateMenu = new Menu
            {
                Id = menuId,
                NameOfDish = menuDTO.NameOfDish,
                Drink = menuDTO.Drink,
                Price = menuDTO.Price,
                IsAvailable = menuDTO.IsAvailable,
                FK_RestaurantId = menuDTO.FK_RestaurantId
            };

            await _menuRepository.UpdateDishOrDrinkAsync(menuId, updateMenu);
        }

        public async Task DeleteDishOrDrinkAsync(int menuId)
        {
            await _menuRepository.DeleteDishOrDrinkAsync(menuId);
        }

        public async Task<IEnumerable<MenuDTO>> SeeMenuAsync(int restaurantId)
        {
            var menuList = await _menuRepository.SeeMenuAsync(restaurantId);

            if(menuList==null)
            {
                throw new InvalidOperationException("There is no menu available at the selected restaurant at the moment");
            }

            return menuList.Select(m => new MenuDTO
            {
                NameOfDish = m.NameOfDish,
                Drink = m.Drink,
                Price = m.Price,
                IsAvailable = m.IsAvailable,
                FK_RestaurantId = m.FK_RestaurantId
            }).ToList();
        }

        public async Task AddOrderAsync(OrderDTO orderDTO)
        {
            var menuItem = await _menuRepository.GetAvailableMenuItemAsync(orderDTO.FK_MenuId);

            if (menuItem == null)
            {
                throw new InvalidOperationException("The selected menu item is not available.");
            }

            var order = new Order
            {
                Amount = orderDTO.Amount,
                FK_CustomerId = orderDTO.FK_CustomerId,
                FK_MenuId = orderDTO.FK_MenuId,
                FK_TableId = orderDTO.FK_TableId
            };

            await _orderRepository.AddOrderAsync(order);
        }

        public async Task UpdateOrderAsync(int orderId, OrderDTO orderDTO)
        {
            var updatedOrder = new Order
            {
                Id = orderId,
                Amount = orderDTO.Amount,
                FK_CustomerId = orderDTO.FK_CustomerId,
                FK_MenuId = orderDTO.FK_MenuId,
                FK_TableId = orderDTO.FK_TableId
            };

            await _orderRepository.UpdateOrderAsync(orderId, updatedOrder);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            await _orderRepository.DeleteOrderAsync(orderId);
        }

        public async Task<OrderDTO> SearchOrderAsync(int orderId)
        {
            var order = await _orderRepository.SearchOrderAsync(orderId);

            if (order == null)
            {
                throw new InvalidOperationException("There is no order with the selected id");
            }

            return new OrderDTO
            {
                Amount = order.Amount,
                FK_CustomerId = order.FK_CustomerId,
                FK_MenuId = order.FK_MenuId,
                FK_TableId = order.FK_TableId
            };
        }

        public async Task<IEnumerable<OrderDTO>> SeeAllOrdersFromTableAsync(int tableId)
        {
            var orders = await _orderRepository.SeeAllOrdersFromTableAsync(tableId);

            return orders.Select(o => new OrderDTO
            {
                Amount = o.Amount,
                FK_CustomerId = o.FK_CustomerId,
                FK_MenuId = o.FK_MenuId
            }).ToList();
        }

        public async Task<MenuDTO> GetAvailableMenuItemAsync(int menuId)
        {
            var menuItem = await _menuRepository.GetAvailableMenuItemAsync(menuId);

            if (menuItem == null)
            {
                throw new InvalidCastException($"No dish with id:{menuId} found");
            }

            return new MenuDTO
            {
                NameOfDish = menuItem.NameOfDish,
                Drink = menuItem.Drink,
                Price = menuItem.Price,
                IsAvailable = menuItem.IsAvailable,
                FK_RestaurantId = menuItem.FK_RestaurantId
            };
        }
    }
}

