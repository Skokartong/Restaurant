using Restaurant.Models;

namespace Restaurant.Data.Repos.IRepos
{
    public interface ICustomerRepository
    {
        Task AddCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int customerId);
        Task UpdateCustomerAsync(Customer updatedCustomer);
        Task<IEnumerable<Customer>> SeeAllCustomersAsync();
        Task<Customer?> SearchCustomerAsync(int customerId);
    }
}
