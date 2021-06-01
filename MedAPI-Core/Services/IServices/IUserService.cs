using Repository.DTOs;
using System.Collections.Generic;
using System.Security.Claims;

namespace Services.IServices
{
    public interface IUserService
    {
        User GetCurrentUser(ClaimsPrincipal principal);
        List<User> GetAllUser();
        User GetUserById(long id);
        bool DeleteUserById(long id);
        User GetByEmail(string email);
        User SaveUser(User mUser);
        UserResources GetResources();
        User Authenticate(string email, string password);
        User Credentials(string email);
        List<Medic> GetAllNonApprovedMedics();
        User ConfirmEmail(string id, string token);
        User GetUserByEmail(string email);
        bool IsUserAlreadyExist(User mUser, string cmp = null);
        List<Lab> GetAllNonApprovedLabs();
        bool ResetPassword(string id, string token, string passwordHash, bool isUserForgotPassword = true, string oldPasswordHash = null);
    }
}
