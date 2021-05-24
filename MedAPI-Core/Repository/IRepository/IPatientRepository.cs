using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IPatientRepository
    {
        //List<Patient> GetAllPatient();
        //int GetActivePatientCount();
        //Patient GetPatientById(long id);
        //bool DeletePatientById(long id);
        //List<District> GetDistrictByprovinceId(long id);
        void SavePatient(Patient mPatient);

        //User GetPatientByDocumentNumber(int documentNumber);
      //  Patient GetPatientByDocumentNumber(int documentNumber);
       // bool SaveAllergiesList(List<PatientAllergy> mAllergies);
        //bool SaveMedicinesList(List<PatientMedicine> mMedicines);
        //bool SavePersonalBackgroundList(List<PatientPersonalbackground> mPersonalBackgrounds);
        //bool SaveMotherBackgroundList(List<PatientMotherbackground> mMotherBackgrounds);
        //bool SaveFatherBackgroundList(List<PatientFatherbackground> mFatherBackgrounds);
        //bool SaveSymptoms(SymptomsWithCustom mSymptoms);
        //SymptomsWithCustom GetSymptomsByPatientId(string docNum);
        //List<Symptom> GetAllSymptoms();
        //PatientMedicPermission checkMedicAccessForPatientData(long id);
        
        //bool ChangeMedicAccess(PatientMedicPermission medicPermission);
        //List<PatientMedicPermission> getPermissionRequests(long userId);
        //void InsertOrChangePermissionRequest(long userId, int medicId);
    }
}
