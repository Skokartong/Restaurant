using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Repos.IRepos;
using Restaurant.Models;
using Restaurant.Models.DTOs;

namespace Restaurant.Data.Repos
{
    public class ReservationRepository : IReservationRepository
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

            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Reservation> GetReservationByIdAsync(int reservationId)
        {
            return await _context.Reservations.FindAsync(reservationId);
        }

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reservation>> ViewAllReservationsAsync()
        {
            var reservationList = await _context.Reservations
            .Include(r => r.Customer)
            .Include(r => r.Restaurant)
            .AsNoTracking()
            .ToListAsync();
            return reservationList;
        }
    }
}
