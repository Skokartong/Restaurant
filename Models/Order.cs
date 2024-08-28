using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Amount { get; set; }
        // Usually each restaurant maps each order to a certain table to keep track on things
        // Each order can consist of multiple booked tables however (for bigger companies)
        public ICollection<Table> Tables { get; set; }
        // Foreign key to see if order item is available on menu
        [ForeignKey("Menu")]
        public int FK_MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
