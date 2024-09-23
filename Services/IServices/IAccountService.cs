using Restaurant.Models;
using Restaurant.Models.DTOs.AccountDTOs;

namespace Restaurant.Services.IServices
{
    public interface IAccountService
    {
        Task AddAccountAsync(NewAccountDTO accountDTO);
        Task DeleteAccountAsync(int accountId);
        Task UpdateAccountAsync(int accountId, UpdateAccountDTO accountDTO);
        Task<string> LogInAsync(LogInDTO logInDTO);
    }
}
