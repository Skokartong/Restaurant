using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.DTOs;
using Restaurant.Models.DTOs.ReservationDTOs;
using Restaurant.Models.DTOs.RestaurantDTOs;
using Restaurant.Models.DTOs.TableDTOs;
using Restaurant.Services.IServices;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        [Route("/allbookings")]
        public async Task<IActionResult> ViewBookings()
        {
            var bookings = await _bookingService.ViewAllReservationsAsync();

            if (bookings == null || !bookings.Any())
            {
                return NoContent(); 
            }

            return Ok(bookings);
        }

        [HttpPost]
        [Route("/checkavailability")]
        public async Task<IActionResult> CheckAvailability([FromBody] AvailabilityCheckDTO checkDTO)
        {
            try
            {
                var availableTables = await _bookingService.CheckAvailabilityAsync(checkDTO);
                if (availableTables == null || !availableTables.Any())
                {
                    return NoContent(); 
                }
                return Ok(availableTables); 
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("/booktable")]
        public async Task<IActionResult> BookTable([FromBody] AddReservationDTO reservationDTO, int customerId, int restaurantId)
        {
            try
            {
                await _bookingService.BookTableAsync(reservationDTO, customerId, restaurantId);
                return Created("", new { message = "Table booked successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("/deletebooking/{reservationId}")]
        public async Task<IActionResult> DeleteReservation(int reservationId)
        {
            await _bookingService.DeleteReservationAsync(reservationId);
            return NoContent();
        }

        [HttpPut]
        [Route("/updatebooking/{reservationId}")]
        public async Task<IActionResult> UpdateReservation(int reservationId,[FromBody] UpdateReservationDTO reservationDTO)
        {
            await _bookingService.UpdateReservationAsync(reservationId, reservationDTO);
            return NoContent(); 
        }

        [HttpPost]
        [Route("/addtable")]
        public async Task<IActionResult> AddTable([FromBody] TableDTO tableDTO)
        {
            await _bookingService.AddTableAsync(tableDTO);
            return Created("", new {message = "Table created successfully"}); 
        }

        [HttpPut]
        [Route("/updatetable/{tableId}")]
        public async Task<IActionResult> UpdateTable(int tableId,[FromBody] TableDTO tableDTO)
        {
            await _bookingService.UpdateTableAsync(tableId, tableDTO);
            return NoContent(); 
        }

        [HttpDelete]
        [Route("/deletetable/{tableId}")]
        public async Task<IActionResult> DeleteTable(int tableId)
        {
            await _bookingService.DeleteTableAsync(tableId);
            return NoContent(); 
        }
    }
}

