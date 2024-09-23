using Restaurant.Models;
using Restaurant.Models.DTOs;
using Restaurant.Models.DTOs.ReservationDTOs;
using Restaurant.Models.DTOs.RestaurantDTOs;
using Restaurant.Models.DTOs.TableDTOs;

namespace Restaurant.Services.IServices
{
    public interface IBookingService
    {
        Task AddTableAsync(TableDTO tableDTO);
        Task DeleteTableAsync(int tableId);
        Task UpdateTableAsync(int tableId, TableDTO tableDTO);
        Task<IEnumerable<ViewReservationDTO>> ViewAllReservationsAsync();
        Task UpdateReservationAsync(int reservationId, UpdateReservationDTO reservationDTO);
        Task DeleteReservationAsync(int reservationId);
        Task<IEnumerable<TableDTO>> CheckAvailabilityAsync(AvailabilityCheckDTO checkDTO);
        Task BookTableAsync(AddReservationDTO reservationDTO, int customerId, int restaurantId);
    }
}
