using Data.Model;
using System.Collections.Generic;

namespace Repository.IRepository
{
    public interface IDiagnosisRepository
    {
        List<Diagnosis> SearchByNameOrCode(string name);
        List<Diagnosis> SearchByName(string name);
        List<Diagnosis> GetAllDiagnosis();
        Diagnosis GetDiagnosisById(long id);
        int SaveDiagnosis(Diagnosis mDiagnosis);
        int SaveChapter(Chapter mChapter);
        bool DeleteDiagnosisById(long id);
    }
}
