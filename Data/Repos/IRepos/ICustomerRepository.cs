using Restaurant.Models;

namespace Restaurant.Data.Repos.IRepos
{
    public interface ICustomerRepository
    {
        Task AddCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int customerId);
        Task UpdateCustomerAsync(int customerId, Customer updatedCustomer);
        Task<IEnumerable<Customer>> SeeAllCustomersAsync(string restaurantName);
        Task<Customer> SearchCustomerAsync(int customerId);
    }
}
