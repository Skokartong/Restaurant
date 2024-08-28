using Restaurant.Models;
using Restaurant.Models.DTOs;

namespace Restaurant.Services.IServices
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(CustomerDTO customerDTO);
        Task DeleteCustomerAsync(int customerId);
        Task<CustomerDTO> UpdateCustomerAsync(int customerId, Customer updatedCustomer);
        Task<IEnumerable<CustomerDTO>> SeeAllCustomersAsync(string restaurantName);
        Task<CustomerDTO> SearchCustomerAsync(int customerId);
    }
}
