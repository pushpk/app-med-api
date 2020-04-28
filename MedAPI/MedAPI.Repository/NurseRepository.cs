using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace MedAPI.Repository
{
    public class NurseRepository : INurseRepository
    {
        public List<Nurse> GetAll()
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return (from n in context.nurses
                        select new Nurse()
                        {
                            Id = n.id,
                            MedicRegistration = n.medicRegistration,
                        }).ToList();
            }
        }
        public NurseSpecialties GetNurseSpecialtiesById(long id)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return (from n in context.nurse_specialties
                        select new NurseSpecialties
                        {
                            NurseId = n.Nurse_id,
                            Specialties = n.specialties
                        }).FirstOrDefault();
            }
        }

        public Nurse GetNurseById(long id)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return (from n in context.nurses
                        select new Nurse()
                        {
                            Id = n.id,
                            MedicRegistration = n.medicRegistration,
                        }).FirstOrDefault();
            }
        }

        public void SaveNurse(Nurse mNurse)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                var efNurse = context.nurses.Where(m => m.id == mNurse.Id).FirstOrDefault();
                if (efNurse == null)
                {
                    efNurse = new DataAccess.nurse();
                    context.nurses.Add(efNurse);
                }
                efNurse.id = mNurse.Id;
                efNurse.medicRegistration = mNurse.MedicRegistration;
                context.SaveChanges();
            }
        }
        public void SaveSpecialtie(NurseSpecialties mNurseSpecialties)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                var efNurseSpecialties = context.nurse_specialties.Where(m => m.Nurse_id == mNurseSpecialties.NurseId).FirstOrDefault();
                if (efNurseSpecialties == null)
                {
                    efNurseSpecialties = new DataAccess.nurse_specialties();
                    context.nurse_specialties.Add(efNurseSpecialties);
                }
                efNurseSpecialties.Nurse_id = mNurseSpecialties.NurseId;
                efNurseSpecialties.specialties = mNurseSpecialties.Specialties;
                context.SaveChanges();
            }
        }
    }
}
