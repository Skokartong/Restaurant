using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models.DTOs.RestaurantDTOs
{
    public class RestaurantDTO
    {
        public string RestaurantName { get; set; }
        public string TypeOfRestaurant { get; set; }
        public string? AdditionalInformation { get; set; }
    }
}
