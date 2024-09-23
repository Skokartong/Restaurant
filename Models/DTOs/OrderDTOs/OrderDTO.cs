namespace Restaurant.Models.DTOs.OrderDTOs
{
    public class OrderDTO
    {
        public int Amount { get; set; }
        public int FK_TableId { get; set; }
        public int FK_MenuId { get; set; }
        public int FK_CustomerId { get; set; }
    }
}
