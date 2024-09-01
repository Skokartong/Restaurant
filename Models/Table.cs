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
        public bool IsAvailable { get; set; }

        // Navigation property for all orders linked to a certain table
        public ICollection<Order> Orders { get; set; }
        // Navigation property for all reservations linked to a certain table
        public virtual ICollection<Reservation> Reservations { get; set; }

        // Each table is linked to a specific restaurant
        [ForeignKey("Restaurant")]
        public int FK_RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }  
    }
}
