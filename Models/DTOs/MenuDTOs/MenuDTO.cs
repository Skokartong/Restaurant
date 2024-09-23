using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models.DTOs.MenuDTOs
{
    public class MenuDTO
    {
        public string NameOfDish { get; set; }
        public string Drink { get; set; }
        public bool IsAvailable { get; set; }
        public string? Ingredients { get; set; }
        public double Price { get; set; }
        public int FK_RestaurantId { get; set; }
    }
}
