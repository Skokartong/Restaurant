using Restaurant.Data.Repos.IRepos;
using Restaurant.Models;

namespace Restaurant.Data.Repos
{
    public class ReservationRepository:IReservationRepository
    {
        private readonly RestaurantContext _context;

        public ReservationRepository(RestaurantContext context)
        {
            _context = context;
        }

        public async Task AddReservationAsync(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteReservationAsync(int reservationId)
        {
            throw new NotImplementedException();
        }

        public async Task<Reservation> UpdateReservationAsync(int reservationId, Reservation updatedReservation)
        {
            throw new NotImplementedException();
        }
    }
}
