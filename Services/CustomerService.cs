using Restaurant.Data.Repos.IRepos;
using Restaurant.Models;
using Restaurant.Models.DTOs;
using Restaurant.Services.IServices;

namespace Restaurant.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task AddCustomerAsync(CustomerDTO customerDTO)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerDTO> SearchCustomerAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomerDTO>> SeeAllCustomersAsync(string restaurantName)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerDTO> UpdateCustomerAsync(int customerId, Customer updatedCustomer)
        {
            throw new NotImplementedException();
        }
    }
}
