using Restaurant.Data.Repos.IRepos;
using Restaurant.Models;
using Restaurant.Models.DTOs;
using Restaurant.Services.IServices;

namespace Restaurant.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task AddReservationAsync(ReservationDTO reservationDTO)
        {
            var reservation = new Reservation
            {
                NumberOfGuests = reservationDTO.NumberOfGuests,
                BookingStart = reservationDTO.BookingStart,
                BookingEnd = reservationDTO.BookingEnd,
                FK_TableId = reservationDTO.FK_TableId,
                FK_CustomerId = reservationDTO.FK_CustomerId
            };

            await _reservationRepository.AddReservationAsync(reservation);
        }

        public async Task DeleteReservationAsync(int reservationId)
        {
            await _reservationRepository.DeleteReservationAsync(reservationId);
        }

        public async Task UpdateReservationAsync(int reservationId, ReservationDTO updatedReservationDTO)
        {
            var updatedReservation = new Reservation
            {
                NumberOfGuests = updatedReservationDTO.NumberOfGuests,
                BookingStart = updatedReservationDTO.BookingStart,
                BookingEnd = updatedReservationDTO.BookingEnd,
                FK_TableId = updatedReservationDTO.FK_TableId,
                FK_CustomerId = updatedReservationDTO.FK_CustomerId
            };

            await _reservationRepository.UpdateReservationAsync(reservationId, updatedReservation);
        }
    }
}
