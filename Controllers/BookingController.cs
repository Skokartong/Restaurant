using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.DTOs;
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
            return Ok(bookings);
        }

        [HttpPost]
        [Route("/booktable")]
        public async Task<IActionResult> BookTable(int restaurantId, int customerId, DateTime startTime, DateTime endTime, int numberOfGuests)
        {
            try
            {
                await _bookingService.BookTableAsync(restaurantId, customerId, startTime, endTime, numberOfGuests);
                return Ok(new { message = "Table booked successfully" });
            }
            catch 
            {
                return BadRequest(new { message = "No tables available"});
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
        public async Task<IActionResult> UpdateReservation(int reservationId,[FromBody] ReservationDTO reservationDTO)
        {
            await _bookingService.UpdateReservationAsync(reservationId, reservationDTO);
            return NoContent(); 
        }

        [HttpPost]
        [Route("/addtable")]
        public async Task<IActionResult> AddTable([FromBody] TableDTO tableDTO)
        {
            await _bookingService.AddTableAsync(tableDTO);
            return CreatedAtAction(nameof(AddTable), tableDTO); 
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

