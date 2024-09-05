using Restaurant.Models;

namespace Restaurant.Data.Repos.IRepos
{
    public interface IReservationRepository
    {
        Task AddReservationAsync(Reservation reservation);
        Task UpdateReservationAsync(int reservationId, Reservation updatedReservation);
        Task DeleteReservationAsync(int reservationId);
        Task<IEnumerable<Reservation>> ViewAllReservationsAsync();
    }
}
