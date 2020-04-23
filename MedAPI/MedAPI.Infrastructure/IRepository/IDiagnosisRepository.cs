using MedAPI.Domain;
using System.Collections.Generic;

namespace MedAPI.Infrastructure.IRepository
{
    public interface IDiagnosisRepository
    {
        List<Diagnosis> SearchByCode(string name);
        List<Diagnosis> SearchByName(string name);
        List<Diagnosis> GetAllDiagnosis();
        Diagnosis GetDiagnosisById(long id);
        int SaveDiagnosis(Diagnosis mDiagnosis);
        int SaveChapter(Chapter mChapter);
        bool DeleteDiagnosisById(long id);
    }
}
