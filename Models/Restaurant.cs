using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string RestaurantName { get; set; }
        [Required]
        [MaxLength(50)]
        public string TypeOfRestaurant { get; set; }
        public ICollection<Menu> Menus { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Table> Tables { get; set; }
    }
}
