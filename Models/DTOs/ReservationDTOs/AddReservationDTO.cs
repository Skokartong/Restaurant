namespace Restaurant.Models.DTOs.RestaurantDTOs
{
    public class AddReservationDTO
    {
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public int NumberOfGuests { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public string? Message { get; set; }
    }
}
