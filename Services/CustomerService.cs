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
                FK_RestaurantId = customer.FK_RestaurantId
            };
        }

        public async Task<IEnumerable<CustomerDTO>> SeeAllCustomersAsync(string restaurantName)
        {
            var customersList = await _customerRepository.SeeAllCustomersAsync(restaurantName);

            if (customersList==null)
            {
                throw new InvalidOperationException($"There is no customers at {restaurantName}");
            }

            return customersList.Select(c => new CustomerDTO
            {
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                FK_RestaurantId = c.FK_RestaurantId

            }).ToList();
        }

        public async Task<CustomerDTO> UpdateCustomerAsync(int customerId, CustomerDTO updatedCustomerDTO)
        {
            var updatedCustomer = new Customer
            {
                Id = customerId,
                Name = updatedCustomerDTO.Name,
                Phone = updatedCustomerDTO.Phone,
                Email = updatedCustomerDTO.Email,
            };

            await _customerRepository.UpdateCustomerAsync(customerId, updatedCustomer);

            return new CustomerDTO
            {
                Name = updatedCustomer.Name,
                Phone = updatedCustomer.Phone,
                Email = updatedCustomer.Email,
                FK_RestaurantId = updatedCustomer.FK_RestaurantId
            };
        }
    }
}
