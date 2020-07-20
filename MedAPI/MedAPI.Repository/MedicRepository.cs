using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedAPI.Repository
{
    public class MedicRepository : IMedicRepository
    {
        public List<Medic> GetAllMedic()
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return (from me in context.medics
                        select new Medic()
                        {
                            id = me.id,
                            cmp = me.cmp,
                            rne = me.rne
                        }).ToList();
            }
        }

        public Medic GetMedicById(long id)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return context.medics.Where(x => x.id == id)
                   .Select(x => new Medic()
                   {
                       id = x.id,
                       cmp=x.cmp,
                       rne=x.rne
                   }).FirstOrDefault();
            }
        }
        public bool DeleteMedicById(long id)
        {
            bool isSuccess = false;
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efMedics= context.medics.Where(m => m.id == id).FirstOrDefault();
                if (efMedics != null)
                {
                    context.medics.Remove(efMedics);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
        }

        public long SaveMedic(Medic mMedic)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efMedic = context.medics.Where(m => m.id == mMedic.id).FirstOrDefault();
                if (efMedic == null)
                {
                    efMedic = new DataAccess.medic();
                    context.medics.Add(efMedic);
                }
                efMedic.id = mMedic.id;
                efMedic.rne = mMedic.rne;
                efMedic.cmp = mMedic.cmp;
                context.SaveChanges();
                return efMedic.id;
            }
        }
    }
}
