using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedAPI.Repository
{
    public class DiagnosisRepository : IDiagnosisRepository
    {
        public bool DeleteDiagnosisById(long id)
        {
            bool isSuccess = false;
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                var efDiagnosis = context.diagnosis.Where(m => m.id == id).FirstOrDefault();
                if (efDiagnosis != null)
                {
                    efDiagnosis.deleted = BitConverter.GetBytes(true); 
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
        }

        public List<Diagnosis> GetAllDiagnosis()
        {
            var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return (from dg in context.diagnosis
                        where dg.deleted != bytes
                        orderby dg.code ascending
                        select new Diagnosis()
                        {
                            Id = dg.id,
                            Code = dg.code,
                            Title = dg.title,
                            ChapterId = dg.chapter_id
                        }
                          ).ToList();
            }
        }

        public Diagnosis GetDiagnosisById(long id)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return context.diagnosis.Where(x => x.id == id && x.deleted != null)
                   .Select(x => new Diagnosis()
                   {
                       Id = x.id,
                       Code = x.code,
                       Title = x.title,
                       ChapterId = x.chapter_id
                   }).FirstOrDefault();
            }
        }

        public int SaveChapter(Chapter mChapter)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                var efChapter = context.chapters.Where(x => x.id == mChapter.Id).FirstOrDefault();
                if (efChapter == null)
                {
                    efChapter = new DataAccess.chapter();
                    context.chapters.Add(efChapter);
                }
                efChapter.code = mChapter.Code;
                efChapter.title = mChapter.Title;
                context.SaveChanges();
                return Convert.ToInt16(efChapter.id);
            }
        }

        public int SaveDiagnosis(Diagnosis mDiagnosis)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                var efDiagnosis = context.diagnosis.Where(x => x.id == mDiagnosis.Id).FirstOrDefault();
                if (efDiagnosis == null)
                {
                    efDiagnosis = new DataAccess.diagnosi();
                    context.diagnosis.Add(efDiagnosis);
                    //efDiagnosis.CreatedDate = DateTime.Now;
                }
                efDiagnosis.code = mDiagnosis.Code;
                efDiagnosis.title = mDiagnosis.Title;
                efDiagnosis.chapter_id = mDiagnosis.ChapterId;
                context.SaveChanges();
                return Convert.ToInt16(efDiagnosis.id);
            }
        }

        public List<Diagnosis> SearchByCode(string name)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return context.diagnosis.Where(x => x.code.Contains(name) && x.deleted != null)
                     .Select(x => new Diagnosis()
                     {
                         Id = x.id,
                         Code = x.code,
                         Title = x.title,
                         ChapterId = x.chapter_id,
                     }).ToList();
            }
        }

        public List<Diagnosis> SearchByName(string name)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return context.diagnosis.Where(x => x.title.Contains(name) && x.deleted != null)
                     .Select(x => new Diagnosis()
                     {
                         Id = x.id,
                         Code = x.code,
                         Title = x.title,
                         ChapterId = x.chapter_id,
                     }).ToList();
            }
        }

       
    }
}

