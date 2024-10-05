using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        public int? FK_RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
