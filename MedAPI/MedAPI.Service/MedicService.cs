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
                    item.User = userRepository.GetUserById(item.Id);
                }
            }
            return medics;
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

            if (mMedic.User.id == 0)
            {
                mMedic.User.passwordHash = Infrastructure.HashPasswordHelper.HashPassword(mMedic.User.passwordHash);
            }
            mMedic.User = userRepository.SaveUser(mMedic.User);

            if (mMedic.User.id > 0)
            {
                mMedic.Id = mMedic.User.id;
                medicRepository.SaveMedic(mMedic);
            }
            return mMedic;
        }
    }

}
