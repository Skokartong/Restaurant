using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Table
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TableNumber { get; set; }
        [Required]
        public int AmountOfSeats { get; set; }
        // Making sure each table is available for booking
        public bool IsAvailable { get; set; }
    }
}
