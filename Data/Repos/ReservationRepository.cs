using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
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
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReservationAsync(int reservationId)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);

            if (reservation!=null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateReservationAsync(int reservationId, Reservation updatedReservation)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);

            if (reservation!=null)
            {
                reservation.FK_CustomerId = updatedReservation.FK_CustomerId;
                reservation.NumberOfGuests = updatedReservation.NumberOfGuests;
                reservation.BookingStart = updatedReservation.BookingStart;
                reservation.BookingEnd = updatedReservation.BookingEnd;
                reservation.FK_TableId = updatedReservation.FK_TableId;

                _context.Reservations.Update(reservation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Reservation>> ViewAllReservationsAsync()
        {
            var reservationList = await _context.Reservations.ToListAsync();
            return reservationList;
        }
    }
}
