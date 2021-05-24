using Data.Model;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class DiagnosisRepository : IDiagnosisRepository
    {
        public bool DeleteDiagnosisById(long id)
        {
            bool isSuccess = false;
            using (var context = new registroclinicocoreContext())
            {
                var efDiagnosis = context.diagnosis.Where(m => m.id == id).FirstOrDefault();
                if (efDiagnosis != null)
                {
                    efDiagnosis.deleted = true;//BitConverter.GetBytes(true); 
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
        }

        public List<Diagnosis> GetAllDiagnosis()
        {
            //var bytes = BitConverter.GetBytes(true);
            using (var context = new registroclinicocoreContext())
            {
                return (from dg in context.diagnosis
                        where dg.deleted != true
                        orderby dg.code ascending
                        select new Diagnosis()
                        {
                            id = dg.id,
                            code = dg.code,
                            title = dg.title,
                            chapterId = dg.chapter_id
                        }
                          ).ToList();
            }
        }

        public Diagnosis GetDiagnosisById(long id)
        {
            using (var context = new registroclinicocoreContext())
            {
                return context.diagnosis.Where(x => x.id == id && x.deleted != true)
                   .Select(x => new Diagnosis()
                   {
                       id = x.id,
                       code = x.code,
                       title = x.title,
                       chapterId = x.chapter_id
                   }).FirstOrDefault();
            }
        }

        public int SaveChapter(Chapter mChapter)
        {
            using (var context = new registroclinicocoreContext())
            {
                var efChapter = context.chapters.Where(x => x.id == mChapter.id).FirstOrDefault();
                if (efChapter == null)
                {
                    efChapter = new DataAccess.chapter();
                    context.chapters.Add(efChapter);
                }
                efChapter.code = mChapter.code;
                efChapter.title = mChapter.title;
                context.SaveChanges();
                return Convert.ToInt16(efChapter.id);
            }
        }

        public int SaveDiagnosis(Diagnosis mDiagnosis)
        {
            using (var context = new registroclinicocoreContext())
            {
                var efDiagnosis = context.diagnosis.Where(x => x.id == mDiagnosis.id).FirstOrDefault();
                if (efDiagnosis == null)
                {
                    efDiagnosis = new DataAccess.diagnosi();
                    context.diagnosis.Add(efDiagnosis);
                    //efDiagnosis.CreatedDate = DateTime.Now;
                }
                efDiagnosis.code = mDiagnosis.code;
                efDiagnosis.title = mDiagnosis.title;
                efDiagnosis.chapter_id = mDiagnosis.chapterId;
                context.SaveChanges();
                return Convert.ToInt16(efDiagnosis.id);
            }
        }

        public List<Diagnosis> SearchByNameOrCode(string name)
        {
            using (var context = new registroclinicocoreContext())
            {
                return context.diagnosis.Where(x => (x.code.Contains(name) || x.title.Contains(name)) && x.deleted != true && x.chapter_id==1)
                     .Select(x => new Diagnosis()
                     {
                         id = x.id,
                         code = x.code,
                         title = x.title,
                         chapterId = x.chapter_id,
                     }).ToList();
            }
        }

        public List<Diagnosis> SearchByName(string name)
        {
            using (var context = new registroclinicocoreContext())
            {
                return context.diagnosis.Where(x => x.title.Contains(name) && x.deleted != true)
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
}

