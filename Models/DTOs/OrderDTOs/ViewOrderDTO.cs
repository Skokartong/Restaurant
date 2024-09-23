namespace Restaurant.Models.DTOs.OrderDTOs
{
    public class ViewOrderDTO
    {
        public string? CustomerName { get; set; }
        public int TableNumber { get; set; }
        public string? NameOfDish { get; set; }
        public string? Drink { get; set; }
        public int Amount { get; set; }
    }
}
