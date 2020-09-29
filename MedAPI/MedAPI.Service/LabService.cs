using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;
using MedAPI.Repository;
using System.Collections.Generic;

namespace MedAPI.Service
{
    public class LabService : ILabService
    {
        private readonly ILabRepository labRepository;
        private readonly IUserRepository userRepository;
        public LabService(ILabRepository labRepository, IUserRepository userRepository)
        {
            this.labRepository = labRepository;
            this.userRepository = userRepository;
        }

      
        public Lab SaveLab(Domain.Lab mLab)
        {

            if (mLab.user.id == 0)
            {
                mLab.user.passwordHash = Infrastructure.HashPasswordHelper.HashPassword(mLab.user.passwordHash);
            }
            mLab.user = userRepository.SaveUser(mLab.user);

            if (mLab.user.id > 0)
            {
                mLab.userId = mLab.user.id;
                labRepository.SaveLab(mLab);
            }
            return mLab;
        }
    }

}
