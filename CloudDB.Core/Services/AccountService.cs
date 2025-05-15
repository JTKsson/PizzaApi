using CloudDB.Core.Interfaces;
using CloudDB.Domain.DTO;
using CloudDB.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CloudDB.Core.Services
{
    public class AccountService : IAccountService
    {

        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;

        public AccountService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> Login(UserLoginDTO user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, false);
            return result.Succeeded;
        }

        public async Task<bool> Register(UserCreateDTO user)
        {
            var newUser = new ApplicationUser()
            {
                Email = user.Email,
                UserName = user.Username,
                PhoneNumber = user.Phone,
            };

            var result = await _userManager.CreateAsync(newUser, user.Password);

            return result.Succeeded;
        }

        public async Task<bool> Update(UserUpdateDTO user)
        {
            // Find the existing user by username
            var existingUser = await _userManager.FindByIdAsync(user.UserId);
            if (existingUser == null)
                return false;

            // Update the properties
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.Phone;
            existingUser.UserName = user.Username;

            var result = await _userManager.UpdateAsync(existingUser);

            return result.Succeeded;
        }
    }
}
