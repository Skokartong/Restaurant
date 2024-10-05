using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Data.Repos.IRepos;
using Restaurant.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Restaurant.Data.Repos
{
    public class AccountRepository : IAccountRepository
    {
        private readonly RestaurantContext _context;

        public AccountRepository(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<Account?> AccountExistsByEmailAsync(string email)
        {
            var existingAccount = await _context.Accounts.SingleOrDefaultAsync(a => a.Email == email);
            return existingAccount;
        }

        public async Task<Account?> AccountExistsByUsernameAsync(string username)
        {
            var existingAccount = await _context.Accounts.SingleOrDefaultAsync(a => a.UserName == username);
            return existingAccount;
        }

        public async Task AddAccountAsync(Account account)
        {
            await _context.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccountAsync(int accountId)
        {
            var existingAccount = await _context.Accounts.FindAsync(accountId);

            if (existingAccount != null)
            {
                _context.Accounts.Remove(existingAccount);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Account>> GetAllAccountsAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account?> GetAccountByIdAsync(int accountId)
        {
            return await _context.Accounts.FindAsync(accountId);
        }

        public async Task UpdateAccountAsync(int accountId, Account updatedAccount)
        {
            var existingAccount = await _context.Accounts.FindAsync(accountId);

            if (existingAccount != null)
            {
                existingAccount.UserName = updatedAccount.UserName;
                existingAccount.Email = updatedAccount.Email;
                existingAccount.PasswordHash = updatedAccount.PasswordHash;

                await _context.SaveChangesAsync();
            }
        }
    }
}
