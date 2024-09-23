using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models.DTOs.TableDTOs
{
    public class TableDTO
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int AmountOfSeats { get; set; }
        public int FK_RestaurantId { get; set; }
    }
}
