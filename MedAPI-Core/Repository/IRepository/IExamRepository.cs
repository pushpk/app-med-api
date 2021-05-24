using Data.Model;
using System.Collections.Generic;

namespace Repository.IRepository
{
    public interface IExamRepository
    {
        List<Exam> SearchByName(string name);
        List<Exam> GetAllExam();
        Exam GetExamById(long id);
        int SaveExam(Exam mExam);
        bool DeleteExamById(long id);
    }
}
