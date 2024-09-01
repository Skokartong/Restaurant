using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models.DTOs
{
    public class ReservationDTO
    {
        public int NumberOfGuests { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public int FK_CustomerId { get; set; }
        public int FK_RestaurantId { get; set; }
    }
}
