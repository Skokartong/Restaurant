using Restaurant.Models;
using Restaurant.Models.DTOs;

namespace Restaurant.Services.IServices
{
    public interface IBookingService
    {
        Task<IEnumerable<ReservationDTO>> ViewAllReservationsAsync();
        Task UpdateReservationAsync(int reservationId, ReservationDTO reservationDTO);
        Task DeleteReservationAsync(int reservationId);
        Task<Table> AddTableAsync(TableDTO tableDTO);
        Task<IEnumerable<TableDTO>> GetTablesByRestaurantIdAsync(int restaurantId);
        Task UpdateTableAsync(int tableId, TableDTO tableDTO);
        Task DeleteTableAsync(int tableId);
        Task BookTableAsync(int restaurantId, int customerId, DateTime startTime, DateTime endTime, int numberOfGuests);
    }
}
