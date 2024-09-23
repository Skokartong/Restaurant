using Restaurant.Data.Repos.IRepos;
using Restaurant.Models;
using Restaurant.Models.DTOs.MenuDTOs;
using Restaurant.Models.DTOs.OrderDTOs;
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

        public async Task AddDishOrDrinkAsync(MenuDTO menuDTO)
        {
            var menu = new Menu
            {
                NameOfDish = menuDTO.NameOfDish,
                Drink = menuDTO.Drink,
                Price = menuDTO.Price,
                IsAvailable = menuDTO.IsAvailable,
                FK_RestaurantId = menuDTO.FK_RestaurantId
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

        public async Task<IEnumerable<ViewMenuDTO>> SeeMenuAsync(int restaurantId)
        {
            var menuList = await _menuRepository.SeeMenuAsync(restaurantId);

            if (menuList == null || !menuList.Any())
            {
                throw new InvalidOperationException($"There is no menu available at restaurant with id: {restaurantId} at the moment.");
            }

            return menuList.Select(m => new ViewMenuDTO
            {
                NameOfDish = m.NameOfDish,
                Drink = m.Drink,
                Price = m.Price,
                IsAvailable = m.IsAvailable,
            }).ToList();
        }

        public async Task AddOrderAsync(int menuId, OrderDTO orderDTO)
        {
            var isAvailable = await _menuRepository.GetAvailableMenuItemAsync(menuId);

            if (isAvailable)
            {
                var order = new Order
                {
                    Amount = orderDTO.Amount,
                    FK_CustomerId = orderDTO.FK_CustomerId,
                    FK_MenuId = orderDTO.FK_MenuId,
                    FK_TableId = orderDTO.FK_TableId
                };

                await _orderRepository.AddOrderAsync(order);
            }

            else
            {
                throw new InvalidOperationException($"Sadly menu item {menuId} is not available :(");
            }
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

        public async Task<ViewOrderDTO> SearchOrderAsync(int orderId)
        {
            var order = await _orderRepository.SearchOrderAsync(orderId);

            if (order == null)
            {
                throw new InvalidOperationException("There is no order with the selected id");
            }

            return new ViewOrderDTO
            {
                CustomerName = order.Customer?.Name??"",
                NameOfDish = order.Menu?.NameOfDish??"",
                Drink = order.Menu?.Drink??"",
                Amount = order.Amount,
                TableNumber = order.Table?.TableNumber?? 0
            };
        }

        public async Task<IEnumerable<ViewOrderDTO>> SeeAllOrdersFromTableAsync(int tableId)
        {
            var orders = await _orderRepository.SeeAllOrdersFromTableAsync(tableId);

            if(orders==null)
            {
                throw new InvalidCastException($"No orders from table with id: {tableId} found");
            }

            return orders.Select(o => new ViewOrderDTO
            {
                CustomerName = o.Customer?.Name??"",
                NameOfDish = o.Menu?.NameOfDish??"",
                Drink = o.Menu?.Drink??"",
                TableNumber = o.Table?.TableNumber?? 0,
                Amount = o.Amount,
            }).ToList();
        }

        public async Task<ViewMenuDTO> SearchMenuItemAsync(int menuId)
        {
            var menuItem = await _menuRepository.SearchMenuItemAsync(menuId);

            if (menuItem == null)
            {
                throw new InvalidCastException($"No dish with id:{menuId} found");
            }

            return new ViewMenuDTO
            {
                NameOfDish = menuItem.NameOfDish,
                Drink = menuItem.Drink,
                Ingredients = menuItem.Ingredients,
                Price = menuItem.Price,
                IsAvailable = menuItem.IsAvailable,
            };
        }
    }
}

