using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;
using System.Collections.Generic;

namespace MedAPI.Service
{
    public class NurseService : INurseService
    {
        private readonly INurseRepository nurseRepository;
        private readonly IUserRepository userRepository;
        public NurseService(INurseRepository nurseRepository, IUserRepository userRepository)
        {
            this.nurseRepository = nurseRepository;
            this.userRepository = userRepository;
        }

        public List<Nurse> GetAll()
        {
            var nurses = nurseRepository.GetAll();
            if(nurses!=null && nurses.Count > 0)
            {
                foreach (var item in nurses)
                {
                    item.User = userRepository.GetUserById(item.Id);
                    var nurseSpecialties = nurseRepository.GetNurseSpecialtiesById(item.Id);
                    if (nurseSpecialties != null)
                    {
                        item.NurseSpecialties = nurseSpecialties;
                    }
                }
            }
            return nurses;
        }

        public Nurse GetNurseById(long id)
        {
            var mNurse= nurseRepository.GetNurseById(id);
            if (mNurse != null && mNurse.Id>0)
            {
                mNurse.User= userRepository.GetUserById(mNurse.Id);
                var nurseSpecialties = nurseRepository.GetNurseSpecialtiesById(mNurse.Id);
                if (nurseSpecialties != null)
                {
                    mNurse.NurseSpecialties = nurseSpecialties;
                }
            }
            return mNurse;
        }

        public Nurse SaveNurse(Nurse mNurse)
        {
            if (mNurse.User.id == 0)
            {
                mNurse.User.passwordHash = Infrastructure.HashPasswordHelper.HashPassword(mNurse.User.passwordHash);
            }
            mNurse.User = userRepository.SaveUser(mNurse.User);

            if (mNurse.User.id > 0)
            {
                mNurse.Id = mNurse.User.id;
                nurseRepository.SaveNurse(mNurse);

                mNurse.NurseSpecialties.NurseId = mNurse.User.id;
                nurseRepository.SaveSpecialtie(mNurse.NurseSpecialties);
            }
            return mNurse;
        }
    }
}
