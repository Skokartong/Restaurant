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

        // Admin Controller
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

        [HttpGet]
        [Route("/bookings/{customerId}")]
        public async Task<IActionResult> GetBookingsForCustomer(int customerId)
        {
            try
            {
                var bookings = await _bookingService.GetReservationsByCustomerAsync(customerId);
                if (bookings == null || !bookings.Any())
                {
                    return NotFound(new { Message = "No bookings found for this customer." });
                }

                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred.", Error = ex.Message });
            }
        }

        // Menu Controller
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
        public async Task<IActionResult> BookTable([FromBody] AddReservationDTO reservationDTO)
        {
            try
            {
                var result = await _bookingService.BookTableAsync(reservationDTO);

                return Created("", new { message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Customer Controller
        [HttpDelete]
        [Route("/deletebooking/{reservationId}")]
        public async Task<IActionResult> DeleteReservation(int reservationId)
        {
            await _bookingService.DeleteReservationAsync(reservationId);
            return NoContent();
        }

        // Customer Controller
        [HttpPut]
        [Route("/updatebooking/{reservationId}")]
        public async Task<IActionResult> UpdateReservation(int reservationId,[FromBody] UpdateReservationDTO reservationDTO)
        {
            await _bookingService.UpdateReservationAsync(reservationId, reservationDTO);
            return NoContent(); 
        }

        // Admin Controller
        [HttpGet]
        [Route("/viewtables/{restaurantId}")]
        public async Task<IActionResult> ViewTables(int restaurantId)
        {
            var tables = await _bookingService.GetTablesByRestaurantIdAsync(restaurantId);

            if (tables == null || !tables.Any())
            {
                return NoContent(); 
            }

            return Ok(tables); 
        }

        // Admin Controller
        [HttpPost]
        [Route("/addtable")]
        public async Task<IActionResult> AddTable([FromBody] TableDTO tableDTO)
        {
            await _bookingService.AddTableAsync(tableDTO);
            return Created("", new {message = "Table created successfully"}); 
        }

        // Admin Controller
        [HttpPut]
        [Route("/updatetable/{tableId}")]
        public async Task<IActionResult> UpdateTable(int tableId,[FromBody] TableDTO tableDTO)
        {
            await _bookingService.UpdateTableAsync(tableId, tableDTO);
            return NoContent(); 
        }

        // Admin Controller
        [HttpDelete]
        [Route("/deletetable/{tableId}")]
        public async Task<IActionResult> DeleteTable(int tableId)
        {
            await _bookingService.DeleteTableAsync(tableId);
            return NoContent(); 
        }
    }
}

