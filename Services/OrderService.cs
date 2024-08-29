using Restaurant.Data.Repos.IRepos;
using Restaurant.Models;
using Restaurant.Models.DTOs;
using Restaurant.Services.IServices;

namespace Restaurant.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task AddOrderAsync(OrderDTO orderDTO)
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

        public async Task DeleteOrderAsync(int orderId)
        {
            await _orderRepository.DeleteOrderAsync(orderId);
        }

        public async Task<OrderDTO> SearchOrderAsync(int orderId)
        {
            var order = await _orderRepository.SearchOrderAsync(orderId);

            if (order == null)
            {
                return null;
            }

            return new OrderDTO
            {
                Amount = order.Amount,
                FK_CustomerId = order.FK_CustomerId,
                FK_MenuId = order.FK_MenuId,
                FK_TableId = order.FK_TableId
            };
        }

        public async Task<List<OrderDTO>> SeeAllOrdersFromTableAsync(int tableId)
        {
            var orders = await _orderRepository.SeeAllOrdersFromTableAsync(tableId);

            return orders.Select(o => new OrderDTO
            {
                Amount = o.Amount,
                FK_CustomerId = o.FK_CustomerId,
                FK_MenuId = o.FK_MenuId
            }).ToList();
        }

        public async Task UpdateOrderAsync(int orderId, OrderDTO updatedOrderDTO)
        {
            var updatedOrder = new Order
            {
                Id = orderId,
                Amount = updatedOrderDTO.Amount,
                FK_CustomerId = updatedOrderDTO.FK_CustomerId,
                FK_MenuId = updatedOrderDTO.FK_MenuId,
                FK_TableId = updatedOrderDTO.FK_TableId
            };

            await _orderRepository.UpdateOrderAsync(orderId, updatedOrder);
        }
    }
}
