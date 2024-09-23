using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string NameOfDish { get; set; }
        [MaxLength(30)]
        public string Drink { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        public string? Ingredients { get; set; }

        [Required]
        public double Price { get; set; }

        [ForeignKey("Restaurant")]
        public int FK_RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
