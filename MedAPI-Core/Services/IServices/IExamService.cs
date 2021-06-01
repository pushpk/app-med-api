using Repository.DTOs;
using System.Collections.Generic;

namespace Services.IServices
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
