using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.DTOs;
using Restaurant.Services.IServices;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        [Route("/add")]
        public async Task<ActionResult> AddCustomer([FromBody] CustomerDTO customerDTO)
        {
            await _customerService.AddCustomerAsync(customerDTO);
            return Ok(customerDTO);
        }

        [HttpDelete]
        [Route("/delete")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            await _customerService.DeleteCustomerAsync(customerId);
            return Ok(new { Message = $"Customer with ID {customerId} has been deleted." });
        }

        [HttpGet]
        [Route("/{customerId}")]
        public async Task<IActionResult> SearchCustomer(int customerId)
        {
            var customer = await _customerService.SearchCustomerAsync(customerId);

            if (customer == null)
            {
                return NotFound(new { Message = "Customer not found" });
            }

            return Ok(customer);
        }

        [HttpGet]
        [Route("/view")]
        public async Task<IActionResult> SeeAllCustomers(string restaurantName)
        {
            var customers = await _customerService.SeeAllCustomersAsync(restaurantName);

            if (customers == null || !customers.Any())
            {
                return NotFound(new { Message = "No customers found for the specified restaurant" });
            }

            return Ok(customers);
        }

        [HttpPut]
        [Route("/update/{customerId}")]
        public async Task<IActionResult> UpdateCustomer(int customerId, [FromBody] CustomerDTO customerDTO)
        {
            var updatedCustomer = await _customerService.UpdateCustomerAsync(customerId, customerDTO);

            if (updatedCustomer == null)
            {
                return NotFound(new { Message = "Customer not found" });
            }

            return Ok(updatedCustomer);
        }
    }
}
