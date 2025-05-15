using CloudDB.Domain.DTO;

namespace CloudDB.Core.Interfaces
{
    public interface IAccountService
    {
        Task<bool> Register(UserCreateDTO user);
        Task<bool> Login(UserLoginDTO user);
        Task<bool> Update(UserUpdateDTO user);
    }
}
