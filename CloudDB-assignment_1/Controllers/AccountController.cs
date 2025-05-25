using CloudDB.Core.Interfaces;
using CloudDB.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            var token = await _accountService.Login(user);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/register")]
        public async Task<IActionResult> Register(UserCreateDTO user)
        {
            var result = await _accountService.Register(user, "RegularUser");

            if (!result) return BadRequest();

            return Ok("User created");
        }

        [HttpPost]
        [Authorize]
        [Route("api/update-user")]
        public async Task<IActionResult> Update(UserUpdateDTO user)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null) return Unauthorized("No User ID found");

            var result = await _accountService.Update(user, userId);

            if (result)
            {
                return Ok("Uppdaterad");

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("api/get-user")]
        [Authorize]
        public async Task<IActionResult> GetUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null) return Unauthorized("No User ID found");

            var result = await _accountService.GetUser(userId);

            if (result == null) return NotFound("Username or password incorrect");

            return Ok(result);
        }

        //[HttpGet]
        //[Authorize(Roles = "PremiumUser")]
        //[Route("api/test-role")]
        //public async Task<IActionResult> TestRole()
        //{
        //    return Ok("Role is working");
        //}

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("api/upgrade-user")]
        public async Task<IActionResult> UpgradeUser(string userId)
        {
            await _accountService.ChangeUserRole(userId, "PremiumUser");

            return Ok("User is premium");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("api/downgrade-user")]
        public async Task<IActionResult> DowngradeUser(string userId)
        {
            await _accountService.ChangeUserRole(userId, "RegularUser");

            return Ok("User is regular");
        }
    }
}
