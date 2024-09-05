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
            var customer = new Customer
            {
                Name = customerDTO.Name,
                Phone = customerDTO.Phone,
                Email = customerDTO.Email,
            };

            await _customerRepository.AddCustomerAsync(customer);
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            await _customerRepository.DeleteCustomerAsync(customerId);
        }

        public async Task<CustomerDTO> SearchCustomerAsync(int customerId)
        {
            var customer = await _customerRepository.SearchCustomerAsync(customerId);

            if (customer==null)
            {
                throw new InvalidOperationException($"Customer with id {customerId} not found");
            }

            return new CustomerDTO
            {
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
            };
        }

        public async Task<IEnumerable<CustomerDTO>> SeeAllCustomersAsync()
        {
            var customersList = await _customerRepository.SeeAllCustomersAsync();

            if (customersList==null)
            {
                throw new InvalidOperationException($"There is no customers");
            }

            return customersList.Select(c => new CustomerDTO
            {
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone
            }).ToList();
        }

        public async Task<CustomerDTO> UpdateCustomerAsync(int customerId, CustomerDTO customerDTO)
        {
            await _customerRepository.SearchCustomerAsync(customerId);

            var updatedCustomer = new Customer
            {
                Id = customerId,
                Name = customerDTO.Name,
                Phone = customerDTO.Phone,
                Email = customerDTO.Email,
            };

            await _customerRepository.UpdateCustomerAsync(updatedCustomer);

            return new CustomerDTO
            {
                Name = updatedCustomer.Name,
                Phone = updatedCustomer.Phone,
                Email = updatedCustomer.Email
            };
        }
    }
}
