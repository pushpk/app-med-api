using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;
using System.Collections.Generic;

namespace MedAPI.Service
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository examRepository;

        public ExamService(IExamRepository examRepository)
        {
            this.examRepository = examRepository;
        }

        public bool DeleteExamById(long id)
        {
            return examRepository.DeleteExamById(id);
        }

        public List<Exam> GetAllExam()
        {
            return examRepository.GetAllExam();
        }

        public Exam GetExamById(long id)
        {
            return examRepository.GetExamById(id);
        }

        public int SaveExam(Exam mExam)
        {
            return examRepository.SaveExam(mExam);
        }

        public List<Exam> SearchByName(string name)
        {
            List<Exam> exams = new List<Exam>();
            if (!string.IsNullOrEmpty(name))
            {
                exams = examRepository.SearchByName(name);
            }
            return exams;
        }
    }
}
