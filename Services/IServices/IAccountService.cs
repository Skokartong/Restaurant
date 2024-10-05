using Restaurant.Models;
using Restaurant.Models.DTOs.AccountDTOs;

namespace Restaurant.Services.IServices
{
    public interface IAccountService
    {
        Task AddAccountAsync(NewAccountDTO accountDTO);
        Task DeleteAccountAsync(int accountId);
        Task UpdateAccountAsync(int accountId, UpdateAccountDTO accountDTO);
        Task<List<Account>> GetAllAccountsAsync();
        Task<Account?> GetAccountByIdAsync(int accountId);
        Task<string> LogInAsync(LogInDTO logInDTO);
    }
}
