using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string? NameOfDish { get; set; }
        [MaxLength(30)]
        public string? Drink { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public double Price { get; set; }

        // Foreign key to map each menu to one particular restaurant
        [ForeignKey("Restaurant")]
        public int? FK_RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
