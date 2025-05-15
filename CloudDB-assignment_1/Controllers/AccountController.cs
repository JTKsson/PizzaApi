using CloudDB.Core.Interfaces;
using CloudDB.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloudDB_assignment_1.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("api/login")]
        public async Task<IActionResult> Login(UserLoginDTO user)
        {
            var result = await _accountService.Login(user);

            if (result)
            {
                return Ok("Inloggad");

            }
            else
            {
                return Unauthorized();
            }

        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/register")]
        public async Task<IActionResult> Register(UserCreateDTO user)
        {
            var result = await _accountService.Register(user); //GLÖM INTE AWAIT!

            if (result)
            {
                return Ok("Skapad");

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/update-user")]
        public async Task<IActionResult> Update(UserUpdateDTO user)
        {
            var result = await _accountService.Update(user);

            if (result)
            {
                return Ok("Uppdaterad");

            }
            else
            {
                return BadRequest();
            }
        }


    }
}
