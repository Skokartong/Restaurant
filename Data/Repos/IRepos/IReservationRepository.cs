using Restaurant.Models;
using Restaurant.Models.DTOs;

namespace Restaurant.Data.Repos.IRepos
{
    public interface IReservationRepository
    {
        Task AddReservationAsync(Reservation reservation);
        Task DeleteReservationAsync(int reservationId);
        Task UpdateReservationAsync(Reservation updatedReservation);
        Task<Reservation> GetReservationByIdAsync(int reservationId);
        Task<IEnumerable<Reservation>> ViewAllReservationsAsync();
        Task<IEnumerable<Reservation>> GetReservationsByCustomerAsync(int customerId);
    }
}
