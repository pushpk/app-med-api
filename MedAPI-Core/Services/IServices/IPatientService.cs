using Repository.DTOs;
using System.Collections.Generic;

namespace Services.IServices
{
    public interface IPatientService
    {
        List<Patient> GetAllPatient();
        int GetActivePatientCount();
        Patient GetPatientById(long id);
        bool DeletePatientById(long id);
        List<Province> GetProvinceByDepartment(long id);
        List<District> GetDistrictByprovinceId(long id);
        Patient SavePatient(Patient mPatient);
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
        List<PatientMedicPermission> getPermissionRequests(long userId);
        bool ChangeMedicAccess(PatientMedicPermission medicPermission);
        void InsertOrChangePermissionRequest(long userId, int medicId);
    }
}
