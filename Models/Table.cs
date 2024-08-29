using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        // Navigation for all orders linked to a certain table
        public ICollection<Order> Orders { get; set; }
        // Each table is linked to specific restaurant
        [ForeignKey("Restaurant")]
        public int FK_RestaurantId { get; set; }
    }
}
