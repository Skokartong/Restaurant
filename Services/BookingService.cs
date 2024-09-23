using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Restaurant.Data.Repos;
using Restaurant.Data.Repos.IRepos;
using Restaurant.Models;
using Restaurant.Models.DTOs;
using Restaurant.Models.DTOs.ReservationDTOs;
using Restaurant.Models.DTOs.RestaurantDTOs;
using Restaurant.Models.DTOs.TableDTOs;
using Restaurant.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public class BookingService : IBookingService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ITableRepository _tableRepository;
        private readonly ICustomerRepository _customerRepository;

        public BookingService(IReservationRepository reservationRepository, ITableRepository tableRepository, ICustomerRepository customerRepository)
        {
            _reservationRepository = reservationRepository;
            _tableRepository = tableRepository;
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<TableDTO>> CheckAvailabilityAsync(AvailabilityCheckDTO checkDTO)
        {
            var availableTables = await _tableRepository.GetAvailableTablesAsync(
                checkDTO.RestaurantId,
                checkDTO.StartTime,
                checkDTO.EndTime,
                checkDTO.NumberOfGuests
            );

            return availableTables.Select(t => new TableDTO
            {
                Id = t.Id,
                TableNumber = t.TableNumber,
                AmountOfSeats = t.AmountOfSeats,
                FK_RestaurantId = t.FK_RestaurantId
            }).ToList();
        }

        public async Task BookTableAsync(AddReservationDTO reservationDTO, int customerId, int restaurantId)
        {
            var availableTables = await CheckAvailabilityAsync(new AvailabilityCheckDTO
            {
                RestaurantId = restaurantId,
                StartTime = reservationDTO.BookingStart,
                EndTime = reservationDTO.BookingEnd,
                NumberOfGuests = reservationDTO.NumberOfGuests
            });

            var selectedTable = availableTables.FirstOrDefault();

            if (selectedTable == null)
            {
                throw new Exception("No available tables found for the selected time and number of guests.");
            }

            var reservation = new Reservation
            {
                NumberOfGuests = reservationDTO.NumberOfGuests,
                BookingStart = reservationDTO.BookingStart,
                BookingEnd = reservationDTO.BookingEnd,
                Message = reservationDTO.Message,
                FK_CustomerId = customerId,
                FK_RestaurantId = restaurantId,
                FK_TableId = selectedTable.Id
            };

            var customer = await _customerRepository.SearchCustomerAsync(customerId);
            if (customer != null)
            {
                customer.FK_RestaurantId = restaurantId;
                await _customerRepository.UpdateCustomerAsync(customer);
            }

            await _reservationRepository.AddReservationAsync(reservation);
        }

        public async Task DeleteReservationAsync(int reservationId)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(reservationId);

            if (reservation != null)
            {
                await _reservationRepository.DeleteReservationAsync(reservationId);
            }
        }

        public async Task UpdateReservationAsync(int reservationId, UpdateReservationDTO reservationDTO)
        {
            var existingReservation = await _reservationRepository.GetReservationByIdAsync(reservationId);

            if (existingReservation == null)
            {
                throw new Exception("Reservation not found.");
            }

            existingReservation.NumberOfGuests = reservationDTO.NumberOfGuests;
            existingReservation.BookingStart = reservationDTO.BookingStart;
            existingReservation.BookingEnd = reservationDTO.BookingEnd;
            existingReservation.Message = reservationDTO.Message;

            if (!string.IsNullOrEmpty(reservationDTO.Message))
            {
                existingReservation.Message = reservationDTO.Message;
            }

            await _reservationRepository.UpdateReservationAsync(existingReservation);
        }


        public async Task<Models.Table> AddTableAsync(TableDTO tableDTO)
        {
            var table = new Models.Table
            {
                Id = tableDTO.Id,
                TableNumber = tableDTO.TableNumber,
                AmountOfSeats = tableDTO.AmountOfSeats,
                FK_RestaurantId = tableDTO.FK_RestaurantId,
            };

            await _tableRepository.AddTableAsync(table);

            return table;
        }

        public async Task UpdateTableAsync(int tableId, TableDTO tableDTO)
        {
            var table = new Models.Table
            {
                Id = tableId,
                TableNumber = tableDTO.TableNumber,
                AmountOfSeats = tableDTO.AmountOfSeats,
                FK_RestaurantId = tableDTO.FK_RestaurantId,
            };

            await _tableRepository.UpdateTableAsync(tableId, table);
        }

        public async Task DeleteTableAsync(int tableId)
        {
            await _tableRepository.DeleteTableAsync(tableId);
        }

        public async Task<IEnumerable<ViewReservationDTO>> ViewAllReservationsAsync()
        {
            var reservations = await _reservationRepository.ViewAllReservationsAsync();

            return reservations.Select(r => new ViewReservationDTO
            {
                CustomerName = r.Customer?.Name?? "",
                RestaurantName = r.Restaurant?.RestaurantName?? "",
                NumberOfGuests = r.NumberOfGuests,
                BookingStart = r.BookingStart,
                BookingEnd = r.BookingEnd,
                Message = r.Message
            }).ToList();
        }
    }
}
