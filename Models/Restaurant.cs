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
        // A restaurant can have multiple dishes or drinks on the menu
        public ICollection<Menu> Menus { get; set; }
        // A restaurant can have multiple customers
        public ICollection<Customer> Customers { get; set; }
    }
}
