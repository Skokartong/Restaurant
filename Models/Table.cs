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
        public ICollection<Order> Orders { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

        [ForeignKey("Restaurant")]
        public int FK_RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }  
    }
}
