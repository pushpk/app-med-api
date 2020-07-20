using MedAPI.Domain;
using System.Collections.Generic;

namespace MedAPI.Infrastructure.IService
{
    public interface IPatientService
    {
        List<Domain.Patient> GetAllPatient();
        Domain.Patient GetPatientById(long id);
        bool DeletePatientById(long id);
        List<Province> GetProvinceByDepartment(long id);
        List<District> GetDistrictByprovinceId(long id);
        Domain.Patient SavePatient(Domain.Patient mPatient);
        //User GetPatientByDocumentNumber(int documentNumber);        
        Domain.Patient GetPatientByDocumentNumber(int documentNumber);
    }
}
