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
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return (from me in context.medics
                        select new Medic()
                        {
                            Id = me.id,
                            Cmp = me.cmp,
                            Rne = me.rne
                        }).ToList();
            }
        }

        public Medic GetMedicById(long id)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return context.medics.Where(x => x.id == id)
                   .Select(x => new Medic()
                   {
                       Id = x.id,
                       Cmp=x.cmp,
                       Rne=x.rne
                   }).FirstOrDefault();
            }
        }
        public bool DeleteMedicById(long id)
        {
            bool isSuccess = false;
            using (var context = new DataAccess.RegistroclinicoEntities())
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
    }
}
