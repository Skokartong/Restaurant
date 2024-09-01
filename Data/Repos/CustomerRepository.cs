using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Repos.IRepos;
using Restaurant.Models;

namespace Restaurant.Data.Repos
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly RestaurantContext _context;
        public CustomerRepository(RestaurantContext context)
        {
            _context = context;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var deleteCustomer = await _context.Customers.FindAsync(customerId);

            if(deleteCustomer!=null)
            {
                _context.Customers.Remove(deleteCustomer);
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(int customerId, Customer updatedCustomer)
        {
            var customer = await _context.Customers.FindAsync(customerId);

            if(customer!=null)
            {
                customer.Name = updatedCustomer.Name;
                customer.Phone = updatedCustomer.Phone;
                customer.Email = updatedCustomer.Email;

                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Customer>> SeeAllCustomersAsync (string restaurantName)
        {
            return await _context.Customers
                .Include(c => c.Restaurant)
                .Where(c => c.Restaurant.RestaurantName == restaurantName)
                .ToListAsync();
        }

        public async Task<Customer> SearchCustomerAsync (int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            return customer;
        }
    }
}
