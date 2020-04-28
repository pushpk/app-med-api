using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;
using System.Collections.Generic;

namespace MedAPI.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool DeleteUserById(long id)
        {
            return userRepository.DeleteUserById(id);
        }

        public List<User> GetAllUser()
        {
            return userRepository.GetAllUser();
        }

        public User GetUserById(long id)
        {
            return userRepository.GetUserById(id);
        }

        public User GetByEmail(string email)
        {
            return userRepository.GetByEmail(email);
        }
        public User SaveUser(User mUser)
        {
            if (mUser.Id == 0)
            {
                mUser.PasswordHash = Infrastructure.HashPasswordHelper.HashPassword(mUser.PasswordHash);
            }
            return userRepository.SaveUser(mUser);
        }

        
    }
}
