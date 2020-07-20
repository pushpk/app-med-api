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
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efExam = context.exams.Where(m => m.id == id).FirstOrDefault();
                if (efExam != null)
                {
                    efExam.deleted = true;//BitConverter.GetBytes(true);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
        }

        public List<Exam> GetAllExam()
        {
            //var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return (from ex in context.exams
                        where ex.deleted != true
                        select new Exam()
                        {
                            id = ex.id,
                            name = ex.name,
                            type = ex.type
                        }).ToList();
            }
        }

        public Exam GetExamById(long id)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return context.exams.Where(x => x.id == id && x.deleted != false)
                   .Select(x => new Exam()
                   {
                       id = x.id,
                       name = x.name,
                       type = x.type
                   }).FirstOrDefault();
            }
        }

        public int SaveExam(Exam mExam)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efExam = context.exams.Where(x => x.id == mExam.id).FirstOrDefault();
                if (efExam == null)
                {
                    efExam = new DataAccess.exam();
                    context.exams.Add(efExam);
                }
                efExam.name = mExam.name;
                efExam.type = mExam.type;
                context.SaveChanges();
                return Convert.ToInt32(efExam.id);
            }
        }

        public List<Exam> SearchByName(string name)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return context.exams.Where(x => x.name.Contains(name) && x.deleted != false)
                     .Select(x => new Exam()
                     {
                         id = x.id,
                         name = x.name,
                         type = x.type
                     }).ToList();
            }
        }
    }
}
