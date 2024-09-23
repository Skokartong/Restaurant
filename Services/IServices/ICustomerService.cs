using Restaurant.Models;
using Restaurant.Models.DTOs.CustomerDTOs;

namespace Restaurant.Services.IServices
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(CustomerDTO customerDTO);
        Task DeleteCustomerAsync(int customerId);
        Task<CustomerDTO> UpdateCustomerAsync(int customerId, CustomerDTO customerDTO);
        Task<IEnumerable<CustomerDTO>> SeeAllCustomersAsync();
        Task<CustomerDTO> SearchCustomerAsync(int customerId);
    }
}
