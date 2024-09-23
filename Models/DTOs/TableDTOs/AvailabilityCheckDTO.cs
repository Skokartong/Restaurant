namespace Restaurant.Models.DTOs
{
    public class AvailabilityCheckDTO
    {
        public int RestaurantId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int NumberOfGuests { get; set; }
    }
}
