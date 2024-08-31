using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models.DTOs
{
    public class TableDTO
    {
        public int TableNumber { get; set; }
        public int AmountOfSeats { get; set; }
        public bool IsAvailable { get; set; }
        public int FK_RestaurantId { get; set; }
    }
}
