using MedAPI.Domain;
using System.Collections.Generic;

namespace MedAPI.Infrastructure.IService
{
    public interface IPatientService
    {
        List<Domain.Patient> GetAllPatient();
        int GetActivePatientCount();
        Domain.Patient GetPatientById(long id);
        bool DeletePatientById(long id);
        List<Province> GetProvinceByDepartment(long id);
        List<District> GetDistrictByprovinceId(long id);
        Domain.Patient SavePatient(Domain.Patient mPatient);
        //User GetPatientByDocumentNumber(int documentNumber);        
        Domain.Patient GetPatientByDocumentNumber(int documentNumber);

        bool SaveAllergiesList(List<PatientAllergies> mAllergies);
        bool SaveMedicinesList(List<PatientMedicines> mMedicines);
        bool SavePersonalBackgroundList(List<PatientPersonalBackgrounds> mPersonalBackgrounds);
        bool SaveMotherBackgroundList(List<PatientMotherbackgrounds> mMotherBackgrounds);
        bool SaveFatherBackgroundList(List<PatientFatherbackgrounds> mFatherBackgrounds);
        bool SaveSymptoms(SymptomsWithCustom mSymptoms);
        SymptomsWithCustom GetSymptomsByPatientId(string docNum);
        List<Symptoms> GetAllSymptoms();
    }
}
