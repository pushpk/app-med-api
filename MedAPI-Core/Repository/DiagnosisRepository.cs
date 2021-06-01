using Data.DataModels;
using Repository.DTOs;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class DiagnosisRepository : IDiagnosisRepository
    {
        private readonly registroclinicocoreContext context;
        public DiagnosisRepository(registroclinicocoreContext context)
        {
            this.context = context;

        }
        public bool DeleteDiagnosisById(long id)
        {
            bool isSuccess = false;
            
                var efDiagnosis = context.diagnoses.Where(m => m.id == id).FirstOrDefault();
                if (efDiagnosis != null)
                {
                    efDiagnosis.deleted = true;//BitConverter.GetBytes(true); 
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            
        }

        public List<Diagnosis> GetAllDiagnosis()
        {
            //var bytes = BitConverter.GetBytes(true);

            return (from dg in context.diagnoses
                    where dg.deleted != true
                    orderby dg.code ascending
                    select new Diagnosis()
                    {
                        id = dg.id,
                        code = dg.code,
                        title = dg.title,
                        chapterId = dg.chapter_id
                    }).ToList();
              
        }

        public Diagnosis GetDiagnosisById(long id)
        {
            
                return context.diagnoses.Where(x => x.id == id && x.deleted != true)
                   .Select(x => new Diagnosis()
                   {
                       id = x.id,
                       code = x.code,
                       title = x.title,
                       chapterId = x.chapter_id
                   }).FirstOrDefault();
            
        }

        public int SaveChapter(Chapter mChapter)
        {
          
                var efChapter = context.chapters.Where(x => x.id == mChapter.id).FirstOrDefault();
                if (efChapter == null)
                {
                    efChapter = new chapter();
                    context.chapters.Add(efChapter);
                }
                efChapter.code = mChapter.code;
                efChapter.title = mChapter.title;
                context.SaveChanges();
                return Convert.ToInt16(efChapter.id);
            
        }

        public int SaveDiagnosis(Diagnosis mDiagnosis)
        {
           
                var efDiagnosis = context.diagnoses.Where(x => x.id == mDiagnosis.id).FirstOrDefault();
                if (efDiagnosis == null)
                {
                    efDiagnosis = new diagnosis();
                    context.diagnoses.Add(efDiagnosis);
                    //efDiagnosis.CreatedDate = DateTime.Now;
                }
                efDiagnosis.code = mDiagnosis.code;
                efDiagnosis.title = mDiagnosis.title;
                efDiagnosis.chapter_id = mDiagnosis.chapterId;
                context.SaveChanges();
                return Convert.ToInt16(efDiagnosis.id);
            
        }

        public List<Diagnosis> SearchByNameOrCode(string name)
        {
           
                return context.diagnoses.Where(x => (x.code.Contains(name) || x.title.Contains(name)) && x.deleted != true && x.chapter_id==1)
                     .Select(x => new Diagnosis()
                     {
                         id = x.id,
                         code = x.code,
                         title = x.title,
                         chapterId = x.chapter_id,
                     }).ToList();
            
        }

        public List<Diagnosis> SearchByName(string name)
        {
            
                return context.diagnoses.Where(x => x.title.Contains(name) && x.deleted != true)
                     .Select(x => new Diagnosis()
                     {
                         id = x.id,
                         code = x.code,
                         title = x.title,
                         chapterId = x.chapter_id,
                     }).ToList();
            
        }

       
    }
}

