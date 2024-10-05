using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.DTOs.CustomerDTOs;
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
        [Route("/addcustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDTO customerDTO)
        {
            await _customerService.AddCustomerAsync(customerDTO);
            return Created("", customerDTO);
        }

        [HttpDelete]
        [Route("/deletecustomer")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            await _customerService.DeleteCustomerAsync(customerId);
            return Ok(new { Message = $"Customer with ID {customerId} has been deleted." });
        }

        [HttpGet]
        [Route("/viewcustomer/{customerId}")]
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
        [Route("/viewcustomers")]
        public async Task<IActionResult> SeeAllCustomers()
        {
            var customers = await _customerService.SeeAllCustomersAsync();

            if (customers == null || !customers.Any())
            {
                return NotFound(new { Message = "No customers found for the specified restaurant" });
            }

            return Ok(customers);
        }

        [HttpPut]
        [Route("/updatecustomer/{customerId}")]
        public async Task<IActionResult> UpdateCustomer(int customerId,[FromBody] CustomerDTO customerDTO)
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
