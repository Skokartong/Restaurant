using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int NumberOfGuests { get; set; }
        [Required]
        public DateTime BookingStart { get; set; }
        [Required]
        public DateTime BookingEnd { get; set; }

        // Each booking has a customer linked to it
        [ForeignKey("Customer")]
        public int? FK_CustomerId { get; set; }
        public Customer Customer { get; set; }

        // Each booking has a table linked to it
        [ForeignKey("Table")]
        public int? FK_TableId { get; set; }
        public Table Table { get; set; }
    }
}
