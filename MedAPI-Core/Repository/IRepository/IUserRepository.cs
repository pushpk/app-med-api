using Repository.DTOs;
using System.Collections.Generic;

namespace Repository.IRepository
{
    public interface IUserRepository
    {
        List<User> GetAllUser();
        User GetUserById(long id);
        bool DeleteUserById(long id);
        User GetByEmail(string email);
        User SaveUser(User mUser);
        User Authenticate(string email);
        List<Medic> GetAllNonApprovedMedics();
        User ConfirmEmail(string userId, string token);
        bool UpdatePassword(string userId, string token, string password);
        bool IsUserAlreadyExist(User mUser, string cmp = null);
        List<Lab> GetAllNonApprovedLabs();
        bool ResetPassword(string userId, string oldPasswordHash, string passwordHash);
    }
}
