using Restaurant.Models;
using Restaurant.Models.DTOs;

namespace Restaurant.Services.IServices
{
    public interface IBookingService
    {
        Task<IEnumerable<ReservationDTO>> ViewAllReservations();
        Task UpdateReservationAsync(int reservationId, ReservationDTO reservationDTO);
        Task DeleteReservationAsync(int reservationId);
        Task AddTableAsync(TableDTO tableDTO);
        Task UpdateTableAsync(int tableId, TableDTO tableDTO);
        Task DeleteTableAsync(int tableId);
        Task<bool> BookTableAsync(int restaurantId, int customerId, DateTime startTime, DateTime endTime, int numberOfGuests);
    }
}
