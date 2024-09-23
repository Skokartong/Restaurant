using Restaurant.Models;
using Restaurant.Models.DTOs.AccountDTOs;

namespace Restaurant.Services.IServices
{
    public interface IAccountService
    {
        Task<AccountDTO> GetAccountByUsername(string username);
        Task<AccountDTO> GetAccountById(int accountId);
        Task<bool> AccountExistsByEmail(string email);
        Task<bool> AccountExistsByUsername(string username);
        Task<bool> UserHasRole(int accountId, string role);
        Task CreateAccount(NewAccount account);
        Task UpdateAccount(UpdateAccount account);
        Task DeleteAccount(int accountId);
    }
}
