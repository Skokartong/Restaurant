using Restaurant.Models;

namespace Restaurant.Data.Repos.IRepos
{
    public interface IAccountRepository
    {
        Task AddAccountAsync(Account account);
        Task DeleteAccountAsync(int accountId);
        Task UpdateAccountAsync(int accountId, Account updatedAccount);
        Task<Account> FindAccountByIdAsync(int accountId);
        Task<Account?> AccountExistsByEmailAsync(string email);
        Task<Account?> AccountExistsByUsernameAsync(string username);
    }
}
