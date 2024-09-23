using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Repos.IRepos;
using Restaurant.Models;

namespace Restaurant.Data.Repos
{
    public class AccountRepository : IAccountRepository
    {
        private readonly RestaurantContext _context;

        public AccountRepository(RestaurantContext context)
        {
            _context = context;
        }

        // Checking if email already is registred when new user 
        public async Task<bool> AccountExistsByEmailAsync(string email)
        {
            return await _context.Accounts.AnyAsync(a => a.Email == email);
        }

        // Checking if username already is registred when new user 
        public async Task<bool> AccountExistsByUsernameAsync(string username)
        {
            return await _context.Accounts.AnyAsync(a => a.UserName == username);
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

        public async Task UpdateAccountAsync(int accountId, Account updatedAccount)
        {
            var existingAccount = await _context.Accounts.FindAsync(accountId);

            if (existingAccount != null)
            {
                _context.Accounts.Update(updatedAccount);
                await _context.SaveChangesAsync();
            };
        }

        public async Task<bool> UserHasRoleAsync(int accountId, string role)
        {
            throw new NotImplementedException();
        }
    }
}
