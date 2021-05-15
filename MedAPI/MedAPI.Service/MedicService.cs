using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;
using System.Collections.Generic;

namespace MedAPI.Service
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

        public Medic SaveMedic(Domain.Medic mMedic)
        {

            if (mMedic.user.id == 0)
            {
                mMedic.user.passwordHash = Infrastructure.HashPasswordHelper.HashPassword(mMedic.user.passwordHash);
            }
            mMedic.user = userRepository.SaveUser(mMedic.user);

            if (mMedic.user.id > 0)
            {
                mMedic.id = mMedic.user.id;
                medicRepository.SaveMedic(mMedic);
            }
            return mMedic;
        }

        public Medic UpdateMedic(Domain.Medic mMedic)
        {

                medicRepository.UpdateMedic(mMedic);
            
            return mMedic;
        }
    }



}
