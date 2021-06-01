using AutoMapper;
using Data.DataModels; using Repository.DTOs;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{

    public class ExamRepository : IExamRepository
    {
        private readonly registroclinicocoreContext context;
        public ExamRepository(registroclinicocoreContext context)
        {
            this.context = context;

        }
        public bool DeleteExamById(long id)
        {
            bool isSuccess = false;
           
                var efExam = context.exams.Where(m => m.id == id).FirstOrDefault();
                if (efExam != null)
                {
                    efExam.deleted = true;//BitConverter.GetBytes(true);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            
        }

        public List<Exam> GetAllExam()
        {
            //var bytes = BitConverter.GetBytes(true);
            
                return (from ex in context.exams
                        where ex.deleted != true
                        select new Exam()
                        {
                            id = ex.id,
                            name = ex.name,
                            type = ex.type
                        }).ToList();
            
        }

        public Exam GetExamById(long id)
        {
           
                return context.exams.Where(x => x.id == id && x.deleted != false)
                   .Select(x => new Exam()
                   {
                       id = x.id,
                       name = x.name,
                       type = x.type
                   }).FirstOrDefault();
            
        }

        public int SaveExam(Exam mExam)
        {
           
                var efExam = context.exams.Where(x => x.id == mExam.id).FirstOrDefault();
                if (efExam == null)
                {
                    efExam = new exam();
                    context.exams.Add(efExam);
                }
                efExam.name = mExam.name;
                efExam.type = mExam.type;
                context.SaveChanges();
                return Convert.ToInt32(efExam.id);
            
        }

        public List<Exam> SearchByName(string name)
        {
            return new List<Exam>();
           
                //return Mapper.Map<List<Exam>>(context.exams.Where(x => x.name.Contains(name) && !x.deleted).ToList());
                
            
        }
    }
}
