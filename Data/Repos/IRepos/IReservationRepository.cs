using Restaurant.Models;

namespace Restaurant.Data.Repos.IRepos
{
    public interface IReservationRepository
    {
        Task AddReservationAsync(Reservation reservation);
        Task<Reservation> UpdateReservationAsync(int reservationId, Reservation updatedReservation);
        Task DeleteReservationAsync(int reservationId);
    }
}
