using System.Collections.Generic;
using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;

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
    }
}
