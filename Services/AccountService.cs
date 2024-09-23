using Restaurant.Data.Repos.IRepos;
using Restaurant.Models.DTOs.AccountDTOs;
using Restaurant.Services.IServices;

namespace Restaurant.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Task<bool> AccountExistsByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AccountExistsByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task CreateAccount(NewAccount account)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAccount(int accountId)
        {
            throw new NotImplementedException();
        }

        public Task<AccountDTO> GetAccountById(int accountId)
        {
            throw new NotImplementedException();
        }

        public Task<AccountDTO> GetAccountByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAccount(UpdateAccount account)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserHasRole(int accountId, string role)
        {
            throw new NotImplementedException();
        }
    }
}
