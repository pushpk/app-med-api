using Repository.DTOs;
using System.Collections.Generic;

namespace Services.IServices
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
