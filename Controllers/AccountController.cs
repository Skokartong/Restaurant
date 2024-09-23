using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        [Route("/register")]
        public IActionResult NewAccount()
        {

        }

        [HttpPost]
        [Route("/login")]
        public IActionResult LogIn()
        {

        }

        [HttpPut]
        [Route("/updateaccount")]
        public IActionResult UpdateAccount()
        {

        }

        [HttpDelete]
        [Route("/deleteaccount")]
        public IActionResult DeleteAccount()
        {

        }
    }
}
