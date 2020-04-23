using MedAPI.Domain;
using System.Collections.Generic;

namespace MedAPI.Infrastructure.IRepository
{
    public interface IUserRepository
    {
        List<User> GetAllUser();
        User GetUserById(long id);
        bool DeleteUserById(long id);
        User GetByEmail(string email);
        User SaveUser(User mUser);
    }
}
