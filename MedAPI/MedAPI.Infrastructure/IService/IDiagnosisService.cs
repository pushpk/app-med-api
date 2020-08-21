using MedAPI.Domain;
using System.Collections.Generic;

namespace MedAPI.Infrastructure.IService
{
    public interface IDiagnosisService
    {
        List<Diagnosis> SearchByNameOrCode(string name);
        List<Diagnosis> GetAllDiagnosis();
        Diagnosis GetDiagnosisById(long id);
        int SaveDiagnosis(Diagnosis mDiagnosis);
        bool DeleteDiagnosisById(long id);
    }
}
