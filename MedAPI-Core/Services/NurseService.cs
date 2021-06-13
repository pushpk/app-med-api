using Repository.DTOs;
using Repository.IRepository;
using Services.IServices;
using System.Collections.Generic;

namespace Services
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
                    item.user = userRepository.GetUserById(item.id);
                    var nurseSpecialties = nurseRepository.GetNurseSpecialtiesById(item.id);
                    if (nurseSpecialties != null)
                    {
                        item.nurseSpecialties = nurseSpecialties;
                    }
                }
            }
            return nurses;
        }

        public Nurse GetNurseById(long id)
        {
            var mNurse= nurseRepository.GetNurseById(id);
            if (mNurse != null && mNurse.id>0)
            {
                mNurse.user= userRepository.GetUserById(mNurse.id);
                var nurseSpecialties = nurseRepository.GetNurseSpecialtiesById(mNurse.id);
                if (nurseSpecialties != null)
                {
                    mNurse.nurseSpecialties = nurseSpecialties;
                }
            }
            return mNurse;
        }

        public Nurse SaveNurse(Nurse mNurse)
        {
            if (mNurse.user.Id == 0)
            {
                mNurse.user.PasswordHash = Services.Helpers.HashPasswordHelper.HashPassword(mNurse.user.PasswordHash);
            }
            mNurse.user = userRepository.SaveUser(mNurse.user);

            if (mNurse.user.Id > 0)
            {
                mNurse.id = mNurse.user.Id;
                nurseRepository.SaveNurse(mNurse);

                mNurse.nurseSpecialties.nurseId = mNurse.user.Id;
                nurseRepository.SaveSpecialtie(mNurse.nurseSpecialties);
            }
            return mNurse;
        }
    }
}
