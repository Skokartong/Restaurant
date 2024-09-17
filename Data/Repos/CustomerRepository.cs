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
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Customer?> SearchCustomerAsync(int customerId)
        {
            return await _context.Customers.FindAsync(customerId);
        }

        public async Task UpdateCustomerAsync(Customer updatedCustomer)
        {
                _context.Customers.Update(updatedCustomer);
                await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> SeeAllCustomersAsync ()
        {
            return await _context.Customers
                .ToListAsync();
        }
    }
}
