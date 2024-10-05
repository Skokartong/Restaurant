using Microsoft.IdentityModel.Tokens;
using Restaurant.Data.Repos.IRepos;
using Restaurant.Migrations;
using Restaurant.Models;
using Restaurant.Models.DTOs.AccountDTOs;
using Restaurant.Services.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Restaurant.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _configuration;

        public AccountService(IAccountRepository accountRepository, IConfiguration configuration)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
        }

        public async Task AddAccountAsync(NewAccountDTO accountDTO)
        {
            var existingEmail = await _accountRepository.AccountExistsByEmailAsync(accountDTO.Email);
            if (existingEmail != null)
            {
                throw new Exception("Email is already taken");
            }

            var existingUser = await _accountRepository.AccountExistsByUsernameAsync(accountDTO.UserName);
            if (existingUser != null)
            {
                throw new Exception("Username is already taken");
            }

            if (accountDTO.Password != accountDTO.ConfirmPassword)
            {
                throw new Exception("Passwords do not match");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(accountDTO.Password);

            var account = new Account
            {
                UserName = accountDTO.UserName,
                FirstName = accountDTO.FirstName,
                LastName = accountDTO.LastName,
                Email = accountDTO.Email,
                PasswordHash = passwordHash,
                Role = accountDTO.UserName == "admin" ? "Admin" : "User"
            };

            await _accountRepository.AddAccountAsync(account);
        }

        public async Task DeleteAccountAsync(int accountId)
        {
            await _accountRepository.DeleteAccountAsync(accountId);
        }

        public async Task UpdateAccountAsync(int accountId, UpdateAccountDTO accountDTO)
        {
            var existingAccount = await _accountRepository.GetAccountByIdAsync(accountId);

            if (existingAccount != null)
            {
                existingAccount.UserName = accountDTO.UserName;
                existingAccount.Email = accountDTO.Email;
                if (!string.IsNullOrEmpty(accountDTO.Password))
                {
                    existingAccount.PasswordHash = BCrypt.Net.BCrypt.HashPassword(accountDTO.Password);
                }

                await _accountRepository.UpdateAccountAsync(accountId, existingAccount);
            }
        }

        public async Task<List<Account>> GetAllAccountsAsync()
        {
            return await _accountRepository.GetAllAccountsAsync();
        }

        public async Task<Account?> GetAccountByIdAsync(int accountId)
        {
            return await _accountRepository.GetAccountByIdAsync(accountId);
        }

        public async Task<string> LogInAsync(LogInDTO logInDTO)
        {
            var existingUser = await _accountRepository.AccountExistsByUsernameAsync(logInDTO.UserName);

            if (existingUser == null || !BCrypt.Net.BCrypt.Verify(logInDTO.Password, existingUser.PasswordHash))
            {
                throw new Exception("Invalid username or password");
            }

            if (existingUser.UserName == "admin" && existingUser.Role == "Admin")
            {
                return GenerateJwtToken(existingUser, "Admin");
            }
            return GenerateJwtToken(existingUser, "User");
        }

        private string GenerateJwtToken(Account existingUser, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = _configuration["JwtKey"];
            var issuer = _configuration["JwtIssuer"];
            var audience = _configuration["JwtAudience"];

            Console.WriteLine($"Key: {key}");
            Console.WriteLine($"Issuer: {issuer}");
            Console.WriteLine($"Audience: {audience}");

            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience))
            {
                throw new Exception("JWT configuration values are missing.");
            }

            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, existingUser.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{existingUser.FirstName} {existingUser.LastName}"),
                new Claim(ClaimTypes.Email, existingUser.Email),
                new Claim("role", role)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(15),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
