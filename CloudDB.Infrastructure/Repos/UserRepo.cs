using CloudDB.Domain.DTO;
using CloudDB.Domain.Entities;
using CloudDB.Infrastructure.Identity;
using CloudDB.Infrastructure.Interfaces;

namespace CloudDB.Infrastructure.Repos
{
    public class UserRepo : IUserRepo
    {
        public void AddUser(UserCreateDTO user)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserCreateDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
