using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;
using System.Collections.Generic;

namespace MedAPI.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository patientRepository;
        private readonly IProvinceRepository provinceRepository;
        private readonly IUserRepository userRepository;
        public PatientService(IPatientRepository patientRepository, IProvinceRepository provinceRepository, IUserRepository userRepository)
        {
            this.patientRepository = patientRepository;
            this.provinceRepository = provinceRepository;
            this.userRepository = userRepository;

        }

        public List<Patient> GetAllPatient()
        {
            return patientRepository.GetAllPatient();
        }

        public Patient GetPatientById(long id)
        {
            return patientRepository.GetPatientById(id);
        }
        public bool DeletePatientById(long id)
        {
            return patientRepository.DeletePatientById(id);
        }
        public List<Province> GetProvinceByDepartment(long id)
        {
          return  provinceRepository.GetAllProvinceByDeparmentId(id);
        }
        public List<District> GetDistrictByprovinceId(long id)
        {
            return patientRepository.GetDistrictByprovinceId(id);
        }

        public Patient SavePatient(Domain.Patient mPatient)
        {
            if (mPatient.user.id == 0)
            {
                mPatient.user.passwordHash = Infrastructure.HashPasswordHelper.HashPassword(mPatient.user.passwordHash);
            }
            mPatient.user = userRepository.SaveUser(mPatient.user);

            if (mPatient.user.id > 0)
            {
                mPatient.id = mPatient.user.id;
                patientRepository.SavePatient(mPatient);
            }
            return mPatient;
        }
        public User GetPatientByDocumentNumber(int documentNumber)
        {
            return patientRepository.GetPatientByDocumentNumber(documentNumber);
        }
    }
}
