using CloudDB.Domain.DTO;

namespace CloudDB.Core.Interfaces
{
    public interface IAccountService
    {
        Task<bool> Register(UserCreateDTO user);
        Task<string> Login(UserLoginDTO user);
        Task<bool> Update(UserUpdateDTO user, string userId);
        Task<UserGetDTO> GetUser(string userId);
    }
}
