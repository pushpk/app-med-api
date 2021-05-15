using MedAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Infrastructure.IRepository
{
    public interface IPatientRepository
    {
        List<Patient> GetAllPatient();
        int GetActivePatientCount();
        Patient GetPatientById(long id);
        bool DeletePatientById(long id);
        List<District> GetDistrictByprovinceId(long id);
        void SavePatient(Patient mPatient);

        //User GetPatientByDocumentNumber(int documentNumber);
        Patient GetPatientByDocumentNumber(int documentNumber);
        bool SaveAllergiesList(List<PatientAllergies> mAllergies);
        bool SaveMedicinesList(List<PatientMedicines> mMedicines);
        bool SavePersonalBackgroundList(List<PatientPersonalBackgrounds> mPersonalBackgrounds);
        bool SaveMotherBackgroundList(List<PatientMotherbackgrounds> mMotherBackgrounds);
        bool SaveFatherBackgroundList(List<PatientFatherbackgrounds> mFatherBackgrounds);
        bool SaveSymptoms(SymptomsWithCustom mSymptoms);
        SymptomsWithCustom GetSymptomsByPatientId(string docNum);
        List<Symptoms> GetAllSymptoms();
        PatientMedicPermission checkMedicAccessForPatientData(long id);
        
        bool ChangeMedicAccess(PatientMedicPermission medicPermission);
        List<PatientMedicPermission> getPermissionRequests(long userId);
        void InsertOrChangePermissionRequest(long userId, int medicId);
    }
}
