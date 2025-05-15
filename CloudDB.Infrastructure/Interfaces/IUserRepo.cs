using CloudDB.Domain.DTO;
using CloudDB.Domain.Entities;
using CloudDB.Infrastructure.Identity;

namespace CloudDB.Infrastructure.Interfaces
{
    public interface IUserRepo
    {
        public void AddUser(UserCreateDTO user);
        public void UpdateUser(UserCreateDTO user);
        public ApplicationUser GetUserById(int id);
    }
}
