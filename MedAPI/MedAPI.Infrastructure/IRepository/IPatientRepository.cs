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
        Patient GetPatientById(long id);
        bool DeletePatientById(long id);
        List<District> GetDistrictByprovinceId(long id);
        //Patient GetPatientByDocumentNumber(string documentNumber);
    }
}
