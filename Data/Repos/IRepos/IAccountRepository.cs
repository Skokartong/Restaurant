using Restaurant.Models;

namespace Restaurant.Data.Repos.IRepos
{
    public interface IAccountRepository
    {
        Task AddAccountAsync(Account account);
        Task DeleteAccountAsync(int accountId);
        Task UpdateAccountAsync(int accountId, Account updatedAccount);
        Task<bool> AccountExistsByEmailAsync(string email);
        Task<bool> AccountExistsByUsernameAsync(string username);
        Task<bool> UserHasRoleAsync(int accountId, string role);
    }
}
