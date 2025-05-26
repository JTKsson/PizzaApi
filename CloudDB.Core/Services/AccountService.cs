using CloudDB.Core.Interfaces;
using CloudDB.Domain.DTO;
using CloudDB.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CloudDB.Core.Services
{
    public class AccountService : IAccountService
    {

        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;


        public AccountService(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager, IConfiguration config, 
            RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
            _roleManager = roleManager;
        }
        public async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            var authClaims = new List<Claim>
    {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var authSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["JWT-Secret-Key"]));

            var token = new JwtSecurityToken(
                issuer: _config["IssuerAudiens"],
                audience: _config["IssuerAudiens"],
                expires: DateTime.UtcNow.AddHours(10),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<string> Login(UserLoginDTO user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, false);
            if (!result.Succeeded)
                return null;

            var appUser = await _userManager.FindByNameAsync(user.Username);
            if (appUser == null)
                return null;

            return await GenerateJwtToken(appUser);
        }

        public async Task<bool> Register(UserCreateDTO user, string role)
        {
            var newUser = new ApplicationUser()
            {
                Email = user.Email,
                UserName = user.Username,
                PhoneNumber = user.Phone,
            };

            var result = await _userManager.CreateAsync(newUser, user.Password);

            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
                await _userManager.AddToRoleAsync(newUser, role);
            }

            return result.Succeeded;
        }


        public async Task<bool> Update(UserUpdateDTO user, string userId)
        {
            var existingUser = await _userManager.FindByIdAsync(userId);
            if (existingUser == null)
                return false;

            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.Phone;
            existingUser.UserName = user.Username;

            var result = await _userManager.UpdateAsync(existingUser);

            return result.Succeeded;
        }

        public async Task<UserGetDTO> GetUser(string userId)
        {
            var authedUser = await _userManager.FindByIdAsync(userId);

            if (authedUser == null)
                return null;

            return new UserGetDTO
            {
                Username = authedUser.UserName,
                Email = authedUser.Email,
                Phone = authedUser.PhoneNumber
            };
        }

        public async Task<bool> ChangeUserRole(string userId, string newRole)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return false;

            var currentRoles = await _userManager.GetRolesAsync(user);

            if (currentRoles.Any())
            {
                var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
                if (!removeResult.Succeeded)
                    return false;
            }

            if (!await _roleManager.RoleExistsAsync(newRole))
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(newRole));
                if (!roleResult.Succeeded)
                    return false;
            }

            var addResult = await _userManager.AddToRoleAsync(user, newRole);
            return addResult.Succeeded;
        }

    }
}
