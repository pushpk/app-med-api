using Repository.DTOs;
using Repository.IRepository;
using Services.IServices;
using System.Collections.Generic;
using Services.IServices;

namespace Services
{
    public class MedicService : IMedicService
    {
        private readonly IMedicRepository medicRepository;
        private readonly IUserRepository userRepository;
        public MedicService(IMedicRepository medicRepository, IUserRepository userRepository)
        {
            this.medicRepository = medicRepository;
            this.userRepository = userRepository;
        }

        public List<Medic> GetAllMedic()
        {
            var medics = medicRepository.GetAllMedic();
            if (medics != null && medics.Count > 0)
            {
                foreach (var item in medics)
                {
                    item.user = userRepository.GetUserById(item.id);
                }
            }
            return medics;
        }
        public int GetActiveMedicCount()
        {
            return medicRepository.GetActiveMedicCount();
        }
        public Medic GetMedicById(long id)
        {
            return medicRepository.GetMedicById(id);
        }

        public bool DeleteMedicById(long id)
        {
            return medicRepository.DeleteMedicById(id);
        }

        public Medic SaveMedic(Repository.DTOs.Medic mMedic)
        {

            mMedic.user = userRepository.SaveUser(mMedic.user);

            if (mMedic.user.Id > 0)
            {
                mMedic.id = mMedic.user.Id;

                medicRepository.SaveMedic(mMedic);
            }
            return mMedic;
        }

        public Medic UpdateMedic(Medic mMedic)
        {

                medicRepository.UpdateMedic(mMedic);
            
            return mMedic;
        }
    }



}
