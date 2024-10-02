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

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> NewAccount([FromBody] NewAccountDTO accountDTO)
        {
            await _accountService.AddAccountAsync(accountDTO);
            return Created("", new {message = "Account created successfully" });
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
