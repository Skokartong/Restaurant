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
        public DateTime BookingDate { get; set; }
        // Each booking has one customer linked to it
        [ForeignKey("Customer")]
        public int FK_CustomerId { get; set; }
        public Customer Customer { get; set; }
        // Each booking though, can consist of multiple tables (if the company is big)
        public ICollection<Table> Tables { get; set; }
    }
}
