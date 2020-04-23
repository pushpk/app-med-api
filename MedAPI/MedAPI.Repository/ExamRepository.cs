using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedAPI.Repository
{
    public class ExamRepository : IExamRepository
    {
        public bool DeleteExamById(long id)
        {
            bool isSuccess = false;
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                var efExam = context.exams.Where(m => m.id == id).FirstOrDefault();
                if (efExam != null)
                {
                    efExam.deleted = BitConverter.GetBytes(true);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
        }

        public List<Exam> GetAllExam()
        {
            var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return (from ex in context.exams
                        where ex.deleted != bytes
                        select new Exam()
                        {
                            Id = ex.id,
                            Name = ex.name,
                            Type = ex.type
                        }).ToList();
            }
        }

        public Exam GetExamById(long id)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return context.exams.Where(x => x.id == id && x.deleted != null)
                   .Select(x => new Exam()
                   {
                       Id = x.id,
                       Name = x.name,
                       Type = x.type
                   }).FirstOrDefault();
            }
        }

        public int SaveExam(Exam mExam)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                var efExam = context.exams.Where(x => x.id == mExam.Id).FirstOrDefault();
                if (efExam == null)
                {
                    efExam = new DataAccess.exam();
                    context.exams.Add(efExam);
                }
                efExam.name = mExam.Name;
                efExam.type = mExam.Type;
                context.SaveChanges();
                return Convert.ToInt32(efExam.id);
            }
        }

        public List<Exam> SearchByName(string name)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return context.exams.Where(x => x.name.Contains(name) && x.deleted != null)
                     .Select(x => new Exam()
                     {
                         Id = x.id,
                         Name = x.name,
                         Type = x.type
                     }).ToList();
            }
        }
    }
}
