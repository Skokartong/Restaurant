using Restaurant.Models.DTOs;

namespace Restaurant.Services.IServices
{
    public interface IBookingService
    {
        Task UpdateReservationAsync(int reservationId, ReservationDTO updatedReservationDTO);
        Task DeleteReservationAsync(int reservationId);
        Task AddTableAsync(TableDTO tableDTO);
        Task UpdateTableAsync(int tableId, TableDTO updatedTableDTO);
        Task DeleteTableAsync(int tableId);
        Task<bool> BookTableAsync(int restaurantId, int customerId, DateTime startTime, DateTime endTime, int numberOfGuests);
    }
}
