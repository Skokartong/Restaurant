using Restaurant.Data.Repos.IRepos;
using Restaurant.Migrations;
using Restaurant.Models;
using Restaurant.Models.DTOs;
using Restaurant.Services.IServices;

namespace Restaurant.Services
{
    public class BookingService : IBookingService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ITableRepository _tableRepository;

        public BookingService(IReservationRepository reservationRepository, ITableRepository tableRepository)
        {
            _reservationRepository = reservationRepository;
            _tableRepository = tableRepository;
        }

        public async Task<bool> BookTableAsync(int restaurantId, int customerId, DateTime startTime, DateTime endTime, int numberOfGuests)
        {
            var availableTable = await _tableRepository.GetAvailableTableAsync(restaurantId, startTime, endTime, numberOfGuests);

            if (availableTable == null)
            {
                throw new InvalidOperationException("Unfortunately, there are no tables available at that time.");
            }

            var reservation = new Models.Reservation
            {
                FK_CustomerId = customerId,
                FK_TableId = availableTable.Id,
                FK_RestaurantId = restaurantId,
                NumberOfGuests = numberOfGuests,
                BookingStart = startTime,
                BookingEnd = endTime
            };

            await _reservationRepository.AddReservationAsync(reservation);

            // Background task that sets table as available when end of booking
                availableTable.IsAvailable = false;
                await _tableRepository.UpdateTableAsync(availableTable.Id, availableTable);

            _ = Task.Run(async () =>
            {
                var delay = (endTime - DateTime.Now).TotalMilliseconds;
                if (delay > 0)
                {
                    await Task.Delay((int)delay);
                }

                availableTable.IsAvailable = true;
                await _tableRepository.UpdateTableAsync(availableTable.Id, availableTable);
            });

            return true;
        }

        public async Task DeleteReservationAsync(int reservationId)
        {
            await _reservationRepository.DeleteReservationAsync(reservationId);
        }

        public async Task UpdateReservationAsync(int reservationId, ReservationDTO reservationDTO)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(reservationId);

            if (reservation != null)
            {
                reservation.NumberOfGuests = reservationDTO.NumberOfGuests;
                reservation.BookingStart = reservationDTO.BookingStart;
                reservation.BookingEnd = reservationDTO.BookingEnd;
                reservation.FK_CustomerId = reservationDTO.FK_CustomerId;
                reservation.FK_RestaurantId = reservationDTO.FK_RestaurantId;
                reservation.FK_TableId = reservationDTO.FK_TableId;

                await _reservationRepository.UpdateReservationAsync(reservation);
            }
        }

        public async Task AddTableAsync(TableDTO tableDTO)
        {
            var table = new Table
            {
                TableNumber = tableDTO.TableNumber,
                AmountOfSeats = tableDTO.AmountOfSeats,
                FK_RestaurantId = tableDTO.FK_RestaurantId,
                IsAvailable = tableDTO.IsAvailable
            };

            await _tableRepository.AddTableAsync(table);
        }

        public async Task UpdateTableAsync(int tableId, TableDTO tableDTO)
        {
            var table = new Table
            {
                Id = tableId,
                TableNumber = tableDTO.TableNumber,
                AmountOfSeats = tableDTO.AmountOfSeats,
                FK_RestaurantId = tableDTO.FK_RestaurantId,
                IsAvailable = tableDTO.IsAvailable
            };

            await _tableRepository.UpdateTableAsync(tableId, table);
        }

        public async Task DeleteTableAsync(int tableId)
        {
            await _tableRepository.DeleteTableAsync(tableId);
        }

        public async Task<IEnumerable<ReservationDTO>> ViewAllReservations()
        {
            var reservations = await _reservationRepository.ViewAllReservationsAsync();

            return reservations.Select(r => new ReservationDTO
            {
                FK_CustomerId=r.FK_CustomerId,
                FK_RestaurantId=r.FK_RestaurantId,
                BookingStart=r.BookingStart,
                BookingEnd=r.BookingEnd,
                NumberOfGuests=r.NumberOfGuests
            }).ToList();
        }
    }
}
