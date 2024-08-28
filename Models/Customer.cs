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
        [MaxLength(10)]
        public int Phone { get; set; }
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }
        // Foreign key restaurant to link customers to specific restaurant
        [ForeignKey("Restaurant")]
        public int FK_RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
