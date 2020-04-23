using MedAPI.Domain;
using System.Collections.Generic;

namespace MedAPI.Infrastructure.IService
{
    public interface IExamService
    {
        List<Exam> SearchByName(string name);
        List<Exam> GetAllExam();
        Exam GetExamById(long id);
        int SaveExam(Exam mExam);
        bool DeleteExamById(long id);
    }
}
