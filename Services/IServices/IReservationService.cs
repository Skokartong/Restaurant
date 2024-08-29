using Restaurant.Models.DTOs;

namespace Restaurant.Services.IServices
{
    public interface IReservationService
    {
        Task AddReservationAsync(ReservationDTO reservationDTO);
        Task UpdateReservationAsync(int reservationId, ReservationDTO updatedReservationDTO);
        Task DeleteReservationAsync(int reservationId);
    }
}
