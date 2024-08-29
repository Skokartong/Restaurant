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
            await _context.Reservation.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReservationAsync(int reservationId)
        {
            var reservation = await _context.Reservation.FindAsync(reservationId);

            if (reservation!=null)
            {
                _context.Reservation.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateReservationAsync(int reservationId, Reservation updatedReservation)
        {
            var reservation = await _context.Reservation.FindAsync(reservationId);

            if (reservation!=null)
            {
                reservation.FK_CustomerId = updatedReservation.FK_CustomerId;
                reservation.NumberOfGuests = updatedReservation.NumberOfGuests;
                reservation.BookingDate = updatedReservation.BookingDate;
                reservation.FK_TableId = updatedReservation.FK_TableId;

                _context.Reservation.Update(reservation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
