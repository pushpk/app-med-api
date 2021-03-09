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

        public int GetActivePatientCount()
        {
            return patientRepository.GetActivePatientCount();
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

        public Domain.Patient SavePatient(Domain.Patient mPatient)
        {
            if (mPatient.user.id == 0)
            {
                mPatient.user.passwordHash = Infrastructure.HashPasswordHelper.HashPassword(mPatient.user.passwordHash);
            }
            mPatient.user = userRepository.SaveUser(mPatient.user);

            if (mPatient.user.id > 0)
            {
                mPatient.userId = mPatient.user.id;
                patientRepository.SavePatient(mPatient);
            }
            return mPatient;
        }
        public Patient GetPatientByDocumentNumber(int documentNumber)
        {
            return patientRepository.GetPatientByDocumentNumber(documentNumber);
        }


        public bool SaveAllergiesList(List<PatientAllergies> mAllergies)
        {
            return patientRepository.SaveAllergiesList(mAllergies);
        }
        public bool SaveMedicinesList(List<PatientMedicines> mMedicines)
        {
            return patientRepository.SaveMedicinesList(mMedicines);
        }
        public bool SavePersonalBackgroundList(List<PatientPersonalBackgrounds> mPersonalBackgrounds)
        {
            return patientRepository.SavePersonalBackgroundList(mPersonalBackgrounds);
        }
        public bool SaveMotherBackgroundList(List<PatientMotherbackgrounds> mMotherBackgrounds)
        {
            return patientRepository.SaveMotherBackgroundList(mMotherBackgrounds);
        }
        public bool SaveFatherBackgroundList(List<PatientFatherbackgrounds> mFatherBackgrounds)
        {
            return patientRepository.SaveFatherBackgroundList(mFatherBackgrounds);
        }

        public bool SaveSymptoms(SymptomsWithCustom mSymptoms)
        {
            return patientRepository.SaveSymptoms(mSymptoms);
        }


        public SymptomsWithCustom GetSymptomsByPatientId(string docNum)
        {
            return patientRepository.GetSymptomsByPatientId(docNum);
        }

        public List<Symptoms> GetAllSymptoms()
        {
            return patientRepository.GetAllSymptoms();


        }

        public PatientMedicPermission checkMedicAccessForPatientData(long id)
        {
            return patientRepository.checkMedicAccessForPatientData(id);        }

        public List<PatientMedicPermission> getPermissionRequests(long userId)
        {
            return patientRepository.getPermissionRequests(userId);
        }

        public bool ChangeMedicAccess(PatientMedicPermission medicPermission)
        {

            return patientRepository.ChangeMedicAccess(medicPermission);
        }
    
    }
}
