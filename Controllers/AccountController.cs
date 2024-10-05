using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.DTOs.AccountDTOs;
using Restaurant.Services.IServices;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("/accounts")]
        public async Task<IActionResult> GetAllAccounts()
        {
            var accounts = await _accountService.GetAllAccountsAsync();
            return Ok(accounts);
        }

        [HttpGet]
        [Route("/accounts/{accountId}")]
        public async Task<IActionResult> GetAccountById(int accountId)
        {
            var account = await _accountService.GetAccountByIdAsync(accountId);
            if (account == null)
            {
                return NotFound(new { message = "Account not found" });
            }
            return Ok(account);
        }

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> NewAccount([FromBody] NewAccountDTO accountDTO)
        {
            try
            {
                await _accountService.AddAccountAsync(accountDTO);
                return Created("", new { message = "Account created successfully" });
            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("Email is already taken"))
                {
                    return BadRequest("Email is already taken");
                }
                if (ex.Message.Contains("Username is already taken"))
                {
                    return BadRequest("Username is already taken");
                }

                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> LogIn([FromBody] LogInDTO logInDTO)
        {
            string token = await _accountService.LogInAsync(logInDTO);
            return Ok(new { token });
        }

        [HttpPut]
        [Route("/updateaccount/{accountId}")]
        public async Task<IActionResult> UpdateAccount(int accountId, [FromBody] UpdateAccountDTO accountDTO)
        {
            await _accountService.UpdateAccountAsync(accountId, accountDTO);
            return Ok(new { message = "Account updated successfully" });
        }

        [HttpDelete]
        [Route("/deleteaccount/{accountId}")]
        public async Task<IActionResult> DeleteAccount(int accountId)
        {
            await _accountService.DeleteAccountAsync(accountId);
            return Ok(new { message = "Account deleted successfully" });
        }
    }
}
